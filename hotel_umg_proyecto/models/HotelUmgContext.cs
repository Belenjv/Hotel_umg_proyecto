using System.Configuration;
using System.Data.Entity;
namespace hotel_umg_proyecto.Models {
    public class HotelUmgContext : DbContext {
        public HotelUmgContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString) { }

        public DbSet<Hotel> Hotel { get; set; }
    }
}