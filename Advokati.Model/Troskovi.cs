using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
  public  class Troskovi
    {
        public int TrosakId { get; set; }
        public string Sifra { get; set; }
        public string Opis { get; set; }
        public decimal Iznos { get; set; }
       
        public DateTime? DatumUplate { get; set; }
        public int PredmetID { get; set; }
        public string BrojPredmeta { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
