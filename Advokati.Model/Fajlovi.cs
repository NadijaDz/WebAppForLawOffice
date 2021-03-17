using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Fajlovi
    {

        public int FajlPredmetaId { get; set; }
        public string Naziv { get; set; }
        public string Url { get; set; }
        public string Opis { get; set; }
        public string Ekstenzija { get; set; }
        public int PredmetID { get; set; }
        public string BrojPredmeta { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
