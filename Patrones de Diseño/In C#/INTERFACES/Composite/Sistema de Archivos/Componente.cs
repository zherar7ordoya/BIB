using System.Collections.Generic;

namespace CompositeSistemaDeArchivos
{
    public abstract class Componente
    {
        // Campo
        readonly string _nombre;

        // Propiedad
        public string Nombre { get { return _nombre; } }

        // Propiedad abstracta (es decir, la clase que herede deberá implementar)
        public abstract int Tamaño { get; }

        // Constructor
        public Componente(string nombre)
        {
            _nombre = nombre;
        }

        // Métodos abstractos (es decir, la clase que herede deberá implementar)
        public abstract void AgregarHijo(Componente componente);
        public abstract IList<Componente> ObtenerHijos();
    }
}
    