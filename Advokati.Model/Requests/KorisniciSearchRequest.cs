using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
    public class KorisniciSearchRequest
    {
        public string ImePrezime { get; set; }
        public string KorisnickoIme { get; set; }
         public string Korisnik { get; set; }

        public string Email { get; set; }
        public List<string> uloge { get; set; }

        private bool _status = true;

        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string username { get; set; }
        public string password { get; set; }


    }
}
