using System.Collections.Generic;

namespace Paso5
{
    public interface IComposite
    {
        string ObtenerNombre();
        void AgregarNodo(IComposite nodo);
        void QuitarNodo(IComposite nodo);
        IEnumerable<IComposite> ObtenerNodos();
        void LimpiarNodos(); // Nuevo método para limpiar nodos
    }
}
