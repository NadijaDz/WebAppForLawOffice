using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
    public interface IZapisnikRocistaService
    {

        List<Model.ZapisnikRocista> Get(ZapisnikRocistaSearchRequest request);
        Model.ZapisnikRocista GetById(int id);

        Model.ZapisnikRocista Insert(ZapisnikRocistaInsertRequest request);
        Model.ZapisnikRocista Update(int id, ZapisnikRocistaInsertRequest request);
        Model.ZapisnikRocista Delete(int id, ZapisnikRocistaInsertRequest request);
    }
}
