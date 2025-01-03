﻿using System;
using System.Collections.Generic;
using CompositePersistente.BE;
using CompositePersistente.DAL;
using System.Data;
//using System.Data.SqlClient;
using System.Data.SQLite;


namespace CompositePersistente.MPP
{
    public class MPPUsuario
    {

        //AccesoSqlServer oDatos;
        AccesoSQLite oDatos;


        //convierto a Lista lo que traigo del Dataset
        public List<Usuario> GetAll()
        {  //instancio un objeto de la clase datos para operar con la BD
            List<Usuario> ListaUsuarios = new List<Usuario>();
            //Declaro el objeto DataSet para guardar los datos y luego pasarlos a lista
            DataSet Ds;
            string Consulta = "select * from usuarios";
            //oDatos = new AccesoSqlServer();
            oDatos = new AccesoSQLite();
            Ds = oDatos.Leer(Consulta, null);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    Usuario oBEUsu = new Usuario();
                    oBEUsu.Id = Convert.ToInt32(fila[0]);
                    oBEUsu.Nombre = fila[1].ToString();
                    ListaUsuarios.Add(oBEUsu);
                }
            }
  
            return ListaUsuarios;
        }
        public bool GuardarPermisos(Usuario oBEUsu)
        {   //porque borras antes si podes consultar y no duplicar el permiso y usuario
            string Consulta_SQL = "DELETE FROM usuarios_permisos WHERE id_usuario= @id_usuario";

            bool RTA = false;

            //List<SqlParameter> LParametros1 = new List<SqlParameter>();
            List<SQLiteParameter> LParametros1 = new List<SQLiteParameter>
            {
                //LParametros1.Add(new SqlParameter("id_usuario", oBEUsu.Id));
                new SQLiteParameter("id_usuario", oBEUsu.Id)
            };

            oDatos.Escribir(Consulta_SQL, LParametros1);

            

            foreach (var item in oBEUsu.Permisos)
            {

                //List<SqlParameter> LParametros2 = new List<SqlParameter>();
                List<SQLiteParameter> LParametros2 = new List<SQLiteParameter>();

                Consulta_SQL = "INSERT INTO usuarios_permisos (id_usuario,id_permiso) VALUES (@id_usuario,@id_permiso) "; 
                
                LParametros2.Add(new SQLiteParameter("id_usuario", oBEUsu.Id));
                LParametros2.Add(new SQLiteParameter("id_permiso", item.Id));

                //AccesoSqlServer oDatos2 = new AccesoSqlServer();
                AccesoSQLite oDatos2 = new AccesoSQLite();
                RTA = oDatos2.Escribir(Consulta_SQL, LParametros2);
            }

            return RTA;
        }



    }

}

