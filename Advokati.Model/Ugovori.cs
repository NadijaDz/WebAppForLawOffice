using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Ugovori
    {
        public int UgovorId { get; set; }
        public string Naslov { get; set; }
        public DateTime DatumPotpisivanja { get; set; }
        public DateTime? DatumRaskida { get; set; }
        public string Napomena { get; set; }
        public bool? Zavrsen { get; set; }

        public int ZaposleniciId { get; set; }
        public string Zaposlenik { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
