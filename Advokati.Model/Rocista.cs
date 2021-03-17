using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Rocista
    {
        public int RocisteId { get; set; }
        public DateTime DatumRocista { get; set; }
        public string Mjesto { get; set; }

        public bool Odrzano { get; set; }

        public string Napomena { get; set; }

        public int PredmetID { get; set; }
        public string BrojPredmeta { get; set; }

        public int ZaposlenikId { get; set; }
        public string Zaposlenik { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
