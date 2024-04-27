using MySql.Data.MySqlClient;

namespace Model
{
    internal class ClienteMapper
    {
        public static Cliente MapearHaciaCliente(MySqlDataReader reader)
        {
            return new Cliente
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

        public static void MapearHaciaTabla(MySqlCommand comando, Cliente cliente)
        {
            comando.Parameters.AddWithValue("@ID", cliente.ID);
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
            comando.Parameters.AddWithValue("@Ciudad", cliente.Ciudad);
            comando.Parameters.AddWithValue("@Email", cliente.Email);
            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            comando.Parameters.AddWithValue("@Ocupacion", cliente.Ocupacion);
        }
    }
}
