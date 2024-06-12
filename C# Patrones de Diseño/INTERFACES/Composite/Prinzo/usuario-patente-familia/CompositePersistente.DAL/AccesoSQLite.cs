using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace CompositePersistente.DAL
{
    public class AccesoSQLite
    {
        private readonly string cadena = @"Data Source=SQLiteDatabase.db;Version=3;";
        private readonly SQLiteConnection conexion;

        public AccesoSQLite()
        {
            conexion = new SQLiteConnection(cadena);
        }

        /// <summary>
        /// Ejecuta una consulta SQL y devuelve los resultados en un DataSet.
        /// </summary>
        /// <param name="query">La cadena de consulta SQL a ejecutar.</param>
        /// <param name="parametros">Lista de parámetros SQL a incluir en la consulta.</param>
        /// <returns>Un DataSet con los resultados de la consulta.</returns>
        /// <exception cref="SQLiteException">Se produce si ocurre un error al ejecutar la consulta SQL.</exception>
        public DataSet Leer(string query, List<SQLiteParameter> parametros)
        {
            var dataset = new DataSet();

            using (var comando = new SQLiteCommand(query, conexion))
            {
                comando.CommandType = CommandType.Text;
                Tool.AgregarParametros(comando, parametros);

                try
                {
                    using (var adaptador = new SQLiteDataAdapter(comando))
                    {
                        adaptador.Fill(dataset);
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new DataAccessException("Error al ejecutar la consulta SQL.", ex);
                }
                catch (Exception ex)
                {
                    throw new DataAccessException("Ocurrió un error inesperado.", ex);
                }
            }

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
            using (var conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                using (var comando = new SQLiteCommand(query, conexion))
                {
                    comando.CommandType = CommandType.Text;
                    Tool.AgregarParametros(comando, parametros);

                    try
                    {
                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                    catch (SQLiteException ex)
                    {
                        throw new DataAccessException("Error al ejecutar la consulta SQL.", ex);
                    }
                    catch (Exception ex)
                    {
                        throw new DataAccessException("Ocurrió un error inesperado.", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Ejecuta una consulta SQL para escribir datos en la base de datos.
        /// </summary>
        /// <param name="query">La cadena de consulta SQL a ejecutar.</param>
        /// <param name="parametros">Lista de parámetros SQL a incluir en la consulta.</param>
        /// <returns>True si la operación se realizó con éxito; False en caso contrario.</returns>
        /// <exception cref="SQLiteException">Se produce si ocurre un error al ejecutar la consulta SQL.</exception>
        public bool Escribir(string query, List<SQLiteParameter> parametros)
        {
            using (var conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                using (var transaccion = conexion.BeginTransaction())
                {
                    using (var comando = new SQLiteCommand(query, conexion, transaccion))
                    {
                        comando.CommandType = CommandType.Text;
                        Tool.AgregarParametros(comando, parametros);

                        try
                        {
                            comando.ExecuteNonQuery();
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
                    }
                }
            }
        }
    }
}
