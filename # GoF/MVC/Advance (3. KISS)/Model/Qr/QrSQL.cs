using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
