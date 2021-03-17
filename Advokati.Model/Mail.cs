using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Mail
    {

        public string From { get; set; }
        public string HtmlBody { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }

        public DateTime Date { get; set; }


    }
}
