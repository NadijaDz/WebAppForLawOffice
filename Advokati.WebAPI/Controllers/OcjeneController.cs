using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model.Requests;
using Advokati.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advokati.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcjeneController : ControllerBase
    {
        private readonly IOcjeneService _ocjeneService;
        public OcjeneController(IOcjeneService ocjeneService)
        {
            _ocjeneService = ocjeneService;
        }

        [HttpGet]
        public List<Model.Ocjene> Get([FromQuery]OcjeneSearchRequest request)
        {
           
            return _ocjeneService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Ocjene GetById(int id)
        {
            return _ocjeneService.GetById(id);
        }

        //[Authorize(Roles = "Advokat")]
        [HttpPost]
        public Model.Ocjene Insert(OcjeneInsertRequest request)
        {

            return _ocjeneService.Insert(request);


        }
        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Ocjene Update(int id, OcjeneInsertRequest request)
        {
            return _ocjeneService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Ocjene Delete(int id, OcjeneInsertRequest request)
        {
            return _ocjeneService.Delete(id, request);
        }

    }
}