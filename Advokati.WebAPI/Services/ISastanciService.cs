using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
  public interface ISastanciService
    {
        List<Model.Sastanci> Get(SastanciSearchRequest request);
        Model.Sastanci GetById(int id);

        Model.Sastanci Insert(SastanciInsertRequest request);
        Model.Sastanci Update(int id, SastanciInsertRequest request);
        Model.Sastanci Delete(int id, SastanciInsertRequest request);

        List<Database.Korisnici> GetAdvokatiPreporuka(int vrstaUslugeId);


        List<Model.Sastanci> GetAllSastanciById(int id);

        List<Model.Sastanci> GetTodaySastanci(SastanciSearchRequest request);

        Model.Sastanci ZakaziSastanak(SastanciInsertRequest request);

        

    }
}
