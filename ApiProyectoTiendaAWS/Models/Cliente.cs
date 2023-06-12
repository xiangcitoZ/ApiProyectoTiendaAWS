using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyectoTiendaAWS.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Password")]
        public byte[] Password { get; set; }

        [Column("Salt")]
        public string Salt { get; set; }

        [Column("Imagen")]
        public string Imagen { get; set; }
    }
}
