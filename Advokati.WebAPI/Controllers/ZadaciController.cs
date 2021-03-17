using Advokati.Model.Requests;
using Advokati.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Advokati.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ZadaciController : ControllerBase
    {
        private readonly IZadaciService _zadaciService;

        public ZadaciController(IZadaciService zadaciService)
        {
            _zadaciService = zadaciService;
        }

        [HttpGet]
        public List<Model.Zadaci>Get([FromQuery]ZadaciSearchRequest request)
        {
            return _zadaciService.Get(request);
        }



        [Route("GetAllZadaciById/{id}")]
        [HttpGet]
        public List<Model.Zadaci> GetAllZadaciById(int id)
        {
            return _zadaciService.GetAllZadaciById(id);
        }


        [HttpGet("{id}")]
        public Model.Zadaci GetById(int id)
        {
            return _zadaciService.GetById(id);
        }

       // [Authorize(Roles = "Menadzer")]
        [HttpPost]
        public Model.Zadaci Insert(ZadaciInsertRequest request)
        {
            return _zadaciService.Insert(request);
        }

       // [Authorize(Roles = "Menadzer")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Zadaci Update(int id, ZadaciInsertRequest request)
        {
            return _zadaciService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Zadaci Delete(int id, ZadaciInsertRequest request)
        {
            return _zadaciService.Delete(id, request);
        }

        [Route("todayZadaci")]
        [HttpGet]
        public List<Model.Zadaci> todayZadaci([FromQuery]ZadaciSearchRequest request)
        {

            return _zadaciService.GetTodayZadaci(request);
        }


    }
}