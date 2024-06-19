using System;

namespace Patrones.Singleton.Core
{
    public class SessionManager
    {
        // "Lock" se usa en entornos multi-hilo. Por lo tanto, no es necesario
        // en este contexto (escritorio).
        private static readonly object _lock = new object();
        //**********************************************************************

        private static SessionManager _session;
        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }

        private SessionManager()
        {
        }

        public static SessionManager GetInstance
        {
            get
            {
                if (_session == null)
                {
                    throw new Exception("Sesión no iniciada");
                }
                return _session;
            }
        }

        public static void Login(Usuario usuario)
        {
            lock (_lock)
            {
                if (_session == null)
                {
                    _session = new SessionManager
                    {
                        Usuario = usuario,
                        FechaInicio = DateTime.Now
                    };
                }
                else
                {
                    throw new Exception("Sesión ya iniciada");
                }
            }
        }

        public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }
    }
}
