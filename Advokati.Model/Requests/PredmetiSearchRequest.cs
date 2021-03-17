using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
   public class PredmetiSearchRequest
    {
        public string BrojPredmeta { get; set; }
        public int KlijentId { get; set; }

        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
    }
}
