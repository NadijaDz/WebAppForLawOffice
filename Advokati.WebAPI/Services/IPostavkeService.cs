using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IPostavkeService
    {
        List<Model.Postavke> Get(PostavkeSearchRequest request);
        Model.Postavke GetById(int id);

        Model.Postavke Insert(PostavkeInsertRequest request);
        Model.Postavke Update(int id, PostavkeInsertRequest request);

        List<Model.Postavke> GetByKorisnikId(int id);

    }
}
