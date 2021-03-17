using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IPredmetiService
    {
        List<Model.Predmeti> Get(PredmetiSearchRequest request);
        List<Model.Predmeti> Get2(PredmetiSearchRequest request);

        Model.Predmeti GetById(int id);
        Model.Predmeti Insert(PredmetiInsertRequest request);
        Model.Predmeti Update(int id, PredmetiInsertRequest request);
        Model.Predmeti Delete(int id, PredmetiInsertRequest request);

        string mailByKlijent(int id);

        List<Model.Predmeti> GetTodayPredmeti(PredmetiSearchRequest request);

         List<Database.Korisnici> GetAdvokatiPreporuka(int vrstaUslugeId);
    }
}
