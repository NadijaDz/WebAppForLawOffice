using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Postavke
    {

        [Key]
        public int PostavkeId { get; set; }
        public string Naziv { get; set; }
        public bool Prikazi { get; set; }


        [ForeignKey("KorisnikId")]
        public Korisnici Korisnici { get; set; }
        public int KorisnikId { get; set; }
    }
}
