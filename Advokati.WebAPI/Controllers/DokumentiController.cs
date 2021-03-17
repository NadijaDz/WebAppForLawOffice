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
    public class DokumentiController : ControllerBase
    {



        private readonly IDokumentiService _dokumentiService;
        public DokumentiController(IDokumentiService dokumentiService)
        {
            _dokumentiService = dokumentiService;
        }

        [HttpGet]
        public List<Model.Dokumenti> Get([FromQuery]DokumentiSearchReequest request)
        {
            return _dokumentiService.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Dokumenti GetById(int id)
        {
            return _dokumentiService.GetById(id);
        }

        //[Authorize(Roles = "Advokat")]
        //[HttpPost]
        //public Model.Dokumenti Insert(DokumentiInsertRequest request)
        //{

        //    return _dokumentiService.Insert(request);


        //}




        //[Authorize(Roles = "Advokat")]
        [Route("uredi/{id}")]
        [HttpPut("{id}")]
        public Model.Dokumenti Update(int id, DokumentiInsertRequest request)
        {
            return _dokumentiService.Update(id, request);
        }


        [Route("brisanje/{id}")]
        [HttpPut("{id}")]
        public Model.Dokumenti Delete(int id, DokumentiInsertRequest request)
        {
            return _dokumentiService.Delete(id, request);
        }





        public class FileProvider
        {
            //public string TestString { get; set; }

            public int KategorijaDokumentaId { get; set; }
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


                DokumentiInsertRequest request = new DokumentiInsertRequest();
                request.Naziv = fileProvider.Naziv;
                request.Opis = fileProvider.Opis;
                request.KategorijaDokumentaId = fileProvider.KategorijaDokumentaId;



                var folderName = Path.Combine("Resources", "Dokuments");
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

                    _dokumentiService.Insert(request);

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