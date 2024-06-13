using System;
using System.Collections.Generic;
using System.Linq;
using CompositePersistente.BE;
using CompositePersistente.DAL;
using System.Data;
//using System.Data.SqlClient;
using System.Data.SQLite;


namespace CompositePersistente.MPP
{
    public class MPPPermiso
    {

        //AccesoSqlServer oDatos;
        AccesoSQLite oDatos;
        public Array GetAllPermission()
        {
            return Enum.GetValues(typeof(ETipoPermiso));
        }


        public Componente GuardarComponente(Componente oComp, bool esfamilia)
        {
            try
            {
                string consulta_sql = $@"INSERT INTO permiso (nombre,permiso) VALUES (@nombre,@permiso)";

                //List<SqlParameter> LParametros = new List<SqlParameter>();
                List<SQLiteParameter> LParametros = new List<SQLiteParameter>();
                //LParametros.Add(new SqlParameter("nombre", oComp.Nombre));
                LParametros.Add(new SQLiteParameter("nombre", oComp.Nombre));


                if (esfamilia)
                    //LParametros.Add(new SqlParameter("permiso", DBNull.Value));
                    LParametros.Add(new SQLiteParameter("permiso", DBNull.Value));

                else
                    //LParametros.Add(new SqlParameter("permiso", oComp.Permiso.ToString()));
                    LParametros.Add(new SQLiteParameter("permiso", oComp.Permiso.ToString()));

                oDatos.Escribir(consulta_sql, LParametros);

                string consulta_sql2 = "SELECT ID AS LastID FROM permiso WHERE ID = @@Identity";


                var id = oDatos.EjecutarConsultaEscalar(consulta_sql2, null);
                oComp.Id = (int)id;
                return oComp;
            }
            catch (Exception e)
            {


                throw e;
            }

        }


        public bool GuardarFamilia(Familia oBEFamilia)
        {


            try
            {
                bool RTA = false;

                var Sql = $@"delete from permiso_permiso where id_permiso_padre=@id";

                //List<SqlParameter> LParametros1 = new List<SqlParameter>();
                List<SQLiteParameter> LParametros1 = new List<SQLiteParameter>();


                //LParametros1.Add(new SqlParameter("id", oBEFamilia.Id));
                LParametros1.Add(new SQLiteParameter("id", oBEFamilia.Id));
                oDatos.Escribir(Sql, LParametros1);

                foreach (var item in oBEFamilia.Hijos)
                {
                    string Sql2 = $@"insert into permiso_permiso (id_permiso_padre,id_permiso_hijo) values (@id_permiso_padre,@id_permiso_hijo) ";

                    //List<SqlParameter> LParametros2 = new List<SqlParameter>();
                    List<SQLiteParameter> LParametros2 = new List<SQLiteParameter>();

                    //LParametros2.Add(new SqlParameter("id_permiso_padre", oBEFamilia.Id));
                    LParametros2.Add(new SQLiteParameter("id_permiso_padre", oBEFamilia.Id));
                    //LParametros2.Add(new SqlParameter("id_permiso_hijo", item.Id));
                    LParametros2.Add(new SQLiteParameter("id_permiso_hijo", item.Id));

                    //AccesoSqlServer oDatos2 = new AccesoSqlServer();
                    AccesoSQLite oDatos2 = new AccesoSQLite();
                    RTA = oDatos2.Escribir(Sql2, LParametros2); ;
                }
                return RTA;
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }


        public IList<Patente> GetAllPatentes()
        {

            //instancio un objeto de la clase datos para operar con la BD
            List<Patente> ListaPatente = new List<Patente>();
            //Declaro el objeto DataSet para guardar los datos y luego pasarlos a lista
            DataSet Ds;
            string Consulta = "select * from permiso p where p.permiso is not null";
            //oDatos = new AccesoSqlServer();
            oDatos = new AccesoSQLite();
            Ds = oDatos.Leer(Consulta, null);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    Patente oBEPat = new Patente();
                    oBEPat.Id = Convert.ToInt32(fila["id"]);
                    oBEPat.Nombre = fila["nombre"].ToString();
                    var permisop = fila["permiso"].ToString();
                    oBEPat.Permiso = (ETipoPermiso)Enum.Parse(typeof(ETipoPermiso), permisop);
                    ListaPatente.Add(oBEPat);
                }
            }

            return ListaPatente;
        }

        // GetAllFamilias

