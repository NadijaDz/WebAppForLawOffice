using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IRadniSatiService
    {
        List<Model.RadniSati> Get(RadniSatiSearchRequest request);
        Model.RadniSati GetById(int id);
        Model.RadniSati Update(int id, RadniSatiInsertRequest request);
        Model.RadniSati Insert(RadniSatiInsertRequest request);
        Model.RadniSati Delete(int id, RadniSatiInsertRequest request);
    }
}
