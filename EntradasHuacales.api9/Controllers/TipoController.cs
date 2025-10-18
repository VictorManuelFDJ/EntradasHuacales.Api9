using System.Runtime.InteropServices;
using EntradasHuacales.api9.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntradasHuacales.api9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController (HuacalesServices TipoServices) : ControllerBase
    {
        // GET: api/<TipoController>
        [HttpGet]
        public async Task Get()
        {
            await TipoServices.ListarTodo(t => true);
        }

        // GET api/<TipoController>/5
        [HttpGet("{id}")]
        public async Task Get(int id)
        {
            await TipoServices.ListarTodo(t => t.TipoId == id);
        }


    }
}
