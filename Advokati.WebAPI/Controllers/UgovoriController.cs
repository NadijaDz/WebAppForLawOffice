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
    public class UgovoriController : ControllerBase
    {
        private readonly IUgovoriService _ugovoriService;
        public UgovoriController(IUgovoriService ugovoriService)
        {
            _ugovoriService = ugovoriService;
        }

        [HttpGet]
        public List<Model.Ugovori> Get([FromQuery]UgovoriSearchRequest request)
        {
            return _ugovoriService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Ugovori GetById(int id)
        {
            return _ugovoriService.GetById(id);
        }

        //[Authorize(Roles = "Menadzer")]
        [HttpPost]
        public Model.Ugovori Insert(UgovoriInsertRequest request)
        {
            return _ugovoriService.Insert(request);
        }

        //[Authorize(Roles = "Menadzer")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Ugovori Update(int id, UgovoriInsertRequest request)
        {
            return _ugovoriService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Ugovori Delete(int id, UgovoriInsertRequest request)
        {
            return _ugovoriService.Delete(id, request);
        }

    }
}