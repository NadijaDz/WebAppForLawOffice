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
    public class KlijentiController : ControllerBase
    {
        private readonly IKlijentiService _klijentiService;
        public KlijentiController(IKlijentiService klijentiService)
        {
            _klijentiService = klijentiService;
        }
        [HttpGet]
        public List<Model.Korisnici> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _klijentiService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _klijentiService.GetById(id);
        }
        //[Authorize(Roles = "Advokat")]
        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            return _klijentiService.Insert(request);
        }

        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, KorisniciInsertRequest request)
        {
            return _klijentiService.Update(id,request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Korisnici Delete(int id, KorisniciInsertRequest request)
        {
            return _klijentiService.Delete(id, request);
        }

    }
}