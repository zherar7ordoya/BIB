using System.Data.SqlClient;


namespace Modelo
{
    internal class ConexionSqlServer
    {
        /**
         * El patrón Data Access object (DAO), consiste en utilizar un objeto
         * de acceso a datos para abstraer y encapsular todos los accesos a la
         * fuente de datos. El DAO maneja la conexión con la fuente de datos
         * para obtener y almacenar datos.
         * Esta clase solo tendrá la cadena de conexión a SQL Server y será una
         * súper-clase. Es decir, será heredada por todas las clases DAO.
         */
        protected SqlConnection conexion =
            new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                Initial Catalog=Practica_Patrones;
                                Integrated Security=True;");
    }
}
