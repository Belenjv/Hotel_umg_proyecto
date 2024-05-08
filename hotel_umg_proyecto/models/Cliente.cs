using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel_umg_proyecto.Models {
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int idCliente { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("apellido")]
        public string Apellido { get; set; }
        [Column("direccion")]
        public string Direccion { get; set; }
        [Column("telefono")]
        public string Telefono { get; set; }
        [Column("correo_electronico")]
        public string correoElectronico { get; set; }
    }
}