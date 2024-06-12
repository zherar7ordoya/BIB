namespace CompositePersistente.BE
{
    public class SimuladorSesion
    {
        // Simulo la sesión de Usuario (login, logout, menú habilitado)
        static SimuladorSesion _sesion;
        Usuario _usuario;

        public static SimuladorSesion GetInstance
        {
            get
            {
                if (_sesion == null) _sesion = new SimuladorSesion();
                return _sesion;
            }
        }

        private SimuladorSesion() { }


        public void Login(Usuario usuario) => _sesion._usuario = usuario;
        public bool IsLoggedIn() => _usuario != null;
        public void Logout() => _sesion._usuario = null;

        
        public bool ExistInRole(ETipoPermiso tipoPermiso)
        {
            bool existe = false;
            foreach (var permiso in _usuario.Permisos)
            {
                if (permiso.Permiso.Equals(tipoPermiso)) return true;
                else
                {
                    existe = ExistInRole(permiso, tipoPermiso, existe);
                    if (existe) return true;
                }
            }
            return existe;
        }

        bool ExistInRole(Componente componente, ETipoPermiso tipoPermiso, bool existe)
        {
            if (componente.Permiso.Equals(tipoPermiso)) existe = true;
            else
            {
                foreach (var hijo in componente.Hijos)
                {
                    existe = ExistInRole(hijo, tipoPermiso, existe);
                    if (existe) return true;
                }
            }
            return existe;
        }
    }
}
