using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class RadniSati
    {
        [Key]
        public int RadniSatiId { get; set; }

        public decimal BrojRadnihSati { get; set; }
        public decimal PrekovremeniSati { get; set; }

        public decimal CijenaPoSatu { get; set; }
        public decimal CijenaPrekovremenogSata{ get; set; } 
        public string Opis { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey("ZaposleniciId")]
        public Korisnici Zaposlenici { get; set; }
        public int ZaposleniciId { get; set; }


        [ForeignKey("PredmetId")]
        public Predmeti Predmeti { get; set; }
        public int? PredmetId { get; set; }
    }
}
