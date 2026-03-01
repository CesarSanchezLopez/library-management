using LibraryManagement.API.Data;
using LibraryManagement.API.DTOs;
using LibraryManagement.API.Entidades;
using LibraryManagement.API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.API.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibraryDbContext _context;

        public LibroService(LibraryDbContext context)
        {
            _context = context;
        }

        public List<LibroDTO> ObtenerLibros()
        {
            return _context.Libros
                .Select(l => new LibroDTO
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Anio = l.Anio,
                    Genero = l.Genero,
                    NumeroPaginas = l.NumeroPaginas,
                    AutorId = l.AutorId
                  
                }).ToList();
        }

        public LibroDTO ObtenerPorId(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null) return null;

            return new LibroDTO
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Anio = libro.Anio,
                Genero = libro.Genero,
                NumeroPaginas = libro.NumeroPaginas,
                AutorId = libro.AutorId
              
            };
        }

        public void CrearLibro(LibroDTO dto)
        {
            var libro = new Libro
            {
                Titulo = dto.Titulo,
                Anio = dto.Anio,
                Genero = dto.Genero,
                NumeroPaginas = dto.NumeroPaginas,
                AutorId = dto.AutorId
             
            };

            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public void ActualizarLibro(int id, LibroDTO dto)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null)
                throw new System.Exception("Libro no encontrado");

            libro.Titulo = dto.Titulo;
            libro.Anio = dto.Anio;
            libro.Genero = dto.Genero;
            libro.NumeroPaginas = dto.NumeroPaginas;
            libro.AutorId = dto.AutorId;
          

            _context.SaveChanges();
        }

        public void EliminarLibro(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null)
                throw new System.Exception("Libro no encontrado");

            _context.Libros.Remove(libro);
            _context.SaveChanges();
        }
    }
}