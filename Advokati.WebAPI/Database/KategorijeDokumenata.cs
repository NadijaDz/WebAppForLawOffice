using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class KategorijeDokumenata
    {
        [Key]
        public int KategorijaDokumentaId { get; set; }
        public string Naziv { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
