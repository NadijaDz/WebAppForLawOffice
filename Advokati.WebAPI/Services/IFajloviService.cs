using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IFajloviService
    {

        List<Model.Fajlovi> Get(FajloviSearchRequest request);
        Model.Fajlovi GetById(int id);

        Model.Fajlovi Insert(FajloviInsertRequest request);
        Model.Fajlovi Update(int id, FajloviInsertRequest request);
        Model.Fajlovi Delete(int id, FajloviInsertRequest request);

    }
}
