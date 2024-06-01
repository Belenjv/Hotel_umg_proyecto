using hotel_umg_proyecto.Models;
using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Http;

namespace hotel_umg_proyecto.Controllers
{
    [System.Web.Http.RoutePrefix("api/detalle_reservacion")]
    public class detalle_reservacionController : ApiController
    {
        private readonly HotelUmgContext _dbContext = new HotelUmgContext();
        public IHttpActionResult Get()
        {
            try
            {
                var detalles = _dbContext.detalle_reservacion.ToList();
                return Ok(detalles);
            }
            catch (Exception ex)
            {   
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [Route("{idDetalleReservacion}")]
        public IHttpActionResult Get(int idDetalleReservacion)
        {
            try
            {
                var detalles = _dbContext.detalle_reservacion.Find(idDetalleReservacion);
                if (detalles == null)
                {
                    return NotFound();
                }
                return Ok(detalles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody] detalle_reservacion detalles)
        {
            try
            {
                var detalle_reservacionDb = _dbContext.detalle_reservacion.Find(detalles.idDetalleReservacion);
                if (detalle_reservacionDb != null)
                {
                    return Conflict();
                }
                _dbContext.detalle_reservacion.Add(detalles);
                _dbContext.SaveChanges();
                return Ok(detalles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [Route("{idDetalleReservacion}")]
        public IHttpActionResult Put(int idDetalleReservacion, [FromBody] detalle_reservacion detalles)
        {
            try
            {
                var detalle_reservacionDb = _dbContext.detalle_reservacion.Find(idDetalleReservacion);
                if (detalle_reservacionDb == null)
                {
                    return NotFound();
                }

                {
                    detalle_reservacionDb.idDetalleReservacion = detalles.idDetalleReservacion;
                }
               detalle_reservacionDb.idReservacion = detalles.idReservacion;
               detalle_reservacionDb.idHabitacion = detalles.idHabitacion;
                detalle_reservacionDb.fechaReserva = detalles.fechaReserva;
                _dbContext.SaveChanges();
                return Ok(detalle_reservacionDb);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [HttpDelete]
        [Route("{idDetalleReservacion}")]
        public IHttpActionResult Delete(int idDetalleReservacion)
        {
            try
            {
                var detalle_reservacionDb = _dbContext.detalle_reservacion.Find(idDetalleReservacion);
                if (detalle_reservacionDb == null)
                {
                    return NotFound();
                }
                _dbContext.detalle_reservacion.Remove(detalle_reservacionDb);
                _dbContext.SaveChanges();
                return Ok(detalle_reservacionDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
    }
}