using LibraryManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.API.Interfaces
{
    public interface ILibroService
    {
        List<LibroDTO> ObtenerLibros();
        LibroDTO ObtenerPorId(int id);
        void CrearLibro(LibroDTO libro);
        void ActualizarLibro(int id, LibroDTO libro);
        void EliminarLibro(int id);
    }
}
