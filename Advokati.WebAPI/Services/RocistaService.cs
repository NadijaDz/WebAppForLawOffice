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
    public class RocistaService : IRocistaService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;


        public RocistaService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

        public List<Model.Rocista> Get(RocistaSearchRequest request)
        {

            var query = _context.Rocista.AsQueryable().Include(c => c.Predmeti).Include(z=>z.Zaposlenici);

            var datum = DateTime.MinValue;


            if (datum != request.DatumRocista)

            {
                request.DatumRocista = request.DatumRocista.AddHours(-2);

                query = query.Where(x => x.DatumRocista.ToString("dd-MMM-yyyy").StartsWith(request.DatumRocista.ToString("dd-MMM-yyyy"))).Include(c => c.Predmeti).Include(z => z.Zaposlenici);
            }

            query = query.Where(p => p.IsDeleted == false).Include(c => c.Predmeti).Include(z => z.Zaposlenici);

            var list = query.ToList();
            return _mapper.Map<List<Model.Rocista>>(list);

        }

        public Model.Rocista GetById(int id)
        {
            var entity = _context.Rocista.Find(id);
            return _mapper.Map<Model.Rocista>(entity);
        }

        public Model.Rocista Insert(RocistaInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Rocista>(request);

            _context.Rocista.Add(entity);
            _context.SaveChanges();

            var query = _context.Rocista.AsQueryable().Include(c => c.Predmeti).Include(z => z.Zaposlenici).Where(x => x.ZaposlenikId.Equals(request.ZaposlenikId));

            var temp = query.FirstOrDefault();


            string subject = "Ročište";
            string body = "Novo ročište je dododano u vaš kalendar.";
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


            return _mapper.Map<Model.Rocista>(entity);

        }

        public Model.Rocista Update(int id, RocistaInsertRequest request)
        {
            var entity = _context.Rocista.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.Rocista>(entity);
        }

        public Model.Rocista Delete(int id, RocistaInsertRequest request)
        {
            var entity = _context.Rocista.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Rocista>(entity);
        }


        public List<Model.Rocista> GetAllRocistaById(int id)
        {
            var query = _context.Rocista.AsQueryable().Include(c => c.Predmeti).Include(z => z.Zaposlenici);

          
           
            var predmeti = _context.Predmeti.AsQueryable().Include(c => c.VrstaUsluge).Include(z => z.Zaposlenici);

            predmeti=predmeti.Where(p=>p.KlijentId.Equals(id)).Include(c => c.VrstaUsluge).Include(z => z.Zaposlenici);


            List<Database.Rocista> listRocista = new List<Database.Rocista>();


            bool alreadyExist = false;
            if (predmeti.Count() != 0)
            {
                foreach (var p in predmeti)
                {
                   
                    foreach (var r in query)
                    {
                        if (p.PredmetId == r.PredmetID)
                        {
                            listRocista.Add(r);
                            alreadyExist = true;

                        }

                    }
                }

            }



            if (id != 0)
            {
                query = query.Where(x => x.ZaposlenikId.Equals(id)).Include(c => c.Predmeti).Include(z => z.Zaposlenici); ;
            }


            query = query.Where(p => p.IsDeleted == false).Include(c => c.Predmeti).Include(z => z.Zaposlenici);

            var list = query.ToList();


            if (alreadyExist)
            {
                list = listRocista.ToList();
            }

         



            return _mapper.Map<List<Model.Rocista>>(list);

        }

        public List<Model.Rocista> GetTodayRocista(RocistaSearchRequest request)
        {
            var query = _context.Rocista.AsQueryable().Include(c => c.Predmeti).Include(z => z.Zaposlenici);




            query = query.Where(x => x.DatumRocista.Date == DateTime.Now.Date).Include(c => c.Predmeti).Include(z => z.Zaposlenici);




            query = query.Where(p => p.IsDeleted == false).Include(c => c.Predmeti).Include(z => z.Zaposlenici);

            var list = query.ToList();

            return _mapper.Map<List<Model.Rocista>>(list);
        }

    }
}
