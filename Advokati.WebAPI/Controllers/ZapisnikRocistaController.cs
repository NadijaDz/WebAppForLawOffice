using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Advokati.Model.Requests;
using Advokati.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advokati.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapisnikRocistaController : ControllerBase
    {


        private readonly IZapisnikRocistaService _zapisnikRocistaService;
        public ZapisnikRocistaController(IZapisnikRocistaService zapisnikRocistaService)
        {
            _zapisnikRocistaService = zapisnikRocistaService;
        }

        [HttpGet]
        public List<Model.ZapisnikRocista> Get([FromQuery]ZapisnikRocistaSearchRequest request)
        {
            return _zapisnikRocistaService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.ZapisnikRocista GetById(int id)
        {
            return _zapisnikRocistaService.GetById(id);
        }

        //[Authorize(Roles = "Advokat")]
        //[HttpPost]
        //public Model.Fajlovi Insert(FajloviInsertRequest request)
        //{

        //    return _fajloviService.Insert(request);


        //}
        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.ZapisnikRocista Update(int id, ZapisnikRocistaInsertRequest request)
        {
            return _zapisnikRocistaService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.ZapisnikRocista Delete(int id, ZapisnikRocistaInsertRequest request)
        {
            return _zapisnikRocistaService.Delete(id, request);
        }



        public class FileProvider
        {
            //public string TestString { get; set; }

            public int RocisteID { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }

            public IFormCollection FormData { get; set; }
            public IList<IFormFile> Files { get; set; }
        }




        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload([FromForm]FileProvider fileProvider)
        {
            try
            {
                var files = fileProvider.Files;
                //var testString = fileProvider.TestString;

                //var file = Request.Form.Files[0];
                var file = fileProvider.Files[0];


                ZapisnikRocistaInsertRequest request = new ZapisnikRocistaInsertRequest();
                request.Naziv = fileProvider.Naziv;
                request.Opis = fileProvider.Opis;
                request.RocisteID = fileProvider.RocisteID;



                var folderName = Path.Combine("Resources", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    request.Url = fullPath;
                    request.Ekstenzija = Path.GetExtension(fileName);

                    _zapisnikRocistaService.Insert(request);

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


    }
}