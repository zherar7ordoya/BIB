using System.Data.SQLite;
using System.Data;

namespace Modelo
{
    public class DatosTabla
    {
        private readonly ConexionBD conexionBD;

        public DatosTabla()
        {
            conexionBD = new ConexionBD("Database.db");
        }

        public DataTable ObtenerDatosTabla()
        {
            DataTable tabla = new DataTable();

            using (SQLiteConnection conexion = conexionBD.AbrirConexion())
            {
                string consulta = "SELECT * FROM Cliente;";
                using (SQLiteDataAdapter adaptador = new SQLiteDataAdapter(consulta, conexion))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }
    }
}
