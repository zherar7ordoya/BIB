using MySql.Data.MySqlClient;


namespace Modelo
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
