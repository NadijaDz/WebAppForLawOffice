using Advokati.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IKontaktlistaService
    {

        List<Model.Kontaktlista> Get(KontaktlistaSearchRequest request);
        Model.Kontaktlista GetById(int id);

        Model.Kontaktlista Insert(KontaktlistaInsertRequest request);
        Model.Kontaktlista Update(int id, KontaktlistaInsertRequest request);
        Model.Kontaktlista Delete(int id, KontaktlistaInsertRequest request);

    }
}
