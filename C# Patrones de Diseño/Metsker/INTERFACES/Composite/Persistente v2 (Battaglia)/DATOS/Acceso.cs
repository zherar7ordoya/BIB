using System;
using System.Data;
//using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SQLite;


namespace DATOS
{

    internal class Acceso
    {

        SQLiteConnection conexion;
        SQLiteTransaction tx;
        public Acceso()
        {


        }

        public void Abrir()
        {
            //string cns = @"Initial Catalog=Composite; Data Source=.;Integrated Security=SSPI";            
            //conexion=new SqlConnection();
            //conexion.ConnectionString=cns;

            string cns = @"Data Source=SQLiteDatabase.db;Version=3;";
            conexion = new SQLiteConnection(cns);

            conexion.Open();
        }

        public void Cerrar()
        {

            conexion.Close();
            conexion.Dispose();
            conexion = null;
            GC.Collect();
        }

        public void ComenzarTransaccion()
        {

            if (tx == null)
            {

                tx = conexion.BeginTransaction();
            }

        }

        public void CancelarTransaccion()
        {

            if (tx != null)
            {

                tx.Rollback();
            }

        }

        public void ConfirmarTransaccion()
        {

            if (tx != null)
            {

                tx.Commit();
            }

        }

        private SQLiteCommand CrearComando(string nombre, List<SQLiteParameter> pars)
        {

            SQLiteCommand cmd = new SQLiteCommand(nombre, conexion);
            if (tx != null)
            {

                cmd.Transaction = tx;
            }

            if (pars != null && pars.Count > 0)
            {

                cmd.Parameters.AddRange(pars.ToArray());
            }

            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        public DataTable Leer(string nombre, List<SQLiteParameter> pars)
        {

            DataTable tabla = new DataTable();
            using (SQLiteDataAdapter da = new SQLiteDataAdapter())
            {

                da.SelectCommand = CrearComando(nombre, pars);
                da.Fill(tabla);
                da.Dispose();
            }

            return tabla;
        }

        public int Escribir(string nombre, List<SQLiteParameter> pars)
        {

            int FilasAfectadas = 0;
            using (SQLiteCommand cmd = CrearComando(nombre, pars))
            {

                try
                {

                    FilasAfectadas = cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {

                    FilasAfectadas = -1;
                }
                cmd.Parameters.Clear();
                cmd.Dispose();
            }

            return FilasAfectadas;
        }

        public object EscribirEscalar(string nombre, List<SQLiteParameter> pars)
        {

            object retorno = null;
            using (SQLiteCommand cmd = CrearComando(nombre, pars))
            {

                try
                {

                    retorno = cmd.ExecuteScalar();
                }

                catch (Exception ex)
                {

                    retorno = "-1";
                }

                cmd.Dispose();
            }

            return retorno;
        }

        public SQLiteParameter CrearParametro(string nombre, string valor)
        {

            SQLiteParameter parametro = new SQLiteParameter(nombre, valor);
            parametro.DbType = DbType.String;
            return parametro;
        }

        public SQLiteParameter CrearParametro(string nombre, int valor)
        {

            SQLiteParameter parametro = new SQLiteParameter(nombre, valor);
            parametro.DbType = DbType.Int32;
            return parametro;
        }

        public SQLiteParameter CrearParametro(string nombre, float valor)
        {

            SQLiteParameter parametro = new SQLiteParameter(nombre, valor);
            parametro.DbType = DbType.Single;
            return parametro;
        }

        public SQLiteParameter CrearParametro(string nombre, long valor)
        {

            SQLiteParameter parametro = new SQLiteParameter(nombre, valor);
            parametro.DbType = DbType.Int64;
            return parametro;
        }

    }

}

