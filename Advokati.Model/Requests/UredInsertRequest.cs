using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
    public class UredInsertRequest
    {

        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Grad { get; set; }
        public string PostanskiBroj { get; set; }
        public int ZiroRacun { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
