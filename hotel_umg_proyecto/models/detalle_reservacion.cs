using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel_umg_proyecto.Models {
    [Table("detalle_reservacion")]
    public class detalle_reservacion

    {
        [Key]
        [Column("id_detalle_reservacion")]
        public int idDetalleReservacion { get; set; }


       // [Column("id_reservacion")]
        //public string idReservacion { get; set; }


        //[Column("id_habitacion")]
        //public string idHabitacion { get; set; }


        [Column("fecha_reserva")]
        public DateTime fechaReserva { get; set; }
       
    }
}