using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class Dokumenti
    {

   
        public int DokumentId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Ekstenzija { get; set; }
        public string Url { get; set; }
        public int KategorijaDokumentaId { get; set; }

        public string KategorijaDokumenta { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
