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
    public class SastanciController : ControllerBase
    {
        private readonly ISastanciService _sastanciService;
        public SastanciController(ISastanciService sastanciService)
        {
            _sastanciService = sastanciService;
        }

        [HttpGet]
        public List<Model.Sastanci>Get([FromQuery]SastanciSearchRequest request)
        {
            return _sastanciService.Get(request);
        }


        [HttpGet("{id}")]
        public Model.Sastanci GetById(int id)
        {
            return _sastanciService.GetById(id);
        }

   
        [HttpPost]
        public Model.Sastanci Insert(SastanciInsertRequest request)
        {
            return _sastanciService.Insert(request);
        }
   
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Sastanci Update(int id, SastanciInsertRequest request)
        {
            return _sastanciService.Update(id, request);
        }



        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Sastanci Delete(int id, SastanciInsertRequest request)
        {
            return _sastanciService.Delete(id, request);
        }
        [HttpGet]
        [Route("{vrstaUslugeId:int}/advokati")]
        [AllowAnonymous]
        public List<Database.Korisnici> GetAdvokati(int vrstaUslugeId)
        {
            return _sastanciService.GetAdvokatiPreporuka(vrstaUslugeId);
        }

        [Route("GetAllSastanciById/{id}")]
        [HttpGet]
        public List<Model.Sastanci> GetAllSastanciById(int id)
        {
            return _sastanciService.GetAllSastanciById(id);
        }

        [Route("todaySastanci")]
        [HttpGet]
        public List<Model.Sastanci> todaySastanci([FromQuery]SastanciSearchRequest request)
        {

            return _sastanciService.GetTodaySastanci(request);
        }

        [Route("ZakaziSastanak")]
        [HttpPost]
        public Model.Sastanci ZakaziSastanak(SastanciInsertRequest request)
        {
            return _sastanciService.ZakaziSastanak(request);
        }


    }
}