using EntradasHuacales.api9.DTO;
using EntradasHuacales.api9.Models;
using EntradasHuacales.api9.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntradasHuacales.api9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasHuacalesController(HuacalesServices huacalesServices) : ControllerBase
    {
        // GET: api/<EntradasHuacalesController>
        [HttpGet]
        public async Task<EntradaHuacalesDto[]> Get()
        {
            return await huacalesServices.Listar(h => true);
        }

        // GET api/<EntradasHuacalesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EntradasHuacalesController>
        [HttpPost]
        public async Task Post([FromBody] EntradaHuacalesDto entradaHuacales)
        {
            var huacales = new EntradaHuacales
            {
                Fecha = DateTime.Now,
                NombreCliente = entradaHuacales.NombreCliente,
                Detalle = entradaHuacales.Huacales.Select(h => new EntradaDetalle
                {
                    TipoId = h.TipoId,
                    Cantidad = h.Cantidad,
                    Precio = h.Precio,
                }).ToArray()
            };
            await huacalesServices.Guardar(huacales);
        }

        // PUT api/<EntradasHuacalesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EntradaHuacalesDto entradaHuacales)
        {
             var huacales = new EntradaHuacales
            {
                Fecha = DateTime.Now,
                IdEntrada = id,
                NombreCliente = entradaHuacales.NombreCliente,
                Detalle = entradaHuacales.Huacales.Select(h => new EntradaDetalle
                {
                    TipoId = h.TipoId,
                    Cantidad = h.Cantidad,
                    Precio = h.Precio,
                }).ToList()
            };
            await huacalesServices.Guardar(huacales);
        }

        // DELETE api/<EntradasHuacalesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await huacalesServices.Eliminar(id);
        }
    }
}
