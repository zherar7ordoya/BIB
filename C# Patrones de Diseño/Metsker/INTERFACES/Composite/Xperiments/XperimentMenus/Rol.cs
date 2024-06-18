using System.Collections.Generic;

namespace Paso5
{
    public class Rol : IComposite
    {
        private readonly string nombre;
        private readonly List<IComposite> nodos;

        public Rol(string nombre)
        {
            this.nombre = nombre;
            this.nodos = new List<IComposite>();
        }

        public string ObtenerNombre()
        {
            return nombre;
        }

        public void AgregarNodo(IComposite nodo)
        {
            nodos.Add(nodo);
        }

        public void QuitarNodo(IComposite nodo)
        {
            nodos.Remove(nodo);
        }

        public IEnumerable<IComposite> ObtenerNodos()
        {
            return nodos;
        }
    }
}
