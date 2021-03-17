using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Kontaktlista
    {
        public int KontaktId { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }

        public string Adresa { get; set; }

        public string Grad { get; set; }

        public bool? IsDeleted { get; set; }



    }
}
