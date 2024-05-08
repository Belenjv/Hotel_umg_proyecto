using hotel_umg_proyecto.Models;
using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Http;

namespace hotel_umg_proyecto.Controllers{
    [System.Web.Http.RoutePrefix("api/Habitacion")]
    public class HabitacionController : ApiController
    {
        private readonly HotelUmgContext _dbContext = new HotelUmgContext();
        public IHttpActionResult Get() {
            try {
                var HabitacionDb = _dbContext.Habitacion.ToList();
                return Ok(HabitacionDb);
            }
            catch (EntityException ex) {
                Console.WriteLine(ex.InnerException.ToString());
                return InternalServerError();
            }
        }
        [Route("{idHabitacion}")]
        public IHttpActionResult Get(int idHabitacion) {
            try {
                var HabitacionDb = _dbContext.Habitacion.Find(idHabitacion);
                if(HabitacionDb == null) {
                    return NotFound();
                }
                return Ok(HabitacionDb);
            }catch (EntityException ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]Habitacion Habitacion) {
            try
            {
                var HabitacionDb = _dbContext.Habitacion.Find(Habitacion.idHabitacion);
                if (HabitacionDb != null)
                {
                    return Conflict();
                }
                _dbContext.Habitacion.Add(Habitacion);
                _dbContext.SaveChanges();
                return Ok(Habitacion);
            }catch (EntityException ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }


        [Route("{idHabitacion}")]
        public IHttpActionResult Put(int idHabitacion, [FromBody] Habitacion Habitacion) {
            try {
                var HabitacionDb = _dbContext.Habitacion.Find(idHabitacion);
                if(HabitacionDb == null) {
                    return NotFound();
                }
                if (Habitacion.Disponibilidad != 0)
                {
                 //   HabitacionDb.idHotel= Habitacion.idHotel;
                 //   HabitacionDb.idTipoHabitacion = Habitacion.idTipoHabitacion;
                    HabitacionDb.Disponibilidad = Habitacion.Disponibilidad;
                }
                _dbContext.SaveChanges();
                return Ok(HabitacionDb);
            }catch (EntityException ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [HttpDelete]
        [Route("{idHabitacion}")]
        public IHttpActionResult Delete(int idHabitacion) {
            try {
                var HabitacionDb = _dbContext.Habitacion.Find(idHabitacion);
                if(HabitacionDb == null) {
                    return NotFound();
                }
                _dbContext.Habitacion.Remove(HabitacionDb);
                _dbContext.SaveChanges();
                return Ok(HabitacionDb);
            }catch (EntityException ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
    }
}