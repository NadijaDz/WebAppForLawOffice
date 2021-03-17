using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Ugovori
    {
        [Key]
        public int UgovorId { get; set; }
        public string Naslov { get; set; }
        public DateTime DatumPotpisivanja { get; set; }
        public DateTime? DatumRaskida { get; set; }
        public string Napomena { get; set; }
        public bool? Zavrsen { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey("ZaposleniciId")]
        public Korisnici Zaposlenici { get; set; }
        public int ZaposleniciId { get; set; }


    }
}
