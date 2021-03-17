using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Postavke
    {
        public int PostavkeId { get; set; }
        public string Naziv { get; set; }
        public bool Prikazi { get; set; }

        public int KorisnikId { get; set; }
        public string Korisnik { get; set; }
    }
}
