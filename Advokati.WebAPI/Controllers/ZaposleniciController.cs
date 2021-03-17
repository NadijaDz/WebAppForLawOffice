using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model.Requests;
using Advokati.WebAPI.Database;
using Advokati.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advokati.WebAPI.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class ZaposleniciController : ControllerBase
    {
        private readonly IZaposleniciService _zaposleniciService;

        public ZaposleniciController(IZaposleniciService zaposleniciService)
        {
            _zaposleniciService = zaposleniciService;
        }


        [HttpGet]
        [AllowAnonymous]
        public List<Model.Korisnici> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _zaposleniciService.Get(request);
        }


        //[HttpGet]
        //[Authorize]
        //[Route("login")]
        //public List<Model.Korisnici> Login([FromQuery]KorisniciSearchRequest request)
        //{
        //    return _zaposleniciService.Get(request);
        //}



     
        //[HttpPost]
        //[Route("login")]
        //public List<Model.Korisnici> Login([FromBody]KorisniciSearchRequest request)
        //{
        //    return _zaposleniciService.Get(request);
        //}


        [HttpPost]
        [Route("login")]
        public Model.Korisnici Login([FromBody]KorisniciSearchRequest request)
        {
            return _zaposleniciService.Authenticiraj(request.KorisnickoIme,request.password);
        }






        //[Authorize]
        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _zaposleniciService.GetById(id);
        }

        [HttpPost]
        
        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            return _zaposleniciService.Insert(request);
        }

        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, KorisniciInsertRequest request)
        {

            return _zaposleniciService.Update(id, request);
        }



        [Route("provjeriOldPass/{id}/{oldPass}")]
        [HttpGet]
        public bool provjeriOldPass(int id,string oldPass )
        {

            if (_zaposleniciService.provjeriOldPass(id, oldPass))
            {

                return true;
            }

            return false;
        }





        //[Authorize]
        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Korisnici Delete(int id, KorisniciInsertRequest request)
        {
            return _zaposleniciService.Delete(id, request);
        }




        [Route("test")]
        [HttpGet]
        public List<Model.Korisnici> Get1([FromQuery]KorisniciSearchRequest request)
        {
            return _zaposleniciService.Get(request);
        }


    }
}