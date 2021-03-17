using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class ZapisnikRocista
    {
        [Key]
        public int ZapisnikRocistaId { get; set; }
        public string Naziv { get; set; }

        public string Url { get; set; }

        public string Opis { get; set; }
        public string Ekstenzija { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey("RocisteID")]
        public Rocista Rocista { get; set; }
        public int RocisteID { get; set; }
    }
}
