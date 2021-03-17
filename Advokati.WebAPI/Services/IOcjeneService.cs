using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IOcjeneService
    {
        List<Model.Ocjene> Get(OcjeneSearchRequest request);
        Model.Ocjene GetById(int id);

        Model.Ocjene Insert(OcjeneInsertRequest request);
        Model.Ocjene Update(int id, OcjeneInsertRequest request);
        Model.Ocjene Delete(int id, OcjeneInsertRequest request);
    }
}
