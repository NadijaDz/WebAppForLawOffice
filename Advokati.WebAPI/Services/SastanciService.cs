using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Advokati.WebAPI.Services
{
    public class SastanciService : ISastanciService
    {
        private readonly AdvokatiContext _context;

        private readonly IMapper _mapper;
        public SastanciService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        public List<Model.Sastanci> Get(SastanciSearchRequest request)
        {
            var query = _context.Sastanci.AsQueryable().Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);

            var datum = DateTime.MinValue;

            if(datum != request.DatumSastanka.Date)
            {
                request.DatumSastanka = request.DatumSastanka.AddHours(-2);
                query = query.Where(x => x.DatumSastanka.ToString("dd-MMM-yyyy").StartsWith(request.DatumSastanka.ToString("dd-MMM-yyyy"))).Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);
            }

            if(request.Odobreno == false)
            {
                query = query.Where(x => x.Odobreno == false).Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);
            }

            query = query.Where(p => p.IsDeleted == false).Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);

            var list = query.ToList();
            return _mapper.Map<List<Model.Sastanci>>(list);
        }
        public List<Database.Korisnici> GetAdvokatiPreporuka(int vrstaUslugeId)
        {
            var query = _context.Predmeti.AsQueryable().Include(c => c.VrstaUsluge).Include(z => z.Zaposlenici);

        
            query = query.Where(x => x.VrstaId == vrstaUslugeId).Include(c=> c.Zaposlenici);
        
            query = query.Where(p => p.IsDeleted == false).Include(c => c.Klijent).Include(z => z.Zaposlenici);

           
            var list = query.ToList();


            List<Database.Korisnici> listAdvokata = new List<Database.Korisnici>();
 

            foreach (var item in list)
            {

                bool alreadyExist = listAdvokata.Contains(item.Zaposlenici);
                if (alreadyExist == false)
                {
                   if(item.Zaposlenici.UlogeId == 1)
                    {
                        listAdvokata.Add(item.Zaposlenici);

                    }
                }
                
            }
            

            
            return listAdvokata;
        }

        public Model.Sastanci GetById(int id)
        {
            var entity = _context.Sastanci.Find(id);
            return _mapper.Map<Model.Sastanci>(entity);
        }

        public Model.Sastanci Insert(SastanciInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Sastanci>(request);
            _context.Sastanci.Add(entity);
            _context.SaveChanges();

            var query = _context.Sastanci.AsQueryable().Include(c => c.Klijent).Include(z => z.Zaposlenici).Where(x => x.KlijentId.Equals(request.KlijentId));

            var temp = query.FirstOrDefault();


            string subject = "Sastanak";
                string body = "Novi sastanak je dodan u vaš raspored na dan "+ request.DatumSastanka.ToShortDateString();
                string FromMail = "testRS1test123@gmail.com";
                //string FromMail = "nadija.dziho@edu.fit.ba";


               string emailFormKlijent = temp.Klijent.Email;

                string emailTo = emailFormKlijent;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("testRS1test123@gmail.com", "Rstest123456");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

            

            return _mapper.Map<Model.Sastanci>(entity);
        }

        public Model.Sastanci Update(int id, SastanciInsertRequest request)
        {
            var entity = _context.Sastanci.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();

            if(request.Odobreno==true)
            {

                var advokat = _context.Korisnici.AsQueryable().Where(x => x.KorisnikId.Equals(request.ZaposleniciId));
                var tempAdvokat = advokat.FirstOrDefault();

                var klijent = _context.Korisnici.AsQueryable().Where(x => x.KorisnikId.Equals(request.KlijentId));
                var tempKlijent = klijent.FirstOrDefault();


                string emailToKlijent = tempKlijent.Email;
                string emailFromAdvokat = tempAdvokat.Email;




                var query = _context.Sastanci.AsQueryable().Include(c => c.Klijent).Include(z => z.Zaposlenici).Where(x => x.KlijentId.Equals(request.KlijentId));

                var temp = query.FirstOrDefault();


                string subject = "Sastanak";
                string body = "Sastanak vam je odobren.";
             



                string FromMail = "testRS1test123@gmail.com";
                string emailTo = emailToKlijent;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("testRS1test123@gmail.com", "Rstest123456");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }



            return _mapper.Map<Model.Sastanci>(entity);
        }


        public Model.Sastanci Delete(int id, SastanciInsertRequest request)
        {
            var entity = _context.Sastanci.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Sastanci>(entity);
        }


        public List<Model.Sastanci> GetAllSastanciById(int id)
        {
            var query = _context.Sastanci.AsQueryable().Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);

            if (id != 0)
            {
                query = query.Where(x => x.ZaposleniciId.Equals(id) || x.KlijentId.Equals(id)).Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);
             

            }


            query = query.Where(p => p.IsDeleted == false).Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);

            var list = query.ToList();


            return _mapper.Map<List<Model.Sastanci>>(list);

        }


        public List<Model.Sastanci> GetTodaySastanci(SastanciSearchRequest request)
        {
            var query = _context.Sastanci.AsQueryable().Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);




            query = query.Where(x => x.DatumSastanka.Date == DateTime.Now.Date).Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);




            query = query.Where(p => p.IsDeleted == false).Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(g => g.VrstaUsluge);

            var list = query.ToList();

            return _mapper.Map<List<Model.Sastanci>>(list);
        }


        public Model.Sastanci ZakaziSastanak(SastanciInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Sastanci>(request);
            _context.Sastanci.Add(entity);
            _context.SaveChanges();

            var advokat = _context.Korisnici.AsQueryable().Where(x => x.KorisnikId.Equals(request.ZaposleniciId));
            var tempAdvokat = advokat.FirstOrDefault();

            var klijent = _context.Korisnici.AsQueryable().Where(x => x.KorisnikId.Equals(request.KlijentId));
            var tempKlijent = klijent.FirstOrDefault();


            string emailFromKlijent = tempKlijent.Email;
            string emailToAdvokat = tempAdvokat.Email;




            var query = _context.Sastanci.AsQueryable().Include(c => c.Klijent).Include(z => z.Zaposlenici).Where(x => x.KlijentId.Equals(request.KlijentId));

            var temp = query.FirstOrDefault();


            string subject = "Sastanak";
            string body = "Klijent " + tempKlijent.Ime + " " + tempKlijent.Prezime +" želi da sa vama da zakaže sastanak dana " + request.DatumSastanka.ToShortDateString();
          




            string FromMail = "testRS1test123@gmail.com";
            string emailTo = emailToAdvokat;

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("testRS1test123@gmail.com", "Rstest123456");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);



            return _mapper.Map<Model.Sastanci>(entity);
        }

    }
}
