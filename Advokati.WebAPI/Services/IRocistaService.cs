using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
  public  interface IRocistaService
    {
        List<Model.Rocista> Get(RocistaSearchRequest request);
        Model.Rocista GetById(int id);

        Model.Rocista Insert(RocistaInsertRequest request);
        Model.Rocista Update(int id,RocistaInsertRequest request);

        Model.Rocista Delete(int id, RocistaInsertRequest request);

     

        List<Model.Rocista> GetAllRocistaById(int id);

        List<Model.Rocista> GetTodayRocista(RocistaSearchRequest request);

    }
}
