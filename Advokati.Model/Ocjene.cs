using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Advokati.Model
{
   public class Ocjene
    {

        public int OcjenaId { get; set; }
        public string Ocjena { get; set; }
        public string Komentar { get; set; }


        public bool? IsDeleted { get; set; }

        public int ZaposleniciId { get; set; }
        public string Zaposlenik { get; set; }

        public int KlijentId { get; set; }
        public string Klijent { get; set; }

    }
}
