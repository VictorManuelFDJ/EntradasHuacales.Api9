using System.Linq.Expressions;
using EntradasHuacales.api9.Dal;
using EntradasHuacales.api9.Models;
using Microsoft.EntityFrameworkCore;

namespace EntradasHuacales.api9.Services
{
    public class TipoHuacalesService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Existe(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposHuacales.AnyAsync(t => t.TipoId == tipoId);
        }

        private async Task<bool> Insertar(TipoHuacales tipoHuacal)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.TiposHuacales.Add(tipoHuacal);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(TipoHuacales tipoHuacal)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.TiposHuacales.Update(tipoHuacal);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(TipoHuacales tipoHuacal)
        {
            if (!await Existe(tipoHuacal.TipoId))
            {
                return await Insertar(tipoHuacal);
            }
            else
            {
                return await Modificar(tipoHuacal);
            }
        }

        public async Task<TipoHuacales?> Buscar(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposHuacales.FindAsync(tipoId);
        }

        public async Task<bool> Eliminar(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposHuacales
                .AsNoTracking()
                .Where(t => t.TipoId == tipoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<TipoHuacales>> Listar(Expression<Func<TipoHuacales, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposHuacales
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<TipoHuacales>> ListarTodos()
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposHuacales
                .AsNoTracking()
                .ToListAsync();
        }
    }
}