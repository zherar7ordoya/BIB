using System.Data.SQLite;

namespace Modelo
{
    public class ConexionBD
    {
        private SQLiteConnection conexion;

        public ConexionBD(string rutaBaseDatos)
        {
            conexion = new SQLiteConnection($"Data Source={rutaBaseDatos};Version=3;");
        }

        public SQLiteConnection AbrirConexion()
        {
            if (conexion.State != System.Data.ConnectionState.Open)
                conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State != System.Data.ConnectionState.Closed)
                conexion.Close();
        }
    }
}
