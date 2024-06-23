using System.ComponentModel.DataAnnotations;

namespace ArticulosAPi.Models;
public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\s]+$", ErrorMessage = "Solo se permiten letras")]
    public string Descripcion { get; set; }
    [Range(0.01, float.MaxValue, ErrorMessage = "El costo debe ser mayor a 0")]
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public decimal Costo { get; set; }
    [Range(0.01, 100, ErrorMessage = "La ganancia debe ser mayor a 0")]
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public decimal Ganancia { get; set; }
    [Range(0.01, float.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public decimal Precio { get; set; }
}