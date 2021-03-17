using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace NotificationService
{
    public partial class NotificationService : ServiceBase
    {
       

        private readonly Timer timer1;
        public NotificationService()
        {
            InitializeComponent();
            InitializeComponent();
            ServiceLog.WriteErrorLog("init");                                                         // Here you can write the   
            //timer1 = new System.Timers.Timer();
            timer1 = new Timer(1 * 60 * 1000) { AutoReset = true };
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
            ServiceLog.WriteErrorLog("doslo");                                                         // Here you can write the   
            ServiceLog.SendEmail("nadija.dziho@edu.fit.ba", "Daily Report of DailyMailSchedulerService on " + DateTime.Now.ToString("dd-MMM-yyyy"), "jj");

        }
    }
}
