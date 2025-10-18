using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntradasHuacales.api9.Models;

namespace EntradasHuacales.api9.DTO;

public class EntradaHuacalesDto
{
    public string NombreCliente { get; set; } = string.Empty;

    public EntradaDetalleDto[] Huacales { get; set; } = [];  
}

