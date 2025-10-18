using EntradasHuacales.api9.Models;
using Microsoft.EntityFrameworkCore;

namespace EntradasHuacales.api9.Dal
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<EntradaHuacales> Entradas { get; set; }
        public DbSet<EntradaDetalle> EntradasDetalle { get; set; }
        public DbSet<TipoHuacales> TiposHuacales { get; set; }
    }
}