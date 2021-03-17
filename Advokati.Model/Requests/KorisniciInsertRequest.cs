using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Advokati.Model.Requests
{
    public class KorisniciInsertRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public string JMBG { get; set; }
        [Required]

        public string Grad { get; set; }
        [Required]

        public string Telefon { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Adresa { get; set; }
        [Required]

        public string Spol { get; set; }
        [Required]

        public string RadniStaz { get; set; }
        [Required]

        public bool? Status { get; set; }
        [Required]

        public string KorisnickoIme { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string PasswordConfirmation { get; set; }
        [Required]

        public int UlogeId { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
