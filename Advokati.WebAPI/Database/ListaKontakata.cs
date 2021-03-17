using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class ListaKontakata
    {
        [Key]
        public int KontaktId { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
   
        public string Telefon { get; set; }

        public string Email { get; set; }

        public string Adresa { get; set; }

        public string Grad { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
