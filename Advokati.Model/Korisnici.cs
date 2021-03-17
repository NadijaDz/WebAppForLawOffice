using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Korisnici
    {
      
        public int KorisnikId { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }


        public string Grad { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Spol { get; set; }

        public string RadniStaz { get; set; }

        public bool? Status { get; set; }
        public string KorisnickoIme { get; set; }

        public int UlogeId { get; set; }
        public string NazivUloge { get; set; }

        public bool? IsDeleted { get; set; }

        public string ImePrezime
        {
            get
            {
                return Ime + "  " + Prezime;
            }
        }
        public ICollection<Uloge> KorisniciUloge { get; set; }

        public string LozinkaSalt { get; set; }
        public string LozinkaHash { get; set; }

    }
}