        public List<Familia> GetAllFamilias()
        {  //instancio un objeto de la clase datos para operar con la BD
            List<Familia> ListaFamilia = new List<Familia>();
            //Declaro el objeto DataSet para guardar los datos y luego pasarlos a lista
            DataSet Ds;
            //si el permiso es null entonces es un familia
            string Consulta = "select * from permiso p where p.permiso is null";
            //oDatos = new AccesoSqlServer();
            oDatos = new AccesoSQLite();
            Ds = oDatos.Leer(Consulta, null);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    Familia oBEFam = new Familia();
                    oBEFam.Id = Convert.ToInt32(fila["id"]);
                    oBEFam.Nombre = fila["nombre"].ToString();
                    ListaFamilia.Add(oBEFam);
                }
            }


            return ListaFamilia;
        }


        public IList<Componente> GetAll(string familia)
        {
            var where = "is NULL";
            if (!string.IsNullOrEmpty(familia))
            {
                where = familia;
            }

            //string query = $@"with recursivo as (
            //                select sp2.id_permiso_padre, sp2.id_permiso_hijo  from permiso_permiso SP2
            //                where sp2.id_permiso_padre {where} --acá se va variando la familia que busco
            //                UNION ALL 
            //                select sp.id_permiso_padre, sp.id_permiso_hijo from permiso_permiso sp 
            //                inner join recursivo r on r.id_permiso_hijo= sp.id_permiso_padre
            //                 )
            //               select r.id_permiso_padre,r.id_permiso_hijo,p.id,p.nombre, p.permiso
            //               from recursivo r 
            //               inner join permiso p on r.id_permiso_hijo = p.id 
            //               ";

            string query =
$@"WITH JerarquiaPermisos AS
(
    SELECT
        permiso_permiso.id_permiso_padre,
        permiso_permiso.id_permiso_hijo
    FROM
        permiso_permiso
    WHERE
        permiso_permiso.id_permiso_padre {where} -- acá se va variando la familia que busco
    UNION
    ALL
    SELECT
        permiso_permiso.id_permiso_padre,
        permiso_permiso.id_permiso_hijo
    FROM
        permiso_permiso
        INNER JOIN JerarquiaPermisos
        ON JerarquiaPermisos.id_permiso_hijo = permiso_permiso.id_permiso_padre
)
SELECT
    JerarquiaPermisos.id_permiso_padre,
    JerarquiaPermisos.id_permiso_hijo,
    permiso.id,
    permiso.nombre,
    permiso.permiso
FROM
    JerarquiaPermisos
    INNER JOIN permiso
    ON JerarquiaPermisos.id_permiso_hijo = permiso.id";

            List<Componente> componentes = new List<Componente>();
            DataSet dataset;
            dataset = oDatos.Leer(query, null);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataset.Tables[0].Rows)
                {
                    int id_padre = 0;
                    var id = Convert.ToInt32(fila["id"]);
                    var nombre = fila["nombre"].ToString();
                    var permiso = string.Empty;
                    if (fila["permiso"] != DBNull.Value)
                        permiso = fila["permiso"].ToString();
                    Componente componente;
                    if (string.IsNullOrEmpty(permiso))
                        componente = new Familia();
                    else
                        componente = new Patente();
                    componente.Id = id;
                    componente.Nombre = nombre;
                    if (!string.IsNullOrEmpty(permiso))
                        componente.Permiso = (ETipoPermiso)Enum.Parse(typeof(ETipoPermiso), permiso);
                    var padre = GetComponent(id_padre, componentes);
                    if (padre == null)
                    {
                        componentes.Add(componente);
                    }
                    else
                    {
                        padre.AgregarHijo(componente);
                    }
                }
            }
            return componentes;
        }


        private Componente GetComponent(int id, IList<Componente> Lista)
        {

            Componente component = Lista != null ? Lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && Lista != null)
            {
                foreach (var c in Lista)
                {

                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);

                }
            }



            return component;



        }

        public void FillUserComponents(Usuario oBEUsu)
        {

            string Consulta = "select p.* from usuarios_permisos up inner join permiso p on up.id_permiso=p.id where id_usuario=@id";

            //List<SqlParameter> LParametros = new List<SqlParameter>();
            List<SQLiteParameter> LParametros = new List<SQLiteParameter>();
            //LParametros.Add(new SqlParameter("id", oBEUsu.Id));
            LParametros.Add(new SQLiteParameter("id", oBEUsu.Id));
            DataSet Ds;
            //oDatos = new AccesoSqlServer();
            oDatos = new AccesoSQLite();
            Ds = oDatos.Leer(Consulta, LParametros);

            oBEUsu.Permisos.Clear();

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    int idp = Convert.ToInt32(fila["id"]);
                    string nombrep = fila["nombre"].ToString();
                    string permisop = String.Empty;

                    if (fila["permiso"] != DBNull.Value)
                        permisop = fila["permiso"].ToString();

                    Componente c1;

                    if (!string.IsNullOrEmpty(permisop))
                    {
                        c1 = new Patente();
                        c1.Id = idp;
                        c1.Nombre = nombrep;
                        c1.Permiso = (ETipoPermiso)Enum.Parse(typeof(ETipoPermiso), permisop);
                        oBEUsu.Permisos.Add(c1);
                    }
                    else
                    {
                        c1 = new Familia();
                        c1.Id = idp;
                        c1.Nombre = nombrep;

                        var f = GetAll("=" + idp);

                        foreach (var familia in f)
                        {
                            c1.AgregarHijo(familia);
                        }
                        oBEUsu.Permisos.Add(c1);
                    }

                }

            }


        }
        public void FillFamilyComponents(Familia oFamilia)
        {
            oFamilia.VaciarHijos();
            foreach (var item in GetAll("=" + oFamilia.Id))
            {
                oFamilia.AgregarHijo(item);
            }
        }

    }
}
