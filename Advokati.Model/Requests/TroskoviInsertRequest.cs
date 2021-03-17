using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
   public class TroskoviInsertRequest
    {
        
        public string Sifra { get; set; }
        public string Opis { get; set; }
        public decimal Iznos { get; set; }
       
        public DateTime? DatumUplate { get; set; }
        public int PredmetID { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
