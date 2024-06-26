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

            OrdenCommand comando;

            comando = new AltaStockCommand(producto, 10);
            empresa.TomarOrden(comando);
            comando = new BajaStockCommand(producto, 50);
            empresa.TomarOrden(comando);
            comando = new BajaStockCommand(producto, 5);
            empresa.TomarOrden(comando);
            comando = new BajaStockCommand(producto, 15);
            empresa.TomarOrden(comando);
            comando = new AltaStockCommand(producto, 100);
            empresa.TomarOrden(comando);
            comando = new AltaStockCommand(producto, 100);
            empresa.TomarOrden(comando);

            empresa.ProcesarOrdenes();

            Console.Write(string.Format("Total stock es {0}", producto.Cantidad));
            Console.ReadKey();
        }
    }
}
