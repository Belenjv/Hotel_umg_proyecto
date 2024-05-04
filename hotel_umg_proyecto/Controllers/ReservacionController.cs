using hotel_umg_proyecto.Models;
using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Http;

namespace hotel_umg_proyecto.Controllers
{
    [System.Web.Http.RoutePrefix("api/reservacion")]
    public class ReservacionController : ApiController
    {
        private readonly HotelUmgContext _dbContext = new HotelUmgContext();
        public IHttpActionResult Get()
        {
            try
            {
                var reservaciones = _dbContext.Reservacion.ToList();
                return Ok(reservaciones);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return InternalServerError();
            }
        }
        //busqueda por Id
        [Route("{idReservacion}")]
        public IHttpActionResult Get(int idReservacion)
        {
            try
            {
                var reservacion = _dbContext.Reservacion.Find(idReservacion);
                if (reservacion == null)
                {
                    return NotFound();
                }
                return Ok(reservacion);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
            }
        //metodo post
             public IHttpActionResult Post([FromBody] Reservacion reservacion)
            {
                try
                {
                    var reservacionDb = _dbContext.Reservacion.Find(reservacion.idReservacion);
                    if (reservacionDb != null)
                    {
                        return Conflict();
                    }
                    _dbContext.Reservacion.Add(reservacion);
                    _dbContext.SaveChanges();
                    return Ok(reservacion);
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return InternalServerError();
                }
            }
        //metodo put
        [Route("{idReservacion}")]
        public IHttpActionResult Put(int idReservacion, [FromBody] Reservacion reservacion)
        {
            try
            {
                var reservacionDb = _dbContext.Reservacion.Find(idReservacion);
                if (reservacionDb == null)
                {
                    return NotFound();
                }
                reservacionDb.idCliente = reservacion.idCliente;
                reservacionDb.idEmpleado = reservacion.idEmpleado;
                reservacionDb.idHotel = reservacion.idHotel;
                reservacionDb.fechaInicio = reservacion.fechaInicio;
                reservacionDb.fechaFin = reservacion.fechaFin;

                _dbContext.SaveChanges();
                return Ok(reservacionDb);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        //metodo delete
        [HttpDelete]
        [Route("{idReservacion}")]
        public IHttpActionResult Delete(int idReservacion)
        {
            try
            {
                var reservacionDb = _dbContext.Reservacion.Find(idReservacion);
                if (reservacionDb == null)
                {
                    return NotFound();
                }
                _dbContext.Reservacion.Remove(reservacionDb);
                _dbContext.SaveChanges();
                return Ok(reservacionDb);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }

        }
    }
}

