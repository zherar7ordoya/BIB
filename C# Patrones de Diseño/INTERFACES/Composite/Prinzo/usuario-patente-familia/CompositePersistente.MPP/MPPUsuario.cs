using System;
using System.Collections.Generic;
using CompositePersistente.BE;
using CompositePersistente.DAL;
using System.Data;
using System.Data.SqlClient;

namespace CompositePersistente.MPP
{
    public class MPPUsuario
    {
              
        Acceso oDatos;
        //convierto a Lista lo que traigo del Dataset
        public List<BEUsuario> GetAll()
        {  //instancio un objeto de la clase datos para operar con la BD
            List<BEUsuario> ListaUsuarios = new List<BEUsuario>();
            //Declaro el objeto DataSet para guardar los datos y luego pasarlos a lista
            DataSet Ds;
            string Consulta = "select * from usuarios";
            oDatos = new Acceso();
            Ds = oDatos.Leer(Consulta, null);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BEUsuario oBEUsu = new BEUsuario();
                    oBEUsu.Id = Convert.ToInt32(fila[0]);
                    oBEUsu.Nombre = fila[1].ToString();
                    ListaUsuarios.Add(oBEUsu);
                }
            }
  
            return ListaUsuarios;
        }
        public bool GuardarPermisos(BEUsuario oBEUsu)
        {   //porque borras antes si podes consultar y no duplicar el permiso y usuario
            string Consulta_SQL = "DELETE FROM usuarios_permisos WHERE id_usuario= @id_usuario";

            bool RTA = false;

            List<SqlParameter> LParametros1 = new List<SqlParameter>();
          
            LParametros1.Add(new SqlParameter("id_usuario", oBEUsu.Id));

            oDatos.EscribirV2(Consulta_SQL, LParametros1);

            

            foreach (var item in oBEUsu.Permisos)
            {

                List<SqlParameter> LParametros2 = new List<SqlParameter>();

                Consulta_SQL = "INSERT INTO usuarios_permisos (id_usuario,id_permiso) VALUES (@id_usuario,@id_permiso) "; 
                
                LParametros2.Add(new SqlParameter("id_usuario", oBEUsu.Id));
                LParametros2.Add(new SqlParameter("id_permiso", item.Id));

                Acceso oDatos2 = new Acceso();
                RTA = oDatos2.EscribirV2(Consulta_SQL, LParametros2);
            }

            return RTA;
        }



    }

}

