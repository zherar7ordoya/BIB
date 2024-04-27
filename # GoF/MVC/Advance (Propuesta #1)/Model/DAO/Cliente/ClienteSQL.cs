using MySql.Data.MySqlClient;

namespace Model
{
    internal class ClienteSQL
    {
        public static MySqlCommand ReadAll(string condicion, MySqlConnection conexion)
        {
            string query = @"SELECT * 
                             FROM Clientes 
                             WHERE ID LIKE CONCAT (@Condicion, '%') 
                             OR Nombre LIKE CONCAT (@Condicion, '%')";
            var comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@Condicion", condicion);
            return comando;
        }

        public static MySqlCommand ReadById(int id, MySqlConnection conexion)
        {
            string query = @"SELECT * 
                             FROM Clientes 
                             WHERE ID = @ID";
            var comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", id);
            return comando;
        }

        public static MySqlCommand Delete(int id, MySqlConnection conexion)
        {
            string query = @"DELETE 
                             FROM Clientes 
                             WHERE ID = @ID";
            var comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", id);
            return comando;
        }
    }
}