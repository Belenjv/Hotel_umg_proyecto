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
    }
}