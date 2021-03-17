using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IUgovoriService
    {
        List<Model.Ugovori> Get(UgovoriSearchRequest request);
        Model.Ugovori GetById(int id);
        Model.Ugovori Insert(UgovoriInsertRequest request);
        Model.Ugovori Update(int id, UgovoriInsertRequest request);
        Model.Ugovori Delete(int id, UgovoriInsertRequest request);
    }
}
