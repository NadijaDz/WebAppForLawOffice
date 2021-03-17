using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Advokati.WebAPI.Database;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json;

namespace NotificationServiceV1
{
    public partial class NotificationService : ServiceBase
    {
     
        private readonly ISastanciService _sastanciService;
        private readonly IPredmetiService _predmetiService;
        private readonly ITroskoviService _troskoviService;

        private const string URL = "http://localhost:12345/api/";
        private string urlParameters = "?api_key=123";

        private readonly Timer timer1;
        public NotificationService()
        {
           
            //  InitializeComponent();
            ServiceLog.WriteErrorLog("init");                                                         // Here you can write the   
            //timer1 = new System.Timers.Timer();
            timer1 = new Timer(1000 * 60 * 1000) { AutoReset = true };
            timer1.Elapsed += tmrExecutor_Elapsed;
            return;
        }

        protected override void OnStart(string[] args)
        {
            // timer1.AutoReset = true;
            //timer1.Enabled = true;
            // timer1.Elapsed += new ElapsedEventHandler(tmrExecutor_Elapsed); // adding Event
            // timer1.Interval = 60000; // Set your time here 
            // timer1.Enabled = true;
           // System.Diagnostics.Debugger.Launch();
            timer1.Start();
            ServiceLog.WriteErrorLog("Daily Reporting service started");

        }

        protected override void OnStop()
        {
            //timer1.AutoReset = false;
            // timer1.Enabled = false;
            timer1.Stop();
            ServiceLog.WriteErrorLog("Daily Reporting service stopped");
        }
        private void tmrExecutor_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ServiceLog.WriteErrorLog("sadsfasfasf");
            //Do your Sending email work here
            try
            {
                ServiceLog.WriteErrorLog("doslo");
                var predmeti = new List<Advokati.Model.Predmeti>();
                var troskovi = new List<Advokati.Model.Troskovi>();

                PredmetiSearchRequest request = new PredmetiSearchRequest();
                TroskoviSearchRequest request2 = new TroskoviSearchRequest();
                ServiceLog.WriteErrorLog("doslo 11");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync("predmeti").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                   // var responseAsString =  response.Content.ReadAsAsync();
                   // ServiceLog.WriteErrorLog(responseAsString.ToString());

                    //Advokati.Model.Predmeti responseAsConcreteType = JsonConvert.DeserializeObject<Advokati.Model.Predmeti>(responseAsString);
                     predmeti = response.Content.ReadAsAsync<List<Advokati.Model.Predmeti>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    //ServiceLog.WriteErrorLog("response");
                    //ServiceLog.WriteErrorLog(predmeti.Count.ToString());
                    //foreach (var d in predmeti)
                    //{
                    //    ServiceLog.WriteErrorLog("d");
                    //    ServiceLog.WriteErrorLog(d.ToString());

                    //}
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                HttpResponseMessage response1 = client.GetAsync("troskovi").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response1.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    // var responseAsString =  response.Content.ReadAsAsync();
                    // ServiceLog.WriteErrorLog(responseAsString.ToString());

                    //Advokati.Model.Predmeti responseAsConcreteType = JsonConvert.DeserializeObject<Advokati.Model.Predmeti>(responseAsString);
                    troskovi = response1.Content.ReadAsAsync<List<Advokati.Model.Troskovi>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    //ServiceLog.WriteErrorLog("Troskovi");
                    //ServiceLog.WriteErrorLog(troskovi.Count.ToString());
                    //foreach (var d in troskovi)
                    //{
                    //    ServiceLog.WriteErrorLog("tr");
                    //    ServiceLog.WriteErrorLog(d.ToString());

                    //}
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                //Advokati.WebAPI.Services.PredmetiService.
                //var predmeti = _predmetiService.Get(request);
                //ServiceLog.WriteErrorLog("doslo1");
                //ar troskovi = _troskoviService.Get(request2);




                List<Advokati.Model.Predmeti> listPredmetaSaNulaTransakcija = new List<Advokati.Model.Predmeti>();
                ServiceLog.WriteErrorLog("doslo2");

                decimal countTransakcije = 0;
                bool transakcijeVeceODNula = false;

                foreach (var p in predmeti)
                {
                    countTransakcije = 0;
                    transakcijeVeceODNula = false;
                    foreach (var t in troskovi)
                    {
                        
                        if (p.PredmetId == t.PredmetID && t.Iznos == 0 && p.RokUplate < DateTime.Now)
                        {
                            ServiceLog.WriteErrorLog("prvi if");

                            listPredmetaSaNulaTransakcija.Add(p);
                            ServiceLog.SendEmail(p);

                        }
                        if (p.PredmetId == t.PredmetID)
                        {
                            countTransakcije += t.Iznos;
                        }
                        if (p.PredmetId == t.PredmetID && t.Iznos > 0 && p.RokUplate < DateTime.Now)
                        {
                            transakcijeVeceODNula = true;
                        }
                    }

                    if (countTransakcije < p.UkupniTrosak && transakcijeVeceODNula)
                    {
                        ServiceLog.WriteErrorLog("drugi if");

                        ServiceLog.SendEmail(p);

                    }
                }

            }
            catch (Exception exc)
            {
                ServiceLog.WriteErrorLog(exc);
                //  Block of code to handle errors
            }
          


         





            // SastanciSearchRequest request = new SastanciSearchRequest();
            //List<Advokati.Model.Sastanci> sastanci = _sastanciService.Get(request);
            //ovdje sad treba izvrtiti sastanke ili bilo sta i zavisnosti od datuma slati mailove 

        }
    }
}
