using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using hotel_umg_proyecto.Models;
using MySql.Data.MySqlClient;

namespace hotel_umg_proyecto.Controllers
{
    [System.Web.Http.RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly HotelUmgContext _dbContext = new HotelUmgContext();
        public IHttpActionResult Get()
        {
            try
            {
                var usuarios = _dbContext.Usuario.ToList();
                return Ok(usuarios);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return InternalServerError();
            }

        }
        [Route("{idUsuario}")]
        public IHttpActionResult Get(int idUsuario)
        {
            try
            {
                var usuario = _dbContext.Usuario.Find(idUsuario);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();

            }

        }
        public IHttpActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioDb = _dbContext.Usuario.Find(usuario.idUsuario);
                if (usuarioDb != null)
                {
                    return Conflict();
                }
                _dbContext.Usuario.Add(usuario);
                _dbContext.SaveChanges();
                return Ok(usuario);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        [Route("{idUsuario}")]
        public IHttpActionResult Put(int idUsuario, [FromBody] Usuario usuario)
        {
            try
            {
                var usuarioDb = _dbContext.Usuario.Find(idUsuario);
                if (usuarioDb == null)
                {
                    return NotFound();
                }
                if (usuario.nombreUsuario != null)
                {
                    usuarioDb.nombreUsuario = usuario.nombreUsuario;
                }
                usuarioDb.password = usuario.password;
                usuarioDb.idEmpleado = usuario.idEmpleado;
                _dbContext.SaveChanges();
                return Ok(usuarioDb);
            }

            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }
        [HttpDelete]
        [Route("{idUsuario}")]
        public IHttpActionResult Delete(int idUsuario)
        {
            try
            {
                var usuarioDb = _dbContext.Usuario.Find(idUsuario);
                if (usuarioDb == null)
                {
                    return NotFound();
                }
                _dbContext.Usuario.Remove(usuarioDb);
                _dbContext.SaveChanges();
                return Ok(usuarioDb);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.ToString());
                return InternalServerError();

            }
        }
    }
}


   






        

            





    