using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel_umg_proyecto.Models {
    [Table("Habitacion")]
    public class Habitacion {
        [Key]
        [Column("id_habitacion")]
        public int idHabitacion { get; set; }
       
        //[Column("id_hotel")]
        // [Foreign Key("Hotel")]
        // public int idHotel { get; set; }
        // public virtual Hotel Hotel { get; set; }

        //[Column("id_tipo_habitacion")]
        // [Foreign Key("Habitacion")]
        // public int idTipoHabitacion { get; set; }
        // public virtual Habitacion Habitacion { get; set; }

        [Column("disponibilidad")]
        public int Disponibilidad { get; set; }
        
    }
}