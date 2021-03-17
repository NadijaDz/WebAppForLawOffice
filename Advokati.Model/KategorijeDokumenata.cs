using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model
{
   public class KategorijeDokumenata
    {
        public int KategorijaDokumentaId { get; set; }
        public string Naziv { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
