using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.Exceptions;
using Advokati.WebAPI.Filters;
using Advokati.WebAPI.Services;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Advokati.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetiController : ControllerBase
    {
        private readonly IPredmetiService _predmetiService;

        public PredmetiController(IPredmetiService predmetiService)
        {
            _predmetiService = predmetiService;
        }

        [HttpGet]
         public List<Model.Predmeti>  Get([FromQuery]PredmetiSearchRequest request)
        {
         
            return _predmetiService.Get(request);
           // return _predmetiService.Get2(request);


            
        }

        [HttpGet("{id}")]
        public Model.Predmeti GetById(int id)
        {
            return _predmetiService.GetById(id);
        }

        //[Authorize(Roles = "Advokat")]
        [HttpPost]
        public Model.Predmeti Insert(PredmetiInsertRequest request)
        {
           
             return _predmetiService.Insert(request);
            
           
        }
        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Predmeti Update(int id, PredmetiInsertRequest request)
        {
            return _predmetiService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Predmeti Delete(int id, PredmetiInsertRequest request)
        {
            return _predmetiService.Delete(id, request);
        }



        [Route("uploadFileAndSendEmail1/{id}")]
        [HttpPost]
        public async Task<IActionResult> uploadFileAndSendEmail1(int id,IFormFile file)
        {
            //Model.Predmeti predmet = _predmetiService.GetById(id);

            string mailToKlijent = _predmetiService.mailByKlijent(id);
            
          
            string subject = "Račun";
            string body = "Račun";
            //string FromMail = "testRS1test123@gmail.com";
            string FromMail = "nadija.dziho@edu.fit.ba";


            string temp = mailToKlijent;

            string emailTo = temp;

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

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                Attachment att = new Attachment(new MemoryStream(fileBytes), "racun.pdf");
                mail.Attachments.Add(att);
            }


            SmtpServer.Send(mail);


            return Ok();
        }


        
        public bool GetTroskovi([FromQuery]PredmetiSearchRequest request)
        {
            List<Model.Predmeti> lista = new List<Model.Predmeti>();

            lista = _predmetiService.Get(request);
            foreach (var p in lista)
            {
                if(p.UkupniTrosak==0)
                {
                    int result = DateTime.Compare((DateTime)p.RokUplate, DateTime.Now);
                    if (result < 0)
                    {
                        //send email
                    }

                }
            }

                return true;


        }


        [Route("todayPredmeti")]
        [HttpGet]
        public List<Model.Predmeti> todayPredmeti([FromQuery]PredmetiSearchRequest request)
        {
          
            return _predmetiService.GetTodayPredmeti(request);
        }


        [Route("GetAdvokatiPreporuka/{id}")]
        [HttpGet]
        public List<Database.Korisnici> GetAdvokatiPreporuka(int id)
        {
            
            return _predmetiService.GetAdvokatiPreporuka(id);

           
        }


        //[HttpGet]
        //public List<Model.Predmeti> Get2([FromQuery]PredmetiSearchRequest request)
        //{
        //    //List<Model.Predmeti> lista = new List<Model.Predmeti>();

        //    //lista = _predmetiService.Get(request);
        //    //foreach (var p in lista)
        //    //{
        //    // dohvatiti troskove po p.predmetId
        //    //provjeriti ako je broj transakcija 0 i datum istekao salji mail
        //    //ako broj transakcija veci od  0 i zbir transakcija manji od ukupnog troska, i datum prosao salji mail

        //    //    if (p.UkupniTrosak == 0)
        //    //    {
        //    //        int result = DateTime.Compare((DateTime)p.RokUplate, DateTime.Now);
        //    //        if (result < 0)
        //    //        {
        //    //            //send email
        //    //        }

        //    //    }
        //    //}



        //    return _predmetiService.Get(request);
        //}


    }
}