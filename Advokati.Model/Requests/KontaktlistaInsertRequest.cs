using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Advokati.Model.Requests
{
   public class KontaktlistaInsertRequest
    {


        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        
     
        [Required]

        public string Grad { get; set; }
        [Required]

        public string Telefon { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Adresa { get; set; }
      

       
 

        public bool? IsDeleted { get; set; }

    }
}
