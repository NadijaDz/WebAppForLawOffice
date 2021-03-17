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
    public class PostavkeController : ControllerBase
    {

        private readonly IPostavkeService _postavkeService;
        public PostavkeController(IPostavkeService postavkeService)
        {
            _postavkeService = postavkeService;
        }

        [HttpGet]
        public List<Model.Postavke> Get([FromQuery]PostavkeSearchRequest request)
        {
            return _postavkeService.Get(request);
        }


        [HttpGet("{id}")]
        public Model.Postavke GetById(int id)
        {
            return _postavkeService.GetById(id);
        }

        //[Authorize(Roles = "Sekretar")]
        [HttpPost]
        public Model.Postavke Insert(PostavkeInsertRequest request)
        {
            return _postavkeService.Insert(request);
        }
        //[Authorize(Roles = "Sekretar")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Postavke Update(int id, PostavkeInsertRequest request)
        {
            return _postavkeService.Update(id, request);
        }


        [Route("GetByKorisnikId/{id}")]
        [HttpGet]
        public List<Model.Postavke> GetByKorisnikId(int id)
        {
            return _postavkeService.GetByKorisnikId(id);
        }

    }
}