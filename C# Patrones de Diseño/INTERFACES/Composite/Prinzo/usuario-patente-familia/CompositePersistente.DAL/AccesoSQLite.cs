using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace CompositePersistente.DAL
{
    public class AccesoSQLite
    {
        // Declarar la cadena de conexión a la base de datos SQLite
        readonly string CadenaC = @"Data Source=UPF.db;Version=3;";

        // Crear el objeto de conexión SQLite
        readonly SQLiteConnection oCnn = new SQLiteConnection(@"Data Source=UPF.db;Version=3;");

        // Definir el objeto command
        SQLiteCommand cmd;
        // Definir el objeto Transaction
        SQLiteTransaction Tranx;

        public DataSet Leer(string Consulta, List<SQLiteParameter> Lparam)
        {
            DataSet Ds = new DataSet();
            SQLiteDataAdapter Da;
            // Pasar la consulta y el objeto de conexión en el constructor
            cmd = new SQLiteCommand(Consulta, oCnn)
            {
                CommandType = CommandType.Text
            };

            try
            {
                Da = new SQLiteDataAdapter(cmd);

                if ((Lparam != null))
                {
                    // Si la lista de parámetros no está vacía
                    foreach (SQLiteParameter dato in Lparam)
                    {
                        // Cargar los parámetros que se están pasando con la lista de parámetros
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }
            }
            catch (SQLiteException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }

            Da.Fill(Ds);
            return Ds;
        }

        public int LeerScalar(string Consulta, List<SQLiteParameter> Lparam)
        {
            oCnn.Open();
            // Usar el constructor del objeto Command al instanciar el objeto
            cmd = new SQLiteCommand(Consulta, oCnn)
            {
                CommandType = CommandType.Text
            };
            try
            {
                if ((Lparam != null))
                {
                    foreach (SQLiteParameter dato in Lparam)
                    {
                        // Cargar los parámetros que se están pasando con la lista de parámetros
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                return Respuesta;
            }
            catch (SQLiteException ex)
            { throw ex; }
        }

        public bool EscribirV2(string consulta, List<SQLiteParameter> Lparam)
        {
            if (oCnn.State == ConnectionState.Closed)
            {
                oCnn.ConnectionString = CadenaC;
                oCnn.Open();
            }

            try
            {
                Tranx = oCnn.BeginTransaction();
                // Usar el constructor del objeto command
                cmd = new SQLiteCommand(consulta, oCnn, Tranx)
                {
                    CommandType = CommandType.Text
                };

                if ((Lparam != null))
                {
                    foreach (SQLiteParameter dato in Lparam)
                    {
                        // Cargar los parámetros que se están pasando con la lista de parámetros
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                int respuesta = cmd.ExecuteNonQuery();
                Tranx.Commit();
                return true;
            }
            catch (SQLiteException)
            {
                Tranx.Rollback();
                return false;
            }
            catch (Exception)
            {
                Tranx.Rollback();
                return false;
            }
            finally
            { oCnn.Close(); }
        }
    }
}
