using System;

using Patrones.Command.Core;

namespace Patrones.Command.UI
{
    class Program
    {
        static void Main()
        {
            var empresa = new EmpresaInvoker();
            var producto = new ProductoReceiver
            {
                Cantidad = 100
            };

            var alta1 = new AltaStockCommand(producto, 10);
            empresa.TomarOrden(alta1);

            var baja1 = new BajaStockCommand(producto, 50);
            empresa.TomarOrden(baja1);

            var baja2 = new BajaStockCommand(producto, 5);
            empresa.TomarOrden(baja2);

            var baja3 = new BajaStockCommand(producto, 15);
            empresa.TomarOrden(baja3);

            var alta2 = new AltaStockCommand(producto, 100);
            empresa.TomarOrden(alta2);

            var alta3 = new AltaStockCommand(producto, 100);
            empresa.TomarOrden(alta3);

            empresa.ProcesarOrdenes();

            Console.Write(string.Format("Total stock es {0}", producto.Cantidad));
            Console.ReadKey();
        }
    }
}
