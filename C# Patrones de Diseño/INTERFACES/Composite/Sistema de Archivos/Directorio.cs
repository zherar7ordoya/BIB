using System.Collections.Generic;

namespace CompositeSistemaDeArchivos
{
    public class Directorio : Componente
    {
        readonly List<Componente> _hijos;

        public override int Tamaño
        {
            get
            {
                int tamaño = 0;
                foreach (var item in _hijos) { tamaño += item.Tamaño; }
                return tamaño;
            }
        }

        public Directorio(string nombre) : base(nombre)
        {
            _hijos = new List<Componente>();
        }

        public override void AgregarHijo(Componente componente)
        {
            _hijos.Add(componente);
        }

        public override IList<Componente> ObtenerHijos()
        {
            return _hijos.ToArray();
        }

        /*--------------------------------------------------------------------*/
    }
}
