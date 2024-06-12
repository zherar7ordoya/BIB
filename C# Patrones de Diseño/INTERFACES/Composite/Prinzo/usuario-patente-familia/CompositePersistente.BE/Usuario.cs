using System.Collections.Generic;

namespace CompositePersistente.BE
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        readonly List<Componente> _permisos;

        // Instancio la lista de componentes que puede tener el usuario
        // (puede ser familia o patentes)
        public Usuario()
        {
            _permisos = new List<Componente>();
        }

        // Los permisos que posee el Usuario solo se leen
        public List<Componente> Permisos
        {
            get { return _permisos; }
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
