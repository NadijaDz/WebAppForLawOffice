using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advokati.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VrstaUslugeController : ControllerBase
    {
        private readonly IVrstaUslugeService _vrstaUslugeService;

        public VrstaUslugeController(IVrstaUslugeService vrstaUslugeService)
        {
            _vrstaUslugeService = vrstaUslugeService;
        }

        [HttpGet]
        public List<Model.VrstaUsluge> Get()
        {
            return _vrstaUslugeService.Get();
        }
    }
}