using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Database
{
    public class Korisnici
    {
        [Key]
        public int KorisnikId { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }


        public string Grad { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Spol { get; set; }

        public string RadniStaz { get; set; }

        public bool? Status { get; set; }
        public string KorisnickoIme { get; set; }

        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey("UlogeId")]
        public Uloge Uloge { get; set; }
        public int UlogeId { get; set; }

    }
}
