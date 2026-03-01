using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class AutorViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Ciudad de Procedencia")]
        public string CiudadProcedencia { get; set; }

        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }
    }
}
