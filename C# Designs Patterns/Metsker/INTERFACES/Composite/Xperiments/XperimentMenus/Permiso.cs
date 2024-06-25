using System;
using System.Collections.Generic;
using System.Linq;

namespace Paso5
{
    public class Permiso : IComposite
    {
        private string nombre;

        public Permiso(string nombre)
        {
            this.nombre = nombre;
        }

        public string ObtenerNombre()
        {
            return nombre;
        }

        public void AgregarNodo(IComposite nodo)
        {
            throw new InvalidOperationException("No se pueden agregar nodos a un permiso.");
        }

        public void QuitarNodo(IComposite nodo)
        {
            throw new InvalidOperationException("No se pueden quitar nodos de un permiso.");
        }

        public IEnumerable<IComposite> ObtenerNodos()
        {
            return Enumerable.Empty<IComposite>();
        }
    }
}
