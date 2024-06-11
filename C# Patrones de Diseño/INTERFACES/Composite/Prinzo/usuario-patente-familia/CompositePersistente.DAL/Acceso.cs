////////10////////20////////30////////40////////50////////60////////70////////80////////90///////100///////110///////120

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CompositePersistente.DAL
{
    public class Acceso
    {
        //declaro el objeto del tipo conection y uso el constructor para pasar el ConnectionString

        //private String CadenaC= @"Data Source=.\SQLEXPRESS02;Initial Catalog=upf;Integrated Security=True";
        private String CadenaC = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=upf;Integrated Security=True";

        //private SqlConnection oCnn = new SqlConnection(@"Data Source=.\SQLEXPRESS02;Initial Catalog=upf;Integrated Security=True");
        private SqlConnection oCnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=upf;Integrated Security=True");

        //defino el objeto command
        SqlCommand cmd;
        //defino el objeto Transaction
        SqlTransaction Tranx;

        public DataSet Leer(string Consulta, List<SqlParameter> Lparam)
        {
            DataSet Ds = new DataSet();
            SqlDataAdapter Da;
            //paso la consulta y el objeto conection en el constructor
            cmd = new SqlCommand(Consulta, oCnn);
            cmd.CommandType = CommandType.Text;

            try
            {
                Da = new SqlDataAdapter(cmd);

                if ((Lparam != null))
                {
                    //si la el arraylist esta vacia
                    foreach (SqlParameter dato in Lparam)
                    {
                        //cargo los parametros que le estoy pasando con la lista de parametros
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }
            }

            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            Da.Fill(Ds);
            return Ds;

        }

        public int LeerScalar(string Consulta, List<SqlParameter> Lparam)
        {
            oCnn.Open();
            //uso el constructor del objeto Command al instanciar el objeto
            cmd = new SqlCommand(Consulta, oCnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                if ((Lparam != null))
                {
                    foreach (SqlParameter dato in Lparam)
                    {
                        //cargo los parametros que le estoy pasando con el arraylist
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                return Respuesta;
            }
            catch (SqlException ex)
            { throw ex; }
        }




        public bool EscribirV2(string consulta, List<SqlParameter> Lparam)
        {

            if (oCnn.State == ConnectionState.Closed)
            {
                oCnn.ConnectionString = CadenaC;
                oCnn.Open();
            }

            try
            {
                Tranx = oCnn.BeginTransaction();
                //uso el constructor del objeto command
                cmd = new SqlCommand(consulta, oCnn, Tranx);
                cmd.CommandType = CommandType.Text;

                if ((Lparam != null))
                {
                    foreach (SqlParameter dato in Lparam)
                    {
                        //cargo los parametros que le estoy pasando con la lista de SqlParameter
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                int respuesta = cmd.ExecuteNonQuery();
                Tranx.Commit();
                return true;

            }

            catch (SqlException ex)
            {
                Tranx.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                Tranx.Rollback();
                return false;
            }
            finally
            { oCnn.Close(); }


        }

       
    }
}
