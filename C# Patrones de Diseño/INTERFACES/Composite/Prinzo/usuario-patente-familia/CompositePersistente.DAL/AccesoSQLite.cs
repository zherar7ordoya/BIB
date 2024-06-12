using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace CompositePersistente.DAL
{
    public class AccesoSQLite
    {
        readonly string cadena = @"Data Source=UPF.db;Version=3;";
        SQLiteCommand comando;
        SQLiteTransaction transaccion;
        readonly SQLiteConnection conexion;

        public AccesoSQLite()
        {
            conexion = new SQLiteConnection(cadena);
        }


        public DataSet Leer(string query, List<SQLiteParameter> parametros)
        {
            DataSet dataset = new DataSet();
            SQLiteDataAdapter adaptador;

            // Pasar la consulta y el objeto de conexión en el constructor
            comando = new SQLiteCommand(query, conexion)
            {
                CommandType = CommandType.Text
            };

            try
            {
                adaptador = new SQLiteDataAdapter(comando);

                if (parametros != null)
                {
                    foreach (SQLiteParameter parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }
            }
            catch (SQLiteException ex) { throw ex; }
            catch (Exception ex) { throw ex; }

            adaptador.Fill(dataset);
            return dataset;
        }

        /// <summary>
        /// Ejecuta una consulta SQL y devuelve el primer valor de la primera fila del conjunto de resultados como un entero.
        /// </summary>
        /// <param name="query">La cadena de consulta SQL a ejecutar.</param>
        /// <param name="parametros">Lista de parámetros SQL a incluir en la consulta.</param>
        /// <returns>El primer valor de la primera fila del conjunto de resultados convertido a un entero.</returns>
        /// <exception cref="SQLiteException">Se produce si ocurre un error al ejecutar la consulta SQL.</exception>
        public int EjecutarConsultaEscalar(string query, List<SQLiteParameter> parametros)
        {
            conexion.Open();
            // Usar el constructor del objeto Command al instanciar el objeto
            comando = new SQLiteCommand(query, conexion)
            {
                CommandType = CommandType.Text
            };
            try
            {
                if ((parametros != null))
                {
                    foreach (SQLiteParameter parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }
                int retorno = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();
                return retorno;
            }
            catch (SQLiteException ex) { throw ex; }
        }

        public bool Escribir(string query, List<SQLiteParameter> parametros)
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.ConnectionString = cadena;
                conexion.Open();
            }

            try
            {
                transaccion = conexion.BeginTransaction();

                // Usar el constructor del objeto command
                comando = new SQLiteCommand(query, conexion, transaccion)
                {
                    CommandType = CommandType.Text
                };

                if ((parametros != null))
                {
                    foreach (SQLiteParameter parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }

                int retorno = comando.ExecuteNonQuery();
                transaccion.Commit();
                return true;
            }
            catch (SQLiteException)
            {
                transaccion.Rollback();
                return false;
            }
            catch (Exception)
            {
                transaccion.Rollback();
                return false;
            }
            finally { conexion.Close(); }
        }
    }
}
