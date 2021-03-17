using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Zadaci
    {
        public int ZadatakId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime Rok { get; set; }

        public bool? Zavrsen { get; set; }
        public int ZaposleniciId { get; set; }
        public string Zaposlenik { get; set; }

        public bool? IsDeleted { get; set; }
       
    }
}
