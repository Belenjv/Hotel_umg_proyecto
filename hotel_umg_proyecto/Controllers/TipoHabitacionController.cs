using hotel_umg_proyecto.Models;
using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Http;

namespace hotel_umg_proyecto.Controllers
{
    [System.Web.Http.RoutePrefix("api/tipoHabitacion")]
    public class TipoHabitacionController : ApiController
    {
        private readonly HotelUmgContext _dbContext = new HotelUmgContext();

        public IHttpActionResult Get()
        {
            try
            {
                var tiposHabitacion = _dbContext.TipoHabitacion.ToList();
                return Ok(tiposHabitacion);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return InternalServerError();
            }
        }

        [Route("{idTipoHabitacion}")]
        public IHttpActionResult Get(int idTipoHabitacion)
        {
            try
            {
                var tipoHabitacion = _dbContext.TipoHabitacion.Find(idTipoHabitacion);
                if (tipoHabitacion == null)
                {
                    return NotFound();
                }
                return Ok(tipoHabitacion);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        public IHttpActionResult Post([FromBody] TipoHabitacion tipoHabitacion)
        {
            try
            {
                _dbContext.TipoHabitacion.Add(tipoHabitacion);
                _dbContext.SaveChanges();
                return Ok(tipoHabitacion);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        [Route("{idTipoHabitacion}")]
        public IHttpActionResult Put(int idTipoHabitacion, [FromBody] TipoHabitacion tipoHabitacion)
        {
            try
            {
                var tipoHabitacionDb = _dbContext.TipoHabitacion.Find(idTipoHabitacion);
                if (tipoHabitacionDb == null)
                {
                    return NotFound();
                }
                tipoHabitacionDb.nombreTipo = tipoHabitacion.nombreTipo;
                tipoHabitacionDb.descripcion = tipoHabitacion.descripcion;

                _dbContext.SaveChanges();
                return Ok(tipoHabitacionDb);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("{idTipoHabitacion}")]
        public IHttpActionResult Delete(int idTipoHabitacion)
        {
            try
            {
                var tipoHabitacionDb = _dbContext.TipoHabitacion.Find(idTipoHabitacion);
                if (tipoHabitacionDb == null)
                {
                    return NotFound();
                }
                _dbContext.TipoHabitacion.Remove(tipoHabitacionDb);
                _dbContext.SaveChanges();
                return Ok(tipoHabitacionDb);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
    }
}
