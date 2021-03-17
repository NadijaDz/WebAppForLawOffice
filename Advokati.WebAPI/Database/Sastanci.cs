using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Sastanci
    {
        [Key]
        public int SastanakId { get; set; }

        public DateTime DatumSastanka { get; set; }
        public string MjestoOdrzavanja { get; set; }
        public string Poruka { get; set; }
        public bool? Odrzan { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? Odobreno { get; set; }

        [ForeignKey("ZaposleniciId")]
        public Korisnici Zaposlenici { get; set; }
        public int ZaposleniciId { get; set; }


        [ForeignKey("KlijentId")]
        public Korisnici Klijent { get; set; }
        public int KlijentId { get; set; }


        [ForeignKey("VrstaId")]
        public VrstaUsluge VrstaUsluge { get; set; }
        public int? VrstaId { get; set; }

    }
}
