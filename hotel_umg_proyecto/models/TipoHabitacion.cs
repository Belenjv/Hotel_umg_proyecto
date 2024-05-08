using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel_umg_proyecto.Models
{
    [Table("tipo_habitacion")]
    public class TipoHabitacion
    {
        [Key]
        [Column("id_tipo_habitacion")]
        public int idTipoHabitacion { get; set; }

        [Column("nombre_tipo")]
        public string nombreTipo { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }
    }
}