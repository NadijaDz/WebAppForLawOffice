using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
  public  class KategorijeDokumenataInsertRequest
    {

        public string Naziv { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
