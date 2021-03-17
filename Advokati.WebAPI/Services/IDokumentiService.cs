using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
    public interface IDokumentiService
    {

        List<Model.Dokumenti> Get(DokumentiSearchReequest request);
        Model.Dokumenti GetById(int id);

        Model.Dokumenti Insert(DokumentiInsertRequest request);
        Model.Dokumenti Update(int id, DokumentiInsertRequest request);
        Model.Dokumenti Delete(int id, DokumentiInsertRequest request);
    }
}
