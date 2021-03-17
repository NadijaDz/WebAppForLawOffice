using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model.Requests;
using Advokati.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advokati.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RadniSatiController : ControllerBase
    {

        private readonly IRadniSatiService _radniSatiService;

        public RadniSatiController(IRadniSatiService radniSatiService)
        {
            _radniSatiService = radniSatiService;
        }

        [HttpGet]
        public List<Model.RadniSati> Get([FromQuery]RadniSatiSearchRequest request)
        {
            return _radniSatiService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.RadniSati GetById(int id)
        {
            return _radniSatiService.GetById(id);
        }

        //[Authorize(Roles = "Advokat")]
        [HttpPost]
        public Model.RadniSati Insert(RadniSatiInsertRequest request)
        {
            return _radniSatiService.Insert(request);
        }

        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.RadniSati Update(int id,RadniSatiInsertRequest request)
        {
            return _radniSatiService.Update(id,request);
        }

        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.RadniSati Delete(int id, RadniSatiInsertRequest request)
        {
            return _radniSatiService.Delete(id, request);
        }

    }
}