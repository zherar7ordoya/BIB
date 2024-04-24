using System.Collections.Generic;
using System.Data;
// using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace Modelo
{
    // internal class ClienteDAO : ConexionSqlServer
    internal class ClienteDAO : ConexionMySql
    {
        //SqlDataReader reader;
        MySqlDataReader reader;
        //readonly SqlCommand comando = new SqlCommand();
        readonly MySqlCommand comando = new MySqlCommand();

        public List<ClienteDTO> Consultar(string condicion)
        {
            comando.Connection = conexion;
            comando.CommandText = "VerRegistros";   //Stored Procedure
            comando.CommandType = CommandType.StoredProcedure; //¿Ves?
            comando.Parameters.AddWithValue("@Condicion", condicion);

            conexion.Open();
            reader = comando.ExecuteReader();

            List<ClienteDTO> clientes = new List<ClienteDTO>();

            while (reader.Read())
            {
                clientes.Add(new ClienteDTO
                {
                    ID = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Apellido = reader.GetString(2),
                    Direccion = reader.GetString(3),
                    Ciudad = reader.GetString(4),
                    Email = reader.GetString(5),
                    Telefono = reader.GetString(6),
                    Ocupacion = reader.GetString(7),
                });
            }
            reader.Close();
            conexion.Close();
            return clientes;
        }
        public static void Agregar() { }
        public static void Borrar() { }
        public static void Modificar() { }
    }
}
