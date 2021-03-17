using System;
using System.Collections.Generic;
using System.Text;

namespace Advokati.Model.Requests
{
   public class SastanciSearchRequest
    {
        public DateTime DatumSastanka { get; set; }

        private bool _odobreno = true;

        public bool Odobreno
        {
            get { return _odobreno; }
            set { _odobreno = value; }
        }

       

    }
}
