using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
  public class UgovoriInsertRequest
    {

       
        public string Naslov { get; set; }
        public DateTime DatumPotpisivanja { get; set; }
        public DateTime? DatumRaskida { get; set; }
        public string Napomena { get; set; }
        public bool? Zavrsen { get; set; }

        public int ZaposleniciId { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
