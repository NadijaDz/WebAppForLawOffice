using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model.Requests;
using Advokati.WebAPI.EF;
using Advokati.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advokati.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RocistaController : ControllerBase
    {
        private readonly IRocistaService _rocistaService;

        public RocistaController(IRocistaService rocistaService)
        {
            _rocistaService = rocistaService;
        }

        [HttpGet]
        public List<Model.Rocista>Get([FromQuery]RocistaSearchRequest request)
        {
            return _rocistaService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Rocista GetById(int id)
        {
            return _rocistaService.GetById(id);
        }

        //[Authorize(Roles = "Advokat")]
        [HttpPost]
        public Model.Rocista Insert(RocistaInsertRequest request)
        {
            return _rocistaService.Insert(request);
        }

        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Rocista Update(int id, RocistaInsertRequest request)
        {
            return _rocistaService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Rocista Delete(int id, RocistaInsertRequest request)
        {
            return _rocistaService.Delete(id, request);
        }


        [Route("GetAllRocistaById/{id}")]
        [HttpGet]
        public List<Model.Rocista> GetAllRocistaById(int id)
        {
            return _rocistaService.GetAllRocistaById(id);
        }



        [Route("todayRocista")]
        [HttpGet]
        public List<Model.Rocista> todayPredmeti([FromQuery]RocistaSearchRequest request)
        {

            return _rocistaService.GetTodayRocista(request);
        }

    }
}