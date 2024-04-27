using MySql.Data.MySqlClient;

namespace Model
{
    internal class ConexionMySql
    {
        protected MySqlConnection connectionString =
            new MySqlConnection(@"Server=localhost;
                                  User=root;
                                  Password=delfin;
                                  Database=Practica_Patrones");
    }
}
