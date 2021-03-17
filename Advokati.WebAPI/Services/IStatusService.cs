using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
   public interface IStatusService
    {
        List<Model.Status> Get();
    }
}
