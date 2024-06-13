﻿using BE;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_User : Mapper<User>
    {
        public override User Transform(DataRow dr)
        {
            User user = new BE.User();
            user.ID = Guid.Parse( dr["ID"].ToString());
            user.Username = dr["USERNAME"].ToString();
            user.Password = dr["PASSWORD"].ToString();
            user.DNI = CryptoManager.Decrypt(dr["DNI"].ToString());
            user.Nombre = dr["NOMBRE"].ToString();
            user.Apellido = dr["APELLIDO"].ToString();
            user.Email = dr["EMAIL"].ToString();
            user.Activo = bool.Parse(dr["ACTIVO"].ToString());
            user.Bloqueo = bool.Parse(dr["BLOQUEO"].ToString());
            user.Attempts = int.Parse(dr["INTENTOS"].ToString());

            return user;
        }

        public override int Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public override List<User> GetAll()
        {
            List<User> users = new List<User>();

            access.Open();
            DataTable dt = access.Read("LISTAR_USUARIO");
            access.Close();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(Transform(dr));
            }
            return users;
        }

        public override User GetById(object id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(User entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                access.CreateParameter("@username", entity.Username),
                access.CreateParameter("@password", entity.Password),
                access.CreateParameter("@dni", entity.DNI),
                access.CreateParameter("@nom", entity.Nombre),
                access.CreateParameter("@ape", entity.Apellido),
                access.CreateParameter("@email", entity.Email),
            };

            access.Open();
            int filasAfectadas = access.Write("INSERTAR_USUARIO", parameters);
            access.Close();

            return filasAfectadas;
        }

        public override int Update(User entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                access.CreateParameter("@id", entity.ID),
                access.CreateParameter("@username", entity.Username),
                access.CreateParameter("@dni", entity.DNI),
                access.CreateParameter("@nom", entity.Nombre),
                access.CreateParameter("@ape", entity.Apellido),
                access.CreateParameter("@email", entity.Email),
                access.CreateParameter("@intentos", entity.Attempts)
            };

            access.Open();
            int filasAfectadas = access.Write("ACTUALIZAR_USUARIO", parameters);
            access.Close();

            return filasAfectadas;
        }

        public int ChangeBlockage(User entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                access.CreateParameter("@id", entity.ID),
                access.CreateParameter("@bloqueo", entity.Bloqueo),
                access.CreateParameter("@intentos", entity.Attempts),
            };

            access.Open();
            int filasAfectadas = access.Write("CAMBIAR_BLOQUEO", parameters);
            access.Close();

            return filasAfectadas;
        }

        MP_Permission mpPermission = new MP_Permission();

        public void AsignPermissions(User entity)
        {

            List<Component> permissionsList = mpPermission.GetAll();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                access.CreateParameter("@id", entity.ID)
            };
            access.Open();
            DataTable dt = access.Read("LISTAR_USUARIO_PERMISO", parameters);
            access.Close();

            foreach (DataRow row in dt.Rows)
            {
                entity.Permissions.Add((from component in permissionsList 
                                            where component.ID.Equals(int.Parse(row["ID_PERMISO"].ToString())) 
                                            select component).FirstOrDefault());
            }

        }

        public int ChangePassword(User entity)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>()
            {
                access.CreateParameter("@id", entity.ID),
                access.CreateParameter("@pass", entity.Password)
            };

            access.Open();
            int filasAfectadas = access.Write("MODIFICAR_PASSWORD", parameterList);
            access.Close();

            return filasAfectadas;

        }

        public void UpdatePermissions(User entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                access.CreateParameter("@id", entity.ID)
            };

            access.Open();
            int filasAfectadas = access.Write("ELIMINAR_USUARIO_PERMISO", parameters);
            
            if (filasAfectadas!=-1)
            {
                List<SqlParameter> parameters2;
                foreach (var entityPermission in entity.Permissions)
                {
                    parameters2 = new List<SqlParameter>()
                    {
                        access.CreateParameter("@id_usuario", entity.ID),
                        access.CreateParameter("@id_permiso", entityPermission.ID)
                    };

                    access.Write("INSERTAR_USUARIO_PERMISO", parameters2);


                }
            }
            access.Close();

        }
    }
}
