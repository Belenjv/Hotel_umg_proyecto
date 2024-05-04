using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel_umg_proyecto.Models
{ [Table("usuario")]
    public class Usuario  {
        [Key]
        [Column("id_usuario")]
        public int idUsuario { get; set; }

        [Column("nombre_usuario")]
        public string nombreUsuario { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("id_empleado")]
        public int idEmpleado { get; set; }

    }
}
