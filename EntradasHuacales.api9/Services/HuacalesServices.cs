using System.Linq.Expressions;
using EntradasHuacales.api9.Dal;
using EntradasHuacales.api9.DTO;
using EntradasHuacales.api9.Models;
using Microsoft.EntityFrameworkCore;

namespace EntradasHuacales.api9.Services
{
    public class HuacalesServices(IDbContextFactory<Contexto> DbFactory)
    {
        private async Task<bool> Existe(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Entradas.AnyAsync(e => e.IdEntrada == id);
        }

        private async Task<bool> Insertar(EntradaHuacales entrada)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

            foreach (var detalle in entrada.Detalle)
            {
                detalle.TipoHuacal = null;
                var tipo = await context.TiposHuacales.FindAsync(detalle.TipoId);
                if (tipo != null)
                {
                    tipo.Existencia = Math.Max(0, tipo.Existencia + detalle.Cantidad);
                }
            }

            context.Entradas.Add(entrada);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(EntradaHuacales entrada)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

            var entradaExistente = await context.Entradas
                .Include(e => e.Detalle)
                .FirstOrDefaultAsync(e => e.IdEntrada == entrada.IdEntrada);

            if (entradaExistente == null) return false;

            foreach (var detalleExistente in entradaExistente.Detalle)
            {
                var tipo = await context.TiposHuacales.FindAsync(detalleExistente.TipoId);
                if (tipo != null)
                {
                    tipo.Existencia = Math.Max(0, tipo.Existencia - detalleExistente.Cantidad);
                }
            }

            context.Entry(entradaExistente).CurrentValues.SetValues(entrada);
            context.RemoveRange(entradaExistente.Detalle);

            foreach (var detalleNuevo in entrada.Detalle)
            {
                var tipo = await context.TiposHuacales.FindAsync(detalleNuevo.TipoId);
                if (tipo != null)
                {
                    tipo.Existencia = Math.Max(0, tipo.Existencia + detalleNuevo.Cantidad);
                }

                entradaExistente.Detalle.Add(new EntradaDetalle
                {
                    TipoId = detalleNuevo.TipoId,
                    Cantidad = detalleNuevo.Cantidad,
                    Precio = detalleNuevo.Precio
                });
            }

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(EntradaHuacales entrada)
        {
            if (!await Existe(entrada.IdEntrada))
            {
                return await Insertar(entrada);
            }
            else
            {
                return await Modificar(entrada);
            }
        }

        public async Task<EntradaHuacales?> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Entradas
                .Include(e => e.Detalle)
                .ThenInclude(d => d.TipoHuacal)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdEntrada == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var entrada = await context.Entradas.Include(e => e.Detalle).FirstOrDefaultAsync(e => e.IdEntrada == id);

            if (entrada == null) return false;

            foreach (var detalle in entrada.Detalle)
            {
                var tipo = await context.TiposHuacales.FindAsync(detalle.TipoId);
                if (tipo != null)
                {
                    tipo.Existencia = Math.Max(0, tipo.Existencia - detalle.Cantidad);
                }
            }

            context.Remove(entrada);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<EntradaHuacalesDto[]> Listar(Expression<Func<EntradaHuacales, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Entradas.Where(criterio).Select(h => new EntradaHuacalesDto
            {
                NombreCliente = h.NombreCliente
            })
                .ToArrayAsync();
        }
    }
}
