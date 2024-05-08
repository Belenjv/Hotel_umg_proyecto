using hotel_umg_proyecto.Models;
using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Http;

namespace hotel_umg_proyecto.Controllers
{
    [System.Web.Http.RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        private readonly HotelUmgContext _dbContext = new HotelUmgContext();
        public IHttpActionResult Get()
        {
            try
            {
                var clientes = _dbContext.Cliente.ToList();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [Route("{idCliente}")]
        public IHttpActionResult Get(int idCliente)
        {
            try
            {
                var cliente = _dbContext.Cliente.Find(idCliente);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                var clienteDb = _dbContext.Cliente.Find(cliente.idCliente);
                if (clienteDb != null)
                {
                    return Conflict();
                }
                _dbContext.Cliente.Add(cliente);
                _dbContext.SaveChanges();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [Route("{idCliente}")]
        public IHttpActionResult Put(int idCliente, [FromBody] Cliente cliente)
        {
            try
            {
                var clienteDb = _dbContext.Cliente.Find(idCliente);
                if (clienteDb == null)
                {
                    return NotFound();
                }
                if (cliente.Nombre != null)
                {
                    clienteDb.Nombre = cliente.Nombre;
                }
                clienteDb.Direccion = cliente.Direccion;
                clienteDb.Telefono = cliente.Telefono;
                clienteDb.correoElectronico = cliente.correoElectronico;
                _dbContext.SaveChanges();
                return Ok(clienteDb);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [HttpDelete]
        [Route("{idCliente}")]
        public IHttpActionResult Delete(int idCliente)
        {
            try
            {
                var clienteDb = _dbContext.Cliente.Find(idCliente);
                if (clienteDb == null)
                {
                    return NotFound();
                }
                _dbContext.Cliente.Remove(clienteDb);
                _dbContext.SaveChanges();
                return Ok(clienteDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
    }
}