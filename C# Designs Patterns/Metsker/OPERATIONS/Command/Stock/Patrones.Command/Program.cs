/*
 * An object lets you extend its behavior by accepting a method encapsulated in
 * an object and invoking that method at an appropriate moment.
 */

using System;

using Patrones.Command.Core;

namespace Patrones.Command.UI
{
    class Program
    {
        static void Main()
        {
            var empresa = new EmpresaInvoker();

            Console.WriteLine("Stock inicial 100\n");
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

            Console.Write(string.Format("\nTotal stock es {0}", producto.Cantidad));
            Console.ReadKey();
        }
    }
}
