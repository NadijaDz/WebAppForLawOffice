using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface ITroskoviService
    {
        List<Model.Troskovi> Get(TroskoviSearchRequest request);
        Model.Troskovi GetById(int id);
        Model.Troskovi Insert(TroskoviInsertRequest request);
        Model.Troskovi Update(int id, TroskoviInsertRequest request);
        Model.Troskovi Delete(int id, TroskoviInsertRequest request);

        List<Model.Troskovi> GetAllForReport(string request1, string request2);

        List<Model.Troskovi> GetAllTroskoviByPredmetId(int id);

        List<Model.Troskovi> GetAllTroskoviByDatum(TroskoviSearchRequest request);

        List<Model.Troskovi> GetAllTroskoviById(int id);

    }
}
