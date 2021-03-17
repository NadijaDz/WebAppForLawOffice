using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
    public class KontaktlistaSearchRequest
    {
         public string ImePrezime { get; set; }
       
         public string Korisnik { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }

        public string Grad { get; set; }




    }
}
