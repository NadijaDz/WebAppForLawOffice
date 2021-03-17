using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IKategorijeDokumenataService
    {

        List<Model.KategorijeDokumenata> Get(KategorijeDokumenataSearchRequest request);
        Model.KategorijeDokumenata GetById(int id);

        Model.KategorijeDokumenata Insert(KategorijeDokumenataInsertRequest request);
        Model.KategorijeDokumenata Update(int id, KategorijeDokumenataInsertRequest request);
        Model.KategorijeDokumenata Delete(int id, KategorijeDokumenataInsertRequest request);

    }
}
