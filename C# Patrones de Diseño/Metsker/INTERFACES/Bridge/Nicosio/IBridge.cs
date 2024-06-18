using System.Collections.Generic;

namespace Bridge
{
    public interface IBridge
    {
        void MostrarTotales(Dictionary<string, double> productos);
        void ListarProductos(Dictionary<string, double> productos);
    }
}