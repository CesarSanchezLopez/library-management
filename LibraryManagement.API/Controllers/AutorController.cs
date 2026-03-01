using System.Collections.Generic;
using System.Web.Http;
using LibraryManagement.API.DTOs;
using LibraryManagement.API.Interfaces;

namespace LibraryManagement.API.Controllers
{
    [RoutePrefix("api/autores")]
    public class AutorController : ApiController
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_autorService.ObtenerAutores());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var autor = _autorService.ObtenerPorId(id);
            if (autor == null)
                return NotFound();

            return Ok(autor);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(AutorDTO autor)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _autorService.CrearAutor(autor);
            return Ok("Autor registrado correctamente");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, AutorDTO autor)
        {
            _autorService.ActualizarAutor(id, autor);
            return Ok("Autor actualizado correctamente");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _autorService.EliminarAutor(id);
            return Ok("Autor eliminado correctamente");
        }
    }
}