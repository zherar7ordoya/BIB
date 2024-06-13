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
        AccesoSQLite accesoSqlite;
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

                accesoSqlite.Escribir(consulta_sql, LParametros);

                string consulta_sql2 = "SELECT ID AS LastID FROM permiso WHERE ID = @@Identity";


                var id = accesoSqlite.EjecutarConsultaEscalar(consulta_sql2, null);
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
                accesoSqlite.Escribir(Sql, LParametros1);

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
            accesoSqlite = new AccesoSQLite();
            Ds = accesoSqlite.Leer(Consulta, null);

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
            accesoSqlite = new AccesoSQLite();
            Ds = accesoSqlite.Leer(Consulta, null);

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
            dataset = accesoSqlite.Leer(query, null);
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
                    var padre = ObtenerComponente(id_padre, componentes);
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


        //private Componente GetComponent(int id, IList<Componente> componentes)
        //{
        //    Componente componente = componentes?.Where(i => i.Id.Equals(id)).FirstOrDefault();
        //    if (componente == null && componentes != null)
        //    {
        //        foreach (var item in componentes)
        //        {
        //            var l = GetComponent(id, item.Hijos);
        //            if (l != null && l.Id == id)
        //            {
        //                return l;
        //            }
        //            else
        //            {
        //                if (l != null)
        //                {
        //                    return GetComponent(id, l.Hijos);
        //                }
        //            }
        //        }
        //    }
        //    return componente;
        //}


        // Método para buscar un componente por su ID en una lista de componentes, incluyendo recursivamente sus hijos.
        private Componente ObtenerComponente(int idComponente, IList<Componente> listaComponentes)
        {
            // Intentar encontrar el componente con el ID especificado en la lista principal.
            Componente componenteEncontrado = 
                listaComponentes?
                .Where(componente => componente.Id.Equals(idComponente))
                .FirstOrDefault();

            // Si no se encuentra en la lista principal y la lista no es nula.
            if (componenteEncontrado == null && listaComponentes != null)
            {
                // Iterar sobre cada componente en la lista principal.
                foreach (var componenteActual in listaComponentes)
        {
                    // Llamar recursivamente para buscar el componente en los hijos del componente actual.
                    Componente componenteHijo = 
                        ObtenerComponente(idComponente, componenteActual.Hijos);

                    // Si se encuentra el componente con el ID especificado, retornarlo.
                    if (componenteHijo != null && componenteHijo.Id == idComponente)
                    {
                        return componenteHijo;
                    }
                    else
                    {
                        // Si se encuentra algún componente pero no con el ID especificado,
                        // seguir buscando recursivamente en sus hijos.
                        if (componenteHijo != null)
                        {
                            return ObtenerComponente(idComponente, componenteHijo.Hijos);
                        }
                    }
                }
            }

            // Retornar el componente encontrado, o null si no se encontró.
            return componenteEncontrado;
        }


        public void FillUserComponents(Usuario usuario)
        {
            // Consulta SQL: Se refiere específicamente a una instrucción SQL válida.
            string consultaSql =
@"-- Selecciona todas las columnas de la tabla permiso.
SELECT
    permiso.*
-- Se realiza una unión interna (INNER JOIN) entre las tablas usuarios_permisos
-- y permiso donde la columna id_permiso de usuarios_permisos coincide con la
-- columna id de permiso.
FROM
    usuarios_permisos
    INNER JOIN permiso ON usuarios_permisos.id_permiso = permiso.id
-- Filtra los resultados para incluir solo aquellos registros donde id_usuario
-- en la tabla usuarios_permisos es igual al parámetro @id.
WHERE
    usuarios_permisos.id_usuario = @id";

            List<SQLiteParameter> parametros = new List<SQLiteParameter>
            {
                new SQLiteParameter("id", usuario.Id)
            };

            DataSet dataset;

            accesoSqlite = new AccesoSQLite();
            dataset = accesoSqlite.Leer(consultaSql, parametros);
            usuario.Permisos.Clear();

            if (dataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataset.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(fila["id"]);
                    string nombre = fila["nombre"].ToString();
                    string permiso = string.Empty;

                    if (fila["permiso"] != DBNull.Value)
                    {
                        permiso = fila["permiso"].ToString();
                    }

                    Componente componente;

                    if (!string.IsNullOrEmpty(permiso))
                    {
                        componente = new Patente
                        {
                            Id = id,
                            Nombre = nombre,
                            Permiso = (ETipoPermiso)Enum.Parse(typeof(ETipoPermiso), permiso)
                        };

                        usuario.Permisos.Add(componente);
                    }
                    else
                    {
                        componente = new Familia
                        {
                            Id = id,
                            Nombre = nombre
                        };

                        var familias = GetAll("=" + id);

                        foreach (var familia in familias)
                        {
                            componente.AgregarHijo(familia);
                        }
                        usuario.Permisos.Add(componente);
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
