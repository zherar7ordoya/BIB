using System.Collections.Generic;

namespace CompositePersistente.BE
{
    public class BEUsuario
    {



        #region "Propiedades_del_Usuario"
        public int Id { get; set; }
        public string Nombre { get; set; }


        List<BEComponente> _permisos;

        #endregion

        //Intancio la lista de componentes q puede tener el usuario puer ser familia o patentes
        public BEUsuario()
        {
            _permisos = new List<BEComponente>();
        }

        //SOlo se lee los permisos que posee el Usuario
        public List<BEComponente> Permisos
        {
            get
            {
                return _permisos;
            }
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
