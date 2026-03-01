using LibraryManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.API.Interfaces
{
    public interface IAutorService
    {
        List<AutorDTO> ObtenerAutores();
        AutorDTO ObtenerPorId(int id);
        void CrearAutor(AutorDTO autor);
        void ActualizarAutor(int id, AutorDTO autor);
        void EliminarAutor(int id);
    }
}
