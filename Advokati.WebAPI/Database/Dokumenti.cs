using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Dokumenti
    {
        [Key]
        public int DokumentId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Ekstenzija { get; set; }
        public string Url { get; set; }


        [ForeignKey("KategorijaDokumentaId")]
        public KategorijeDokumenata KategorijaDokumenta { get; set; }
        public int KategorijaDokumentaId { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
