using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IUredService
    {
        List<Model.Ured> Get(UredSearchRequest request);
        Model.Ured GetById(int id);

        Model.Ured Insert(UredInsertRequest request);
        Model.Ured Update(int id, UredInsertRequest request);
        Model.Ured Delete(int id, UredInsertRequest request);
    }
}
