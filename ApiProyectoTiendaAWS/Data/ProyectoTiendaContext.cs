using ApiProyectoTiendaAWS.Models;
using Microsoft.EntityFrameworkCore;
using PyoyectoNugetTienda;

namespace ApiProyectoTiendaAWS.Data
{
    public class ProyectoTiendaContext: DbContext
    {
        public ProyectoTiendaContext
            (DbContextOptions<ProyectoTiendaContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<InfoArte> InfoArtes { get; set; }
        public DbSet<InfoProducto> InfoProductos { get; set; }

    }
}
