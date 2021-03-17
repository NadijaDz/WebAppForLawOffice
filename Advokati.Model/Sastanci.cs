using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Sastanci
    {
        public int SastanakId { get; set; }

        public DateTime DatumSastanka { get; set; }
        public string MjestoOdrzavanja { get; set; }
        public string Poruka { get; set; }
        public bool? Odrzan { get; set; }
        public bool? Odobreno { get; set; }

        public int ZaposleniciId { get; set; }
        public string Zaposlenik { get; set; }

        public int KlijentId { get; set; }
        public string Klijent { get; set; }
        public bool? IsDeleted { get; set; }
        public string VrstaPredmeta { get; set; }
        public int VrstaId { get; set; }
    }
}
