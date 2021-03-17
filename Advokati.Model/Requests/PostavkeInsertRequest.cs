using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
    public class PostavkeInsertRequest
    {
       
        public string Naziv { get; set; }
        public bool Prikazi { get; set; }
        public int KorisnikId { get; set; }
  
    }
}
