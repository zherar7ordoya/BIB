using System.Collections.Generic;

namespace Bridge
{
    public class Abstraction
    {
        readonly IBridge _implementacion;
        readonly Dictionary<string, double> _productos;

        public Abstraction(IBridge implementacion, Dictionary<string, double> productos)
        {
            _implementacion = implementacion;
            _productos = productos;
        }

        // Asignación
        public Abstraction(int tipo, Dictionary<string, double> productos)
        {
            if (tipo == 1)
            {
                _implementacion = new ImplementationBW();
            }
            if (tipo == 2)
            {
                _implementacion = new ImplementationZebra();
            }
            if (tipo == 3)
            {
                _implementacion = new ImplementationBlock();
            }
            _productos = productos;
        }


        // Operatoria
        public void MostrarTotales() => _implementacion.MostrarTotales(_productos);
        public void Listar() => _implementacion.ListarProductos(_productos);
    }
}
