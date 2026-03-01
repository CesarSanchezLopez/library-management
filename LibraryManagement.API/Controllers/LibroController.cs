using System.Collections.Generic;
using System.Web.Http;
using LibraryManagement.API.DTOs;
using LibraryManagement.API.Exceptions;
using LibraryManagement.API.Interfaces;

namespace LibraryManagement.API.Controllers
{
    [RoutePrefix("api/libros")]
    public class LibroController : ApiController
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_libroService.ObtenerLibros());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var libro = _libroService.ObtenerPorId(id);
            if (libro == null)
                return NotFound();

            return Ok(libro);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(LibroDTO libro)
        {
            try
            {
                _libroService.CrearLibro(libro);
                return Ok("Libro registrado correctamente");
            }
            catch (AutorNoExisteException ex)
            {
                return BadRequest(ex.Message);
            }
            //catch (MaximoLibrosException ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, LibroDTO libro)
        {
            _libroService.ActualizarLibro(id, libro);
            return Ok("Libro actualizado correctamente");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _libroService.EliminarLibro(id);
            return Ok("Libro eliminado correctamente");
        }
    }
}