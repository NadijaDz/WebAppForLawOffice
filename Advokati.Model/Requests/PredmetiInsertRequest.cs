using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Advokati.Model.Requests
{
   public class PredmetiInsertRequest
    {
      
        [Required]
        public string BrojPredmeta { get; set; }
        [Required]

        public string NazivPredmeta { get; set; }
        [Required]

        public DateTime DatumPocetka { get; set; }
      

        public DateTime? RokUplate { get; set; }

        public decimal? UkupniTrosak { get; set; }

        [Required]

        public int ZaposleniciId { get; set; }

        [Required]

        public int KlijentId { get; set; }
        [Required]

        public int StatusId { get; set; }
        [Required]

        public int VrstaId { get; set; }

        public int FajloviPredmetaId { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
