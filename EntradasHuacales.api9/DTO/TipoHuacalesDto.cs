using System.ComponentModel.DataAnnotations;

namespace EntradasHuacales.api9.DTO;

public class TipoHuacalesDto
{

    public int TipoId { get; set; }

    public string Descripcion { get; set; }

    public int Existencia { get; set; } = 0;
}
