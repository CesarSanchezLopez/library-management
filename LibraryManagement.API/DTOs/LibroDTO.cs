using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.API.DTOs
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public int AutorId { get; set; }
        public object FechaPublicacion { get; internal set; }
    }
}