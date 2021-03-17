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
    public class UredController : ControllerBase
    {
        private readonly IUredService _uredService;
        public UredController(IUredService uredService)
        {
            _uredService = uredService;
        }

        [HttpGet]
        public List<Model.Ured>Get([FromQuery]UredSearchRequest request)
        {
            return _uredService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Ured GetById(int id)
        {
            return _uredService.GetById(id);
        }

        //[Authorize(Roles = "Sekretar")]
        [HttpPost]
        public Model.Ured Insert(UredInsertRequest request)
        {
            return _uredService.Insert(request);
        }
        //[Authorize(Roles = "Sekretar")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Ured Update(int id, UredInsertRequest request)
        {
            return _uredService.Update(id, request);
        }

        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Ured Delete(int id, UredInsertRequest request)
        {
            return _uredService.Delete(id, request);
        }

    }
}