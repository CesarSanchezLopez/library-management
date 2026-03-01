using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.API.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string CorreoElectronico { get; set; }
    }
}