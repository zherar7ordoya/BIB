using Patrones.Singleton.Core;

using System;

namespace Patrones.Singleton.UIConsole
{
    class Program
    {
        static void Main()
        {
            Usuario usuario = new Usuario
            {
                Username = "prueba",
                Password = "prueba"
            };

            try
            {
                SessionManager.Login(usuario);
                SessionManager u = SessionManager.GetInstance;
                SessionManager.Logout();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
