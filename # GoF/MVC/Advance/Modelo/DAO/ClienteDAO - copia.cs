using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;


namespace Modelo
{
    internal class ClienteDAO : ConexionMySql
    {
        public List<ClienteDTO> Consultar(string condicion)
        {
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            using (var conexion = connectionString)
            {
                using (var comando = new MySqlCommand("VerRegistros", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Condicion", condicion);
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new ClienteDTO
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                Ciudad = reader.GetString(reader.GetOrdinal("Ciudad")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Ocupacion = reader.GetString(reader.GetOrdinal("Ocupacion")),
                            });
                        }
                    }
                }
            }
            return clientes;
        }

        public static void Agregar() { }
        public static void Borrar() { }
        public static void Modificar() { }
    }
}
