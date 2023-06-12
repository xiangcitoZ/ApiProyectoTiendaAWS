using ApiProyectoTienda.Repositories;
using ApiProyectoTiendaAWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PyoyectoNugetTienda;

namespace ApiProyectoTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoArteController : ControllerBase
    {

        private RepositoryInfoArte repo;

        public InfoArteController(RepositoryInfoArte repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<DatosArtista> GetInfoArte()
        {
            return this.repo.GetInfoArte();
        }

        [HttpGet("{id}")]
        public ActionResult<DatosArtista> FindInfoArte(int id)
        {
            return this.repo.FindInfoArte(id);
        }

        //[HttpGet("{ids}")]
        //public ActionResult<DatosArtista> GetInfoArteSession([FromQuery]List<int> id)
        //{
        //    return this.repo.GetInfoArteSession(id);
        //}

        [HttpPost]
        [Route("[action]/{titulo}/{precio}/{descripcion}/{imagen}/{idartista}")]
        public async Task<ActionResult> AgregarProducto
            (string titulo, int precio, string descripcion, string imagen, int idartista)
        {
            await this.repo.AgregarProductoAsync
                (titulo, precio, descripcion, imagen, idartista);
            return Ok();
        }
    }
}
