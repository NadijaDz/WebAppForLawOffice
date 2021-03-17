using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
   public class TroskoviSearchRequest
    {
        public string Sifra { get; set; }

        public DateTime DatumOD { get; set; }
        public DateTime DatumDO { get; set; }


       
        public int PredmetID { get; set; }
        public string BrojPredmeta { get; set; }

        public DateTime DatumUplate { get; set; }

        public string file { get; set; }



    }
}
