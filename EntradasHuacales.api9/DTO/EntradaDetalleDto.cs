using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntradasHuacales.api9.Models;

namespace EntradasHuacales.api9.DTO;

public class EntradaDetalleDto
{
  
    public int TipoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

}
