using System;
using System.Collections.Generic;

namespace Bridge
{
    public class CImplementacion2 : IBridge
    {
        public void ListarProductos(Dictionary<string, double> pProductos)
        {
            foreach (KeyValuePair<string, double> item in pProductos)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Key);
            }
        }

        public void MostrarTotales(Dictionary<string, double> pProductos)
        {
            double total = 0;
            int cantidad = 0;
            foreach (KeyValuePair<string, double> item in pProductos)
            {
                total += item.Value;
                cantidad++;
            }
            Console.WriteLine("El total de {0} productos + IVA es de ${1} ", cantidad, total * 1.21);
        }
    }
}
