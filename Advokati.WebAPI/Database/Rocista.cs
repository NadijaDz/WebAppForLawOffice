using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Rocista
    {
        [Key]
        public int RocisteId { get; set; }
        public DateTime DatumRocista { get; set; }
        public string Mjesto { get; set; }

        public bool Odrzano { get; set; }

        public string Napomena { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey("PredmetID")]
        public Predmeti Predmeti { get; set; }
        public int PredmetID { get; set; }

        [ForeignKey("ZaposlenikId")]
        public Korisnici Zaposlenici { get; set; }
        public int ZaposlenikId { get; set; }
    }
}
