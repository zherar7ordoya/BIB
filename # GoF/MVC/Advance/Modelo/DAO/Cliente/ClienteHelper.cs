using System.Data;

using MySql.Data.MySqlClient;

namespace Modelo
{
    internal class ClienteHelper
    {
        public static MySqlCommand CrearComando(string condicion, MySqlConnection conexion)
        {
            var comando = new MySqlCommand("VerRegistros", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
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