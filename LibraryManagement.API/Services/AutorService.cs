using LibraryManagement.API.Data;
using LibraryManagement.API.DTOs;
using LibraryManagement.API.Entidades;
using LibraryManagement.API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.API.Services
{
    public class AutorService : IAutorService
    {
        public List<AutorDTO> ObtenerAutores()
        {
            using (var _context = new LibraryDbContext())
            {
                return _context.Autores
                    .Select(a => new AutorDTO
                    {
                        Id = a.Id,
                        NombreCompleto = a.NombreCompleto,
                        FechaNacimiento = a.FechaNacimiento,
                        CiudadProcedencia = a.CiudadProcedencia,
                        CorreoElectronico = a.CorreoElectronico
                    }).ToList();
            }
        }

        public AutorDTO ObtenerPorId(int id)
        {
            using (var _context = new LibraryDbContext())
            {
                var autor = _context.Autores.Find(id);
                if (autor == null) return null;

                return new AutorDTO
                {
                    Id = autor.Id,
                    NombreCompleto = autor.NombreCompleto,
                    FechaNacimiento = autor.FechaNacimiento,
                    CiudadProcedencia = autor.CiudadProcedencia,
                    CorreoElectronico = autor.CorreoElectronico
                };
            }
        }

        public void CrearAutor(AutorDTO dto)
        {
            using (var _context = new LibraryDbContext())
            {
                var server = _context.Database.Connection.DataSource;
                var database = _context.Database.Connection.Database;

                System.Diagnostics.Debug.WriteLine("SERVER: " + server);
                System.Diagnostics.Debug.WriteLine("DATABASE: " + database);

                var autor = new Autor
                {
                    NombreCompleto = dto.NombreCompleto,
                    FechaNacimiento = dto.FechaNacimiento,
                    CiudadProcedencia = dto.CiudadProcedencia,
                    CorreoElectronico = dto.CorreoElectronico
                };

                _context.Autores.Add(autor);
                _context.SaveChanges();
            }
        }

        public void ActualizarAutor(int id, AutorDTO dto)
        {
            using (var _context = new LibraryDbContext())
            {
                var autor = _context.Autores.Find(id);
                if (autor == null)
                    throw new System.Exception("Autor no encontrado");

                autor.NombreCompleto = dto.NombreCompleto;
                autor.FechaNacimiento = dto.FechaNacimiento;
                autor.CiudadProcedencia = dto.CiudadProcedencia;
                autor.CorreoElectronico = dto.CorreoElectronico;

                _context.SaveChanges();
            }
        }

        public void EliminarAutor(int id)
        {
            using (var _context = new LibraryDbContext())
            {
                var autor = _context.Autores.Find(id);
                if (autor == null)
                    throw new System.Exception("Autor no encontrado");

                bool tieneLibros = _context.Libros.Any(l => l.AutorId == id);
                if (tieneLibros)
                    throw new System.Exception("No se puede eliminar el autor porque tiene libros asociados");

                _context.Autores.Remove(autor);
                _context.SaveChanges();
            }
        }
    }
}