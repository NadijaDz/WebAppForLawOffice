using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IKlijentiService
    {
        List<Model.Korisnici> Get(KorisniciSearchRequest request);
        Model.Korisnici GetById(int id);

        Model.Korisnici Insert(KorisniciInsertRequest request);
        Model.Korisnici Update(int id, KorisniciInsertRequest request);
        Model.Korisnici Delete(int id, KorisniciInsertRequest request);

    }
}
