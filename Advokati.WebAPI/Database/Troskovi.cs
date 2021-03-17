using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Troskovi
    {
        [Key]
        public int TrosakId { get; set; }
        public string Sifra { get; set; }
        public string Opis { get; set; }
        public decimal Iznos { get; set; }
       
        public DateTime? DatumUplate { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey("PredmetID")]
        public Predmeti Predmeti { get; set; }
        public int PredmetID { get; set; }
    }
}
