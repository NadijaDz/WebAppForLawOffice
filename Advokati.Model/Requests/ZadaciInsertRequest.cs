using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
   public class ZadaciInsertRequest
    {

        
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime Rok { get; set; }

        public bool? Zavrsen { get; set; }

        public int ZaposleniciId { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
