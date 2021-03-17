using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Zadaci
    {

        [Key]
        public int ZadatakId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime Rok { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? Zavrsen { get; set; }

        [ForeignKey("ZaposleniciId")]
        public Korisnici Zaposlenici { get; set; }
        public int ZaposleniciId { get; set; }
    }
}
