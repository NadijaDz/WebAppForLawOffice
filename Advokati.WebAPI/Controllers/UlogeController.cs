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
    public class UlogeController : ControllerBase
    {
        private readonly IUlogeService _ulogeService;

        public UlogeController(IUlogeService ulogeService)
        {
            _ulogeService = ulogeService;
        }

        [HttpGet]
        public List<Model.Uloge>Get()
        {
            return _ulogeService.Get();
        }
        
    }
}