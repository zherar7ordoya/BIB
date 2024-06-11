namespace TCTD2020.ArquitecturaCapasV2.Servicios
{
    public class SingletonSesion
    {
        private static Sesion _instancia;
        readonly static object _lock = new object();

        public static Sesion Instancia
         {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null) _instancia = new Sesion(); 
                }
                return _instancia;
            }
        }
    }
}
