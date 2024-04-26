using System.Data;

using MySql.Data.MySqlClient;

namespace Modelo
{
    internal class ClienteHelper
    {
        public static MySqlCommand CrearComando(string condicion, MySqlConnection conexion)
        {
            string query = @"SELECT * 
                             FROM Clientes 
                             WHERE ID LIKE CONCAT (@Condicion, '%') 
                             OR Nombre LIKE CONCAT (@Condicion, '%')";
            var comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@Condicion", condicion);
            return comando;
        }

        public static ClienteDTO MapearCliente(MySqlDataReader reader)
        {
            return new ClienteDTO
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                Ciudad = reader.GetString(reader.GetOrdinal("Ciudad")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                Ocupacion = reader.GetString(reader.GetOrdinal("Ocupacion"))
            };
        }
    }
}