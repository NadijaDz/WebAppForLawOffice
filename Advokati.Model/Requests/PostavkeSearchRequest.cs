using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
    public class PostavkeSearchRequest
    {
        public string Naziv { get; set; }

        public int KorisnikId { get; set; }
    }
}
