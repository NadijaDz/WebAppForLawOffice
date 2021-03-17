using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Advokati.Model.Requests
{
    public class OcjeneInsertRequest
    {

        [Required]
        public string Ocjena { get; set; }

        [Required]
        public string Komentar { get; set; }
      
 

        public int ZaposleniciId { get; set; }

 
        public int KlijentId { get; set; }
     
       
        public bool? IsDeleted { get; set; }
    }
}
