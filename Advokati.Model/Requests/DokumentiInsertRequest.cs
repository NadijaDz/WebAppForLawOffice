using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.IO;

namespace Advokati.Model.Requests
{
   public class DokumentiInsertRequest
    {




        [Required]

        public string Naziv { get; set; }

        [Required]

        public string Opis { get; set; }

        public string Ekstenzija { get; set; }

        public string Url { get; set; }


        [Required]

        public int KategorijaDokumentaId { get; set; }

        public bool? IsDeleted { get; set; }



     




    }
}
