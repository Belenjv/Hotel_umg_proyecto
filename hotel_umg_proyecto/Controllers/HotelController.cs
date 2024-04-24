using hotel_umg_proyecto.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace hotel_umg_proyecto.Controllers{
    [System.Web.Http.RoutePrefix("api/hotel")]
    public class HotelController : ApiController
    {
        private readonly HotelUmgContext _dbContext = new HotelUmgContext();
        public IHttpActionResult Get() {
            try {
                var hoteles = _dbContext.Hotel.ToList();
                return Ok(hoteles);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [Route("{idHotel}")]
        public IHttpActionResult Get(int idHotel) {
            try {
                var hotel = _dbContext.Hotel.Find(idHotel);
                if(hotel == null) {
                    return NotFound();
                }
                return Ok(hotel);
            }catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]Hotel hotel) {
            try {
                var hotelDb = _dbContext.Hotel.Find(hotel.idHotel);
                if (hotelDb != null) {
                    return Conflict();
                }
                _dbContext.Hotel.Add(hotel);
                _dbContext.SaveChanges();
                return Ok(hotel);
            }catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [Route("{idHotel}")]
        public IHttpActionResult Put(int idHotel, [FromBody] Hotel hotel) {
            try {
                var hotelDb = _dbContext.Hotel.Find(idHotel);
                if(hotelDb == null) {
                    return NotFound();
                }
                if (hotel.nombreHotel != null) {
                    hotelDb.nombreHotel = hotel.nombreHotel;
                }
                hotelDb.direccion = hotel.direccion;
                hotelDb.telefono = hotel.telefono;
                hotelDb.correoElectronico = hotel.correoElectronico;
                _dbContext.SaveChanges();
                return Ok(hotelDb);
            }catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [HttpDelete]
        [Route("{idHotel}")]
        public IHttpActionResult Delete(int idHotel) {
            try {
                var hotelDb = _dbContext.Hotel.Find(idHotel);
                if(hotelDb == null) {
                    return NotFound();
                }
                _dbContext.Hotel.Remove(hotelDb);
                _dbContext.SaveChanges();
                return Ok(hotelDb);
            }catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
    }
}