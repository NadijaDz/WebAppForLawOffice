using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
    public class ZapisnikRocista
    {
       
        public int ZapisnikRocistaId { get; set; }
        public string Naziv { get; set; }

        public string Url { get; set; }

        public string Opis { get; set; }
        public string Ekstenzija { get; set; }

        public bool? IsDeleted { get; set; }

    
        public int RocisteID { get; set; }

        public string Mjesto { get; set; }


    }
}
