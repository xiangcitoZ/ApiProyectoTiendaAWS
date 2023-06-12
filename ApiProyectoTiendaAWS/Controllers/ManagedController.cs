using ApiProyectoTienda.Repositories;
using ApiProyectoTiendaAWS.Models;
using ApiProyectoTiendaAWS.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiProyectoTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagedController : ControllerBase
    {
        private RepositoryCliente repoClient;
        private RepositoryArtista repoArtist;

        public ManagedController(RepositoryCliente repoClient, RepositoryArtista repoArtist)
        {
            this.repoClient = repoClient;
            this.repoArtist = repoArtist;
        }

        #region CLIENTE

        [HttpPost]
        [Route("[action]/{email}/{password}")]
        public async Task<ActionResult> LoginCliente(string email
            , string password)
        {
            Cliente cliente =
                await this.repoClient.ExisteCliente(email, password);
            return Ok();
        }

        [HttpPost]
        [Route("[action]/{nombre}/{apellidos}/{email}/{password}/{imagen}")]
        public async Task<ActionResult> RegisterCliente
            (string nombre, string apellidos, string email, string password, string imagen)
        {
            await this.repoClient.RegistrarClienteAsync
                (nombre, apellidos, email, password, imagen);
            return Ok();
        }

        #endregion

        #region ARTISTA

        [HttpPost]
        [Route("[action]/{email}/{password}")]
        public async Task<ActionResult> LoginArtista(string email
            , string password)
        {
            Artista artista =
                await this.repoArtist.ExisteArtista(email, password);
            return Ok();
            
        }

        [HttpPost]
        [Route("[action]/{nombre}/{apellidos}/{nick}/{descripcion}/{email}/{password}/{imagen}/{imagenfondo}")]
        public async Task<IActionResult> RegisterArtista
            (string nombre, string apellidos, string nick, string descripcion,
            string email, string password, string imagen, string imagenfondo)
        {
            await this.repoArtist.RegistrarArtistaAsync
                (nombre, apellidos, nick, descripcion,
                email, password, imagen, imagenfondo);
            return Ok();
        }

        #endregion
    }
}
