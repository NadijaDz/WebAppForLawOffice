using Advokati.Model.Requests;
using Advokati.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IZaposleniciService
    {
        List<Model.Korisnici> Get(KorisniciSearchRequest request);
        Model.Korisnici GetById(int id);

        Model.Korisnici Update(int id, KorisniciInsertRequest request);
      

        Model.Korisnici Insert(KorisniciInsertRequest request);
        Model.Korisnici Authenticiraj(string username,string pass);
        Model.Korisnici Delete(int id, KorisniciInsertRequest request);

        bool provjeriOldPass(int id,string request);


    }
}
