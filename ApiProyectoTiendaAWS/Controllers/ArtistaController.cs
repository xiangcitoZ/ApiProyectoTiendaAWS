using ApiProyectoTienda.Repositories;
using ApiProyectoTiendaAWS.Models;
using ApiProyectoTiendaAWS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PyoyectoNugetTienda;

namespace ApiProyectoTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private RepositoryArtista repo;

        public ArtistaController(RepositoryArtista repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<DatosArtista> GetArtistas()
        {
            return this.repo.GetArtistas();
        }

        [HttpGet("{id}")]
        public ActionResult<DatosArtista> DetallesArtista(int id)
        {
            return this.repo.DetailsArtista(id);
        }

        [HttpPut]
        [Route("[action]/{idartista}/{nombre}/{apellidos}/{nick}/{descripcion}/{email}/{imagen}")]
        public async Task<ActionResult> EditarArtista
            (int idartista, string nombre, string apellidos, string nick, string descripcion,
            string email, string imagen)
        {
            await this.repo.PerfilArtista(idartista, nombre, apellidos, nick,
                descripcion, email, imagen);
            return Ok();
        }

        [HttpPut]
        [Route("[action]/{id}/{imagenfondo}")]
        public async Task<ActionResult> CambiarImagenFondo(int id,string imagenfondo)
        {
            await this.repo.CambiarImagenFondoAsync(id, imagenfondo);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> BorrarProducto(int id)
        {
            await this.repo.DeleteInfoArteAsync(id);
            return Ok();
        }
    }
}
