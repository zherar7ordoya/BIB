using System.Collections.Generic;

namespace CompositeSistemaDeArchivos
{
    public class Archivo : Componente
    {
        readonly int _tamaño;

        public override int Tamaño
        {
            get
            {
                return _tamaño;
            }
        }

        public Archivo(string nombre, int tamaño) : base(nombre)
        {
            _tamaño = tamaño;
        }

        public override void AgregarHijo(Componente componente) { }

        public override IList<Componente> ObtenerHijos()
        {
            return null;
        }

        /*--------------------------------------------------------------------*/
    }
}
