namespace ApiProyectoTiendaAWS.Models
{
    public class DatosArtista
    {
        public List<InfoProducto> listaProductos { get; set; }
        public List<Artista> listaArtistas { get; set; }
        public Artista artista { get; set; }
        public InfoProducto infoProducto { get; set; }
        public Cliente cliente { get; set; }
    }
}
