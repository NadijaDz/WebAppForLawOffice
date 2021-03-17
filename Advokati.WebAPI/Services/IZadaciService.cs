using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IZadaciService
    {
        List<Model.Zadaci> Get(ZadaciSearchRequest request);
        Model.Zadaci GetById(int id);

        Model.Zadaci Insert(ZadaciInsertRequest request);
        Model.Zadaci Update(int id, ZadaciInsertRequest request);

        Model.Zadaci Delete(int id, ZadaciInsertRequest request);


        List<Model.Zadaci> GetAllZadaciById(int id);

        List<Model.Zadaci> GetTodayZadaci(ZadaciSearchRequest request);

    }
}
