using System;
using System.Collections.Generic;

namespace Bridge
{
    public class ImplementationBlock : IBridge
    {
        public void ListarProductos(Dictionary<string, double> productos)
        {
            foreach (KeyValuePair<string, double> producto in productos)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (producto.Key[0] == 'C') Console.WriteLine("{0} - {1}", producto.Key, producto.Value);
            }

            foreach (KeyValuePair<string, double> producto in productos)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (producto.Key[0] == 'M') Console.WriteLine("{0} - {1}", producto.Key, producto.Value);
            }

            foreach (KeyValuePair<string, double> producto in productos)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (producto.Key[0] == 'D') Console.WriteLine("{0} - {1}", producto.Key, producto.Value);
            }
        }

        public void MostrarTotales(Dictionary<string, double> productos)
        {
            int cantidad = 0;
            double total = 0;
            double totalM = 0;
            double totalC = 0;
            double totalD = 0;

            foreach (KeyValuePair<string, double> producto in productos)
            {
                total += producto.Value;
                if (producto.Key[0] == 'C') totalC += producto.Value;
                if (producto.Key[0] == 'M') totalM += producto.Value;
                if (producto.Key[0] == 'D') totalD += producto.Value;
                cantidad++;
            }

            double porcentajeC = Math.Round((totalC / total) * 100, 2);
            double porcentajeM = Math.Round((totalM / total) * 100, 2);
            double porcentajeD = Math.Round((totalD / total) * 100, 2);

            Console.WriteLine("El total de comida es de ${0}\t({1}% del total general)", totalC, porcentajeC);
            Console.WriteLine("El total de medicamentos es de ${0}\t({1}% del total general)", totalM, porcentajeM);
            Console.WriteLine("El total de deportes es de ${0}\t({1}% del total general)", totalD, porcentajeD);
            Console.WriteLine("\nEl total de {0} productos es ${1}", cantidad, total);
        }
    }
}