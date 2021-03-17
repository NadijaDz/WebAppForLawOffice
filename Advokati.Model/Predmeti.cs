using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Predmeti
    {
        public int PredmetId { get; set; }
        public string BrojPredmeta { get; set; }
        public string NazivPredmeta { get; set; }

        public DateTime DatumPocetka { get; set; }
        public DateTime? RokUplate { get; set; }

        public decimal? UkupniTrosak { get; set; }

        public int ZaposleniciId { get; set; }
        public string Zaposlenik { get; set; }

        public int KlijentId { get; set; }
        public string Klijent { get; set; }

        public int StatusId { get; set; }
        public string Status { get; set; }


        public int VrstaId { get; set; }
        public string VrstaUsluge { get; set; }

        public int FajloviPredmetaId { get; set; }
        public string FajloviPredmeta { get; set; }
        public bool? IsDeleted { get; set; }

        public decimal Ukupno { get; set; }
        public string Email { get; set; }


    }
}
