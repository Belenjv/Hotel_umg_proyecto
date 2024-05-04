using hotel_umg_proyecto.Models;
using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Http;

namespace hotel_umg_proyecto.Controllers{
    [System.Web.Http.RoutePrefix("api/Empleado")]
    public class EmpleadoController : ApiController
    {
        private readonly HotelUmgContext _dbContext = new HotelUmgContext();
        public IHttpActionResult Get() {
            try {
                var EmpleadoDb = _dbContext.Empleado.ToList();
                return Ok(EmpleadoDb);
            }
            catch (EntityException ex) {
                Console.WriteLine(ex.InnerException.ToString());
                return InternalServerError();
            }
        }

        [Route("{idEmpleado}")]
        public IHttpActionResult Get(int idEmpleado) {
            try {
                var EmpleadoDb = _dbContext.Empleado.Find(idEmpleado);
                if(EmpleadoDb == null) {
                    return NotFound();
                }
                return Ok(EmpleadoDb);
            }catch (EntityException ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]Empleado Empleado) {
            try {
                var EmpleadoDb = _dbContext.Empleado.Find(Empleado.idEmpleado);
                if (EmpleadoDb != null) {
                    return Conflict();
                }
                _dbContext.Empleado.Add(Empleado);
                _dbContext.SaveChanges();
                return Ok(Empleado);
            }catch (EntityException ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [Route("{idEmpleado}")]
        public IHttpActionResult Put(int idEmpleado, [FromBody] Empleado Empleado) {
            try {
                var EmpleadoDb = _dbContext.Empleado.Find(idEmpleado);
                if(EmpleadoDb == null) {
                    return NotFound();
                }
                if (Empleado.nombre != null) {
                    EmpleadoDb.nombre = Empleado.nombre;
                    EmpleadoDb.apellido = Empleado.apellido;
                    EmpleadoDb.cargo = Empleado.cargo;
                    EmpleadoDb.salario = Empleado.salario;
                    EmpleadoDb.fechaContratacion = Empleado.fechaContratacion;
                }
                _dbContext.SaveChanges();
                return Ok(EmpleadoDb);
            }catch (EntityException ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [HttpDelete]
        [Route("{idEmpleado}")]
        public IHttpActionResult Delete(int idEmpleado) {
            try {
                var EmpleadoDb = _dbContext.Empleado.Find(idEmpleado);
                if(EmpleadoDb == null) {
                    return NotFound();
                }
                _dbContext.Empleado.Remove(EmpleadoDb);
                _dbContext.SaveChanges();
                return Ok(EmpleadoDb);
            }catch (EntityException ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
    }
}