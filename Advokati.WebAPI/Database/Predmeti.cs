using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Predmeti
    {
        [Key]
        public int PredmetId { get; set; }
        public string BrojPredmeta { get; set; }
        public string NazivPredmeta { get; set; }
       
        public DateTime DatumPocetka { get; set; }
        public DateTime? RokUplate { get; set; }

        public decimal? UkupniTrosak { get; set; }

        public bool? IsDeleted { get; set; }


        [ForeignKey("ZaposleniciId")]
        public Korisnici Zaposlenici { get; set; }
        public int ZaposleniciId { get; set; }


        [ForeignKey("KlijentId")]
        public Korisnici Klijent { get; set; }
        public int KlijentId { get; set; }


        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int StatusId { get; set; }


        [ForeignKey("VrstaId")]
        public VrstaUsluge VrstaUsluge { get; set; }
        public int VrstaId { get; set; }


     

    }
}
