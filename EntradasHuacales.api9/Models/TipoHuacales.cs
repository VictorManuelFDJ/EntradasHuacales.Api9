using System.ComponentModel.DataAnnotations;

namespace EntradasHuacales.api9.Models;

public class TipoHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Descripcion { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "La existencia no puede ser negativa.")]
    public int Existencia { get; set; } = 0;
}