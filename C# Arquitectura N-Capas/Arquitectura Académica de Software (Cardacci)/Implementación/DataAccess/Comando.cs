using System.Data.SqlClient;
using System.Data;


namespace DataAccess
{
    public class Comando
    {
        SqlCommand _comando;
        Conexion _conexion;


        private SqlCommand RetornaComando(string sentencia, SqlConnection conexion)
        {
            _comando = new SqlCommand
            {
                CommandText = sentencia,
                CommandType = CommandType.Text,
                Connection = conexion
            };
            return _comando;
        }


        public DataTable RetornaTablaCompleta(string sentencia)
        {
            _conexion = new Conexion();

            SqlDataAdapter adaptador = 
                new SqlDataAdapter(
                    RetornaComando(sentencia, _conexion.RetornaConexion()));
            
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }


        public DataTable RetornaTablaEstructura(string nombreTabla)
        {
            _conexion = new Conexion();

            SqlDataAdapter adaptador = 
                new SqlDataAdapter(
                    RetornaComando($"SELECT * FROM {nombreTabla}", _conexion.RetornaConexion()));

            DataTable tabla = new DataTable();
            adaptador.FillSchema(tabla, SchemaType.Mapped);
            return tabla;
        }


        public void ActualizaBase(string nombreTabla, DataTable tabla)
        {
            _conexion = new Conexion();

            SqlDataAdapter adaptador = 
                new SqlDataAdapter(
                    RetornaComando($"SELECT * FROM {nombreTabla}", _conexion.RetornaConexion()));
            
            SqlCommandBuilder builder = new SqlCommandBuilder(adaptador);
            adaptador.InsertCommand = builder.GetInsertCommand();
            adaptador.DeleteCommand = builder.GetDeleteCommand();
            adaptador.UpdateCommand = builder.GetUpdateCommand();

            adaptador.Update(tabla);
        }
    }
}
