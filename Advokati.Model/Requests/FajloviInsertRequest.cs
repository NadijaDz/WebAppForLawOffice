using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Advokati.Model.Requests
{
    public class FajloviInsertRequest
    {
        [Required]
        public string Naziv { get; set; }
        public string Url { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public string Ekstenzija { get; set; }
        public int PredmetID { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
