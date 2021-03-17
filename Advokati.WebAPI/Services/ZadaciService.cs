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
    public class ZadaciService : IZadaciService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;
        public ZadaciService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Zadaci> Get(ZadaciSearchRequest request)
        {
            var query = _context.Zadaci.AsQueryable().Include(c => c.Zaposlenici);

            if(!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv)).Include(c => c.Zaposlenici);
            }


            query = query.Where(p => p.IsDeleted == false).Include(c => c.Zaposlenici);

            var list = query.ToList();
            
            
            return _mapper.Map<List<Model.Zadaci>>(list);
        }

        public Model.Zadaci GetById(int id)
        {
            var entity = _context.Zadaci.Find(id);

            return _mapper.Map<Model.Zadaci>(entity);
        }

        public Model.Zadaci Insert(ZadaciInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Zadaci>(request);
            _context.Zadaci.Add(entity);
            _context.SaveChanges();


            var query = _context.Zadaci.AsQueryable().Include(c => c.Zaposlenici).Where(x => x.ZaposleniciId.Equals(request.ZaposleniciId));

            var temp = query.FirstOrDefault();


            string subject = "Zadatak";
            string body = "Novi zadatak je dodan u vaš kalendar.";
            string FromMail = "testRS1test123@gmail.com";
            //string FromMail = "nadija.dziho@edu.fit.ba";


            string emailFormAdvokat = temp.Zaposlenici.Email;

            string emailTo = emailFormAdvokat;


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


            return _mapper.Map<Model.Zadaci>(entity);
        }

        public Model.Zadaci Update(int id, ZadaciInsertRequest request)
        {
            var entity = _context.Zadaci.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.Zadaci>(entity);
        }


        public Model.Zadaci Delete(int id, ZadaciInsertRequest request)
        {
            var entity = _context.Zadaci.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);
        
            _context.SaveChanges();
            return _mapper.Map<Model.Zadaci>(entity);
        }


        //public List<Model.Zadaci> GetAllZadaciById2(int id)
        //{

        //    var zadaci = _context.Zadaci.ToList();
        //    var query = new List<Database.Zadaci>();

        //    foreach (var u in zadaci)
        //    {
        //        if(u.ZaposleniciId==id)
        //        {
        //            query.Add(u);
        //        }
        //    }

        //    var list = query.ToList();
        //    return _mapper.Map<List<Model.Zadaci>>(list);
        //}



        public List<Model.Zadaci> GetAllZadaciById(int id)
        {
            var query = _context.Zadaci.AsQueryable().Include(c => c.Zaposlenici);

            if (id!=0)
            {
                query = query.Where(x => x.ZaposleniciId.Equals(id)).Include(c => c.Zaposlenici);
            }


            query = query.Where(p => p.IsDeleted == false).Include(c => c.Zaposlenici);

            var list = query.ToList();


            return _mapper.Map<List<Model.Zadaci>>(list);

        }


        public List<Model.Zadaci> GetTodayZadaci(ZadaciSearchRequest request)
        {
            var query = _context.Zadaci.AsQueryable().Include(c => c.Zaposlenici);




            query = query.Where(x => x.DatumPocetka.Date == DateTime.Now.Date).Include(c => c.Zaposlenici);




            query = query.Where(p => p.IsDeleted == false).Include(c => c.Zaposlenici);

            var list = query.ToList();

            return _mapper.Map<List<Model.Zadaci>>(list);
        }

    }
}
