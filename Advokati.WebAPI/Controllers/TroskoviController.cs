using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Advokati.Model.Requests;
using Advokati.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advokati.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TroskoviController : ControllerBase
    {
        private readonly ITroskoviService _troskoviService;

        public TroskoviController(ITroskoviService troskoviService)
        {
            _troskoviService = troskoviService;
        }

        [HttpGet]
        public List<Model.Troskovi> Get([FromQuery]TroskoviSearchRequest request)
        {
            return _troskoviService.Get(request);
        }


        [HttpGet("{id}")]
        public Model.Troskovi GetById(int id)
        {
            return _troskoviService.GetById(id);
        }

        //[Authorize(Roles = "Sekretar")]
        [HttpPost]
        public Model.Troskovi Insert(TroskoviInsertRequest request)
        {
            return _troskoviService.Insert(request);
        }

        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Troskovi Update(int id, TroskoviInsertRequest request)
        {
            return _troskoviService.Update(id, request);
        }

        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Troskovi Delete(int id, TroskoviInsertRequest request)
        {
            return _troskoviService.Delete(id, request);
        }


        [Route("trosakOdDo/{request1}/{request2}")]
        [HttpGet]
        public List<Model.Troskovi> GetAllForReport(string request1, string request2)
        {
            return _troskoviService.GetAllForReport(request1, request2);
           
        }


        [Route("GetAllTroskoviByPredmetId/{id}")]
        [HttpGet]
        public List<Model.Troskovi> GetAllTroskoviByPredmetId(int id)
        {
            return _troskoviService.GetAllTroskoviByPredmetId(id);
        }


        [Route("GetAllTroskoviByDatum")]
        [HttpPost]
        public List<Model.Troskovi> GetAllTroskoviByDatum(TroskoviSearchRequest request)
        {
            return _troskoviService.GetAllTroskoviByDatum(request);
        }

      


        [Route("uploadFileAndSendEmail")]
        [HttpPost]
        public async Task<IActionResult> uploadFileAndSendEmail(TroskoviSearchRequest file)
        {
             byte[] data = System.Convert.FromBase64String(file.file);
            file.file = System.Text.ASCIIEncoding.ASCII.GetString(data);

            



            string subject = "Registracija";
                string body = file.file;
                //string FromMail = "testRS1test123@gmail.com";
                string FromMail = "nadija.dziho@edu.fit.ba";


                string temp = "busatlic.kadir@gmail.com";

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
                SmtpServer.Send(mail);

            

            return Ok();
        }



        [Route("uploadFileAndSendEmail1/{id}")]
        [HttpPost]
        public async Task<IActionResult> uploadFileAndSendEmail1(string email,IFormFile file)
        {


            string subject = "Račun";
            string body = "Račun";
            //string FromMail = "testRS1test123@gmail.com";
            string FromMail = "nadija.dziho@edu.fit.ba";


            //string temp = "busatlic.kadir@gmail.com";

            string emailTo = email;

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



        [Route("sendInvoiceOnEmail/{email}")]
        [HttpPost]
        public async Task<IActionResult> sendInvoiceOnEmail(string email, IFormFile file)
        {

            
            string subject = "Račun";
            string body = "Račun";
            //string FromMail = "testRS1test123@gmail.com";
            string FromMail = "nadija.dziho@edu.fit.ba";


            //string temp = "nadija.dziho@edu.fit.ba";

            string emailTo = email;



            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            string[] words = email.Split(',');

            foreach (var word in words)
            {
                mail.To.Add(word);
        
            }



            mail.From = new MailAddress(FromMail);
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




        [Route("GetAllTroskoviById/{id}")]
        [HttpGet]
        public List<Model.Troskovi> GetAllTroskoviById(int id)
        {
            return _troskoviService.GetAllTroskoviById(id);
        }





    }
}