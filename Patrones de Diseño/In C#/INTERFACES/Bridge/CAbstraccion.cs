using System.Collections.Generic;

namespace Bridge
{
    public class CAbstraccion
    {
        readonly IBridge _implementacion;
        readonly Dictionary<string, double> _productos;

        public CAbstraccion(IBridge implementacion, Dictionary<string, double> productos)
        {
            _implementacion = implementacion;
            _productos = productos;
        }

        // Asignación
        public CAbstraccion(int tipo, Dictionary<string, double> productos)
        {
            if (tipo == 1)
            {
                _implementacion = new CImplementacion1();
            }
            if (tipo == 2)
            {
                _implementacion = new CImplementacion2();
            }
            if (tipo == 3)
            {
                _implementacion = new CImplementacion3();
            }
            _productos = productos;
        }


        // Operatoria
        public void MostrarTotales() => _implementacion.MostrarTotales(_productos);
        public void Listar() => _implementacion.ListarProductos(_productos);
    }
}
