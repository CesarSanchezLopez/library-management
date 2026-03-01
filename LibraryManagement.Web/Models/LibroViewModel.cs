using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class LibroViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Range(1, 9999)]
        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Display(Name = "Género")]
        public string Genero { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Número de Páginas")]
        public int NumeroPaginas { get; set; }

        [Required]
        [Display(Name = "Autor")]
        public int AutorId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Publicación")]
        public DateTime? FechaPublicacion { get; set; }
    }
}
