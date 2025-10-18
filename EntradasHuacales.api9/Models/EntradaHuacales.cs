using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntradasHuacales.api9.Models;

public class EntradaHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    public string NombreCliente { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    [ForeignKey("IdEntrada")]
    public virtual ICollection<EntradaDetalle> Detalle { get; set; } = new List<EntradaDetalle>();
}