using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Modelo
{
    internal class ConexionMySql
    {
        protected MySqlConnection conexion =
            new MySqlConnection("server=localhost;user=root;password=delfin;database=Practica_Patrones");
    }
}
