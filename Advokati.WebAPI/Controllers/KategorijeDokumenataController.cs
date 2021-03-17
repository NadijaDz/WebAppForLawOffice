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
    public class KategorijeDokumenataController : ControllerBase
    {



        private readonly IKategorijeDokumenataService _kategorijeDokumenataService;
        public KategorijeDokumenataController(IKategorijeDokumenataService kategorijeDokumenataService)
        {
            _kategorijeDokumenataService = kategorijeDokumenataService;
        }

        [HttpGet]
        public List<Model.KategorijeDokumenata> Get([FromQuery]KategorijeDokumenataSearchRequest request)
        {
            return _kategorijeDokumenataService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.KategorijeDokumenata GetById(int id)
        {
            return _kategorijeDokumenataService.GetById(id);
        }

        //[Authorize(Roles = "Advokat")]
        [HttpPost]
        public Model.KategorijeDokumenata Insert(KategorijeDokumenataInsertRequest request)
        {

            return _kategorijeDokumenataService.Insert(request);


        }
        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.KategorijeDokumenata Update(int id, KategorijeDokumenataInsertRequest request)
        {
            return _kategorijeDokumenataService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.KategorijeDokumenata Delete(int id, KategorijeDokumenataInsertRequest request)
        {
            return _kategorijeDokumenataService.Delete(id, request);
        }

    }
}