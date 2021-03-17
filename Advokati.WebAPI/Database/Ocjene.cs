using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Ocjene
    {

        [Key]

        public int OcjenaId { get; set; }
        public string Ocjena { get; set; }
        public string Komentar { get; set; }


        public bool? IsDeleted { get; set; }

        [ForeignKey("ZaposleniciId")]
        public Korisnici Zaposlenici { get; set; }
        public int ZaposleniciId { get; set; }


        [ForeignKey("KlijentId")]
        public Korisnici Klijent { get; set; }
        public int KlijentId { get; set; }
    }
}
