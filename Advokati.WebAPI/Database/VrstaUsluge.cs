using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class VrstaUsluge
    {
        [Key]
        public int VrstaUslugeId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
