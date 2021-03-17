using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
    public class RadniSati
    {
        public int RadniSatiId { get; set; }

        public decimal BrojRadnihSati { get; set; }
        public decimal PrekovremeniSati { get; set; }

        public decimal CijenaPoSatu { get; set; }
        public decimal CijenaPrekovremenogSata { get; set; }
        public string Opis { get; set; }

        public int ZaposleniciId { get; set; }
        public string Zaposlenik { get; set; }

        public int? PredmetId { get; set; }
        public string BrojPredmeta { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
