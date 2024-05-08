using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel_umg_proyecto.Models {
    [Table("Hotel")]
    public class Hotel {
        [Key]
        [Column("id_hotel")]
        public int idHotel { get; set; }
        [Column("nombre_hotel")]
        public string nombreHotel { get; set; }
        [Column("direccion")]
        public string direccion {  get; set; }
        [Column("telefono")]
        public string telefono { get; set; }
        [Column("correo_electronico")]
        public string correoElectronico { get; set; }
    }
}