using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.API.Entidades
{
    [Table("Autores")]
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string NombreCompleto { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(100)]
        public string CiudadProcedencia { get; set; }

        [Required]
        [StringLength(150)]
        public string CorreoElectronico { get; set; }

        // Relación 1 a N (Un autor puede tener muchos libros)
        public virtual ICollection<Libro> Libros { get; set; }

        public Autor()
        {
            Libros = new HashSet<Libro>();
        }
    }
}