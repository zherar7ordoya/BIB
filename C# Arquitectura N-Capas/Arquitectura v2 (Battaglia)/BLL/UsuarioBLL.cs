using System;
using System.Linq;

using TCTD2020.ArquitecturaCapasV2.BE;
using TCTD2020.ArquitecturaCapasV2.DAL;
using TCTD2020.ArquitecturaCapasV2.Servicios;

namespace TCTD2020.ArquitecturaCapasV2.BLL
{
    public class UsuarioBLL : AbstractBLL<Usuario>
    {
        readonly FamiliaBLL _bllFamilias = new FamiliaBLL();
        public UsuarioBLL()
        {
            _crud = new UsuarioDAL();
            SimularDatos();
        }


        private void SimularDatos()
        {
            _bllFamilias.SimularDatos();

            //u1 puede gestionar usuarios
            var usuario = new Usuario
            {
                Email = "u1@mail.com",
                Password = Encriptador.Hash("123")
            };
            var familia = _bllFamilias.GetAll().Where(x => x.Nombre.Contains("Gestores de usuarios")).FirstOrDefault();
            if (familia != null) usuario.Permisos.Add(familia);

            _crud.Save(usuario);

            //u2 puede gestionar permisos
            usuario = new Usuario
            {
                Email = "u2@mail.com",
                Password = Encriptador.Hash("123")
            };
            familia = _bllFamilias.GetAll().Where(x => x.Nombre.Contains("Gestores de permisos")).FirstOrDefault();
            if (familia != null) usuario.Permisos.Add(familia);

            _crud.Save(usuario);

            //admin tiene todo
            usuario = new Usuario
            {
                Email = "admin@mail.com",
                Password = Encriptador.Hash("123")
            };
            familia = _bllFamilias.GetAll().Where(x => x.Nombre.Contains("Administradores")).FirstOrDefault();
            if (familia != null) usuario.Permisos.Add(familia);

            _crud.Save(usuario);
        }

        public LoginResult Login(string email, string password)
        {

            if (SingletonSesion.Instancia.IsLogged())
            {
                throw new Exception("Ya hay una sesión iniciada"); //doble validación, anulo en boton en formulario y valido en la bll
            }

            var user = _crud.GetAll().Where(u => u.Email.Equals(email)).FirstOrDefault();

            if (user == null)
            {
                throw new LoginException(LoginResult.InvalidUsername);
            }

            if (Encriptador.Hash(password).Equals(user.Password))
            {
                SingletonSesion.Instancia.Login(user);
                return LoginResult.ValidUser;
            }
            else
            {
                throw new LoginException(LoginResult.InvalidPassword);
            }


        }

        public void Logout()
        {
            if (!SingletonSesion.Instancia.IsLogged())
            {
                throw new Exception("No hay sesión iniciada"); //doble validación, anulo en boton en formulario y valido en la bll
            }

            SingletonSesion.Instancia.Logout();
        }
    }
}
