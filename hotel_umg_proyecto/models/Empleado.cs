using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel_umg_proyecto.Models {
    [Table("Empleado")]
    public class Empleado {
        [Key]
        [Column("id_empleado")]
        public int idEmpleado { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }
        [Column("apellido")]
        public string apellido { get; set; }
        [Column("cargo")]
        public string cargo { get; set; }

        [Column("salario")]
        public decimal salario { get; set; }

        [Column("fecha_contratacion")]
        public DateTime fechaContratacion { get; set; }

       [Column("id_hotel")]
       [ForeignKey("Hotel")]
       public int idHotel { get; set; }
       public virtual Hotel Hotel { get; set; }
    }
}