using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Advokati.Model;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MimeKit;

namespace Advokati.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {


        [Route("mail")]
        [HttpGet]
        public async Task<List<Mail>> GetAsync()
        {
            var messages = new List<MimeMessage>();

            using (var client = new ImapClient())
            {
                //accept all certs
                //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync("smtp.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                //client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.AuthenticateAsync("testRS1test123@gmail.com", "Rstest123456");

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadWrite);
                // get only unread
                var results = await inbox.SearchAsync(SearchOptions.All, SearchQuery.All).ConfigureAwait(false);
                foreach (var uniqueId in results.UniqueIds)
                {
                    var message = await inbox.GetMessageAsync(uniqueId).ConfigureAwait(false);

                    messages.Add(message);

                    // Mark message as read
                    inbox.AddFlags(uniqueId, MessageFlags.Seen, true);
                }

                await client.DisconnectAsync(true);
            }

            var newMails = new List<Mail>();
            if (messages.Count > 0)
            {
                foreach (var m in messages)
                {

                    var body = m.HtmlBody ?? m.TextBody;
                    body = body.Trim().Trim('\r', '\n'); // to clean it a bit
                    var newMail = new Mail
                    {
                        From = m.From.Mailboxes.First()?.Address,
                        HtmlBody = body,

                        Subject = m.Subject,

                        To = m.To.Mailboxes.First()?.Address,
                        Date = m.Date.UtcDateTime
                    };
                    newMails.Add(newMail);
                }
            }


            return newMails;
        }


        public class MailReply
        {

            public string Message { get; set; }
 

            public string From { get; set; }
            public string HtmlBody { get; set; }
            public string Subject { get; set; }
            public string To { get; set; }

            public DateTime Date { get; set; }



        }


        //[Route("replyOnMail")]
        //[HttpPost]
        //public async Task<IActionResult> replyOnMail(MailReply email)
        //{

        //    string subject = email.Subject;
        //    string body = email.Message;
        //    string FromMail = email.From;

        //    string emailTo = email.To;

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


        //    return Ok();
        //}







        [Route("replyOnMail")]
        [HttpPost]
        public async Task<IActionResult> replyOnMail(MailReply email)
        {

             MimeMessage message=new MimeMessage();

            // Retrieve searched email.
            MailMessage originalMessage;
            using (ImapClient imap = new ImapClient())
            {
                imap.Connect("smtp.gmail.com", 993, true);
                imap.Authenticate("testRS1test123@gmail.com", "Rstest123456");

                //imap.SelectInbox();


                var inbox = imap.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadWrite);


                //string search = @"SUBJECT ""Subj za test""";

                //originalMessage = imap.GetMessage(imap.SearchMessageNumbers(search).First());

                var results = await inbox.SearchAsync(SearchOptions.All, SearchQuery.SubjectContains(email.Subject)).ConfigureAwait(false);

                foreach (var uniqueId in results.UniqueIds)
                {
                    message = inbox.GetMessage(uniqueId);
                    
                  

                }



                //Create reply email with sender and receiver addresses swapped.
                //InternetAddressList temp = message.To;

                MailMessage replyMessage = new MailMessage();
                replyMessage.From = new MailAddress(message.From.ToString());
                replyMessage.To.Add(email.From.ToString());

           



                //if (!string.IsNullOrEmpty(message.MessageId))
                //{
                //    replyMessage.ReplyTo= message.MessageId;
                //    foreach (var id in message.References)
                //        replyMessage.References.Add(id);
                //    replyMessage.References.Add(message.MessageId);
                //}



                replyMessage.Headers.Add("Message-Id", message.MessageId);


                // Add 'In-Reply-To' and 'References' header.
                //replyMessage.Headers.Add(
                //new Header(HeaderId.InReplyTo, message.MessageId));
                //replyMessage.Headers.Add(
                //    new Header(HeaderId.References, message.MessageId));


                // Set subject.
             
                replyMessage.Subject = $"Re: { message.Subject }";


                // Set reply message message.
                replyMessage.Body = email.Message;

                // Append original message text.
                replyMessage.Body +=
                   $"<div>On {message.Date.LocalDateTime}, {message.From} </div>" +
                   $"<blockquote>{message.TextBody}</blockquote>";


                replyMessage.IsBodyHtml = true;




                // Send reply email.
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
            {

                //smtp.Connect();
                //smtp.Authenticate("<USERNAME>", "<PASSWORD>");
                //smtp.SendMessage(replyMessage);

                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("testRS1test123@gmail.com", "Rstest123456");
                smtp.EnableSsl = true;
                smtp.Send(replyMessage);
            }
            }





            return Ok();
        }




    }
}