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


        [Column("id_reservacion")]
        [ForeignKey("Reservacion")]
        public int idReservacion { get; set; }
        public virtual Reservacion Reservacion { get; set; }

        [Column("id_habitacion")]
        [ForeignKey("Habitacion")]
        public int idHabitacion { get; set; }
        public virtual Habitacion Habitacion { get; set; }


        [Column("fecha_reserva")]
        public DateTime fechaReserva { get; set; }
       
    }
}