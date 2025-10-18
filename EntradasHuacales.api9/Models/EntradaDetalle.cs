using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntradasHuacales.api9.Models;

public class EntradaDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int IdEntrada { get; set; }

    [Required]
    public int TipoId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }

    public virtual TipoHuacales? TipoHuacal { get; set; }
    public virtual EntradaHuacales? EntradaHuacales { get; set; }
}