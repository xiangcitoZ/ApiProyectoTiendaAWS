using ApiProyectoTienda.Repositories;
using ApiProyectoTiendaAWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PyoyectoNugetTienda;

namespace ApiProyectoTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private RepositoryCliente repo;

        public ClienteController(RepositoryCliente repo)
        {
            this.repo = repo;
        }

        [HttpGet("{id}")]
        public ActionResult<DatosArtista> DetallesCliente(int id)
        {
            return this.repo.FindCliente(id);
        }

        [HttpPut]
        [Route("[action]/{idcliente}/{nombre}/{apellidos}/{email}/{imagen}")]
        public async Task<ActionResult> EditarCliente
            (int idcliente, string nombre, string apellidos, string email, string imagen)
        {
            await this.repo.EditarClienteAsync
                (idcliente, nombre, apellidos, email, imagen);
            return Ok();
        }
    }
}
