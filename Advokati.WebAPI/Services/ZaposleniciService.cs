using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.Database;
using Advokati.WebAPI.EF;
using Advokati.WebAPI.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Advokati.WebAPI.Services
{
    public class ZaposleniciService : IZaposleniciService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public ZaposleniciService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Model.Korisnici> Get(KorisniciSearchRequest request)
        {

            var uloge = _context.Uloge.ToList();
            var Sekretarid = -1;
            var Menadzerid = -1;
            var Advokatid = -1;
            var KlijentId = -1;
       
            foreach (var u in uloge)
            {
                if (u.Naziv == "Advokat")
                {
                    Advokatid = u.UlogaId;
                }
                if (u.Naziv == "Menadzer")
                {
                    Menadzerid = u.UlogaId;
                }
                if (u.Naziv == "Sekretar")
                {
                    Sekretarid = u.UlogaId;
                }
                if (u.Naziv == "Klijent")
                {
                    KlijentId = u.UlogaId;
                }
            }

            var query = _context.Korisnici.AsQueryable().Include(c => c.Uloge);


            if (!string.IsNullOrWhiteSpace(request?.ImePrezime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.ImePrezime) || x.Prezime.StartsWith(request.ImePrezime)).Include(c => c.Uloge);
            }

            if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.StartsWith(request.KorisnickoIme)).Include(c => c.Uloge);
            }
            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.StartsWith(request.Email)).Include(c => c.Uloge);
            }

            if (request.Status == false)
            {
                query = query.Where(x => x.Status == false).Include(c => c.Uloge);
            }

            query = query.Where(p => p.UlogeId == Sekretarid || p.UlogeId == Advokatid || p.UlogeId==Menadzerid || p.UlogeId== KlijentId).Include(c => c.Uloge);
            query = query.Where(p => p.IsDeleted == false).Include(c => c.Uloge);

                var list2 = query.ToList();
                return _mapper.Map<List<Model.Korisnici>>(list2);
            
        }


        public List<Model.Korisnici> Login(KorisniciSearchRequest request)
        {

            var uloge = _context.Uloge.ToList();
            var Sekretarid = -1;
            var Menadzerid = -1;
            var Advokatid = -1;
            var KlijentId = -1;

            foreach (var u in uloge)
            {
                if (u.Naziv == "Advokat")
                {
                    Advokatid = u.UlogaId;
                }
                if (u.Naziv == "Menadzer")
                {
                    Menadzerid = u.UlogaId;
                }
                if (u.Naziv == "Sekretar")
                {
                    Sekretarid = u.UlogaId;
                }
                if (u.Naziv == "Klijent")
                {
                    KlijentId = u.UlogaId;
                }
            }

            var query = _context.Korisnici.AsQueryable().Include(c => c.Uloge);


            if (!string.IsNullOrWhiteSpace(request?.ImePrezime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.ImePrezime) || x.Prezime.StartsWith(request.ImePrezime)).Include(c => c.Uloge);
            }

            if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.StartsWith(request.KorisnickoIme)).Include(c => c.Uloge);
            }
            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.StartsWith(request.Email)).Include(c => c.Uloge);
            }

            if (request.Status == false)
            {
                query = query.Where(x => x.Status == false).Include(c => c.Uloge);
            }

            query = query.Where(p => p.UlogeId == Sekretarid || p.UlogeId == Advokatid || p.UlogeId == Menadzerid || p.UlogeId == KlijentId).Include(c => c.Uloge);
            query = query.Where(p => p.IsDeleted == false).Include(c => c.Uloge);

            var list2 = query.ToList();
            return _mapper.Map<List<Model.Korisnici>>(list2);

        }
        public Model.Korisnici GetById(int id)
        {
            var entity = _context.Korisnici.Find(id);
            return _mapper.Map<Model.Korisnici>(entity);
        }


        public Model.Korisnici Authenticiraj(string username, string pass)
        {
            var user = _context.Korisnici.Include("Uloge").FirstOrDefault(x => x.KorisnickoIme == username);

            byte[] data = System.Convert.FromBase64String(pass);
            pass = System.Text.ASCIIEncoding.ASCII.GetString(data);

            if (user!=null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);
                if(newHash==user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnici>(user);
                }
            }
            return null;
        }


        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }


        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            request.IsDeleted = false;

            byte[] data = System.Convert.FromBase64String(request.Password);
            request.Password = System.Text.ASCIIEncoding.ASCII.GetString(data);

            byte[] data2 = System.Convert.FromBase64String(request.PasswordConfirmation);
            request.PasswordConfirmation = System.Text.ASCIIEncoding.ASCII.GetString(data2);


            var entity = _mapper.Map<Database.Korisnici>(request);


            if(request.Password !=request.PasswordConfirmation)
            {
                throw new UserException("Passwordi se ne slazu!");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

           
            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Update(int id, KorisniciInsertRequest request)
        {

            byte[] data = System.Convert.FromBase64String(request.Password);
            request.Password = System.Text.ASCIIEncoding.ASCII.GetString(data);

            byte[] data2 = System.Convert.FromBase64String(request.PasswordConfirmation);
            request.PasswordConfirmation = System.Text.ASCIIEncoding.ASCII.GetString(data2);


            var entity = _context.Korisnici.Find(id);
            _mapper.Map(request, entity);

            //if (request.Status==true)
            //{

            //    string subject = "Registracija";
            //    string body = "Odobrena vam je registarcija";
            //    //string FromMail = "testRS1test123@gmail.com";
            //    string FromMail = "nadija.dziho@edu.fit.ba";


            //    string temp =entity.Email;

            //    string emailTo = temp;

            //    MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //    mail.From = new MailAddress(FromMail);
            //    mail.To.Add(emailTo);
            //    mail.Subject = subject;
            //    mail.Body = body;
            //    SmtpServer.Port = 587;
            //    SmtpServer.UseDefaultCredentials = false;
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("testRS1test123@gmail.com", "Rstest123456");
            //    SmtpServer.EnableSsl = true;
            //    SmtpServer.Send(mail);

            //}



            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("Passwordi se ne slazu!");
                }
            }

            if (request.Password != "-" && request.PasswordConfirmation != "-")
            {
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }


            entity.IsDeleted = false;

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);

        }


        public bool provjeriOldPass(int id,string request)
        {
            
            byte[] data = System.Convert.FromBase64String(request);
            request = System.Text.ASCIIEncoding.ASCII.GetString(data);

            var entity = _context.Korisnici.Find(id);


            string LozinkaSalt = GenerateSalt();
            //string LozinkaHash = GenerateHash(LozinkaSalt, request);

            var LozinkaHash = GenerateHash(entity.LozinkaSalt, request);
            if (entity.LozinkaHash==LozinkaHash)
            {
                return true;
            }


            return false;

           
        }








            public Model.Korisnici Delete(int id, KorisniciInsertRequest request)
        {
            var entity = _context.Korisnici.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Korisnici>(entity);
        }
    }
}
