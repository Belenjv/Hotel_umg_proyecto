using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel_umg_proyecto.Models {
    [Table("reservacion")]
    public class Reservacion
    {
        [Key]
        [Column("id_reservacion")]
        public int idReservacion { get; set; }
      
        [Column("id_cliente")]
        public int idCliente { get; set; }
    
        [Column("id_empleado")]
        public int idEmpleado { get; set; }
       
        [Column("id_hotel")]
        public int idHotel { get; set; }
        [Column("fecha_inicio")]
        public DateTime fechaInicio { get; set; }
        [Column("fecha_fin")]
        public DateTime fechaFin { get; set;}
        [Column("costo_total")]
        public int costoTotal { get;}

        [ForeignKey("idCliente")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("idEmpleado")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("idHotel")]
        public virtual Hotel Hotel { get; set; }
    }
}