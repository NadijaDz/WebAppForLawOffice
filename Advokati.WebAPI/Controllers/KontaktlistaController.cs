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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KontaktlistaController : ControllerBase
    {

        private readonly IKontaktlistaService _kontaktlistaService;
        public KontaktlistaController(IKontaktlistaService kontaktlistaService)
        {
            _kontaktlistaService = kontaktlistaService;
        }
        [HttpGet]
        public List<Model.Kontaktlista> Get([FromQuery]KontaktlistaSearchRequest request)
        {
            return _kontaktlistaService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Kontaktlista GetById(int id)
        {
            return _kontaktlistaService.GetById(id);
        }
        //[Authorize(Roles = "Advokat")]
        [HttpPost]
        public Model.Kontaktlista Insert(KontaktlistaInsertRequest request)
        {
            return _kontaktlistaService.Insert(request);
        }

        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Kontaktlista Update(int id, KontaktlistaInsertRequest request)
        {
            return _kontaktlistaService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Kontaktlista Delete(int id, KontaktlistaInsertRequest request)
        {
            return _kontaktlistaService.Delete(id, request);
        }


    }
}