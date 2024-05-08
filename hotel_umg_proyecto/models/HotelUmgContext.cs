using MySql.Data.EntityFramework;
using System;
using System.Configuration;
using System.Data.Entity;
namespace hotel_umg_proyecto.Models {
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class HotelUmgContext : DbContext {
        public HotelUmgContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString) {}

        public DbSet<Hotel> Hotel { get; set; }


        public DbSet<Reservacion> Reservacion { get; set; }
        public DbSet<TipoHabitacion> TipoHabitacion { get;set; }
        public DbSet<Usuario> Usuario { get; set; }




        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Habitacion> Habitacion { get; set; }


        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<detalle_reservacion> detalle_reservacion { get; set; }

    }
}