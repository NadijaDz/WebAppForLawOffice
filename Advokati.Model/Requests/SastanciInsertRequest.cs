using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
   public class SastanciInsertRequest
    {
        

        public DateTime DatumSastanka { get; set; }
        public string MjestoOdrzavanja { get; set; }
        public string Poruka { get; set; }
        public bool? Odrzan { get; set; }
        public int ZaposleniciId { get; set; }

        public bool? Odobreno { get; set; }
        public int KlijentId { get; set; }
        public int VrstaId { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
