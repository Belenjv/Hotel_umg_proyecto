using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;


namespace hotel_umg_proyecto.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly string _connectionString;

        public UsuarioController()
        {
            // La cadena de conexión se obtiene desde appsettings.json
            _connectionString = "Server=localhost;Port=3307;Database=hotel_umg;Uid=root;Pwd=123456789;";
        }

        public IHttpActionResult Get()
        {
            List<string> datos = new List<string>();

            // Intenta conectar con la base de datos
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // Realiza una operación simple, como leer algunos datos de una tabla
                string query = "SELECT * FROM usuario"; // Cambia "EjemploTabla" por el nombre de tu tabla
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    datos.Add(reader["id_usuario"].ToString());
                }


            }

            return Ok(datos);
        }

    }
}

 
    