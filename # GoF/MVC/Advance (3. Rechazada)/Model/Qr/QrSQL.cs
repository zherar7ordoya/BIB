using MySql.Data.MySqlClient;

namespace Model
{
    internal class QrSQL
    {
        public static MySqlCommand ReadAll(MySqlConnection conexion)
        {
            string query = @"SELECT * FROM QR";
            var comando = new MySqlCommand(query, conexion);
            return comando;
        }
    }
}
