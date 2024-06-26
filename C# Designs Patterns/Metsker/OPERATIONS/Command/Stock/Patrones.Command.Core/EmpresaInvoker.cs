using System.Collections.Generic;

namespace Patrones.Command.Core
{
    public class EmpresaInvoker
    {
        readonly List<OrdenCommand> _ordenes = new List<OrdenCommand>();

        public void TomarOrden(OrdenCommand comando)
        {
            _ordenes.Add(comando);
        }

        public void ProcesarOrdenes()
        {
            foreach (var orden in _ordenes)
            {
                orden.Ejecutar();
            }
            _ordenes.Clear();
        }
    }
}