using LibraryManagement.API.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Libros")]
public class Libro
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Titulo { get; set; }

    [Required]
    public int Anio { get; set; }

    [Required]
    [StringLength(100)]
    public string Genero { get; set; }

    [Required]
    public int NumeroPaginas { get; set; }

    [Required]
    public int AutorId { get; set; }

    [ForeignKey("AutorId")]
    public virtual Autor Autor { get; set; }
}