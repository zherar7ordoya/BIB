using System;
using System.Collections.Generic;

namespace Bridge
{
    public class ImplementationZebra : IBridge
    {
        public void ListarProductos(Dictionary<string, double> productos)
        {
            foreach (KeyValuePair<string, double> item in productos)
            {
                if (item.Key[0] == 'C') Console.ForegroundColor = ConsoleColor.Green;
                if (item.Key[0] == 'M') Console.ForegroundColor = ConsoleColor.Yellow;
                if (item.Key[0] == 'D') Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }

        public void MostrarTotales(Dictionary<string, double> pProductos)
        {
            int cantidad = 0;
            double total = 0;
            double totalM=0;
            double totalC=0;
            double totalD=0;
            
            foreach (KeyValuePair<string, double> item in pProductos)
            {
                total += item.Value;
                if (item.Key[0] == 'C') totalC += item.Value;
                if (item.Key[0] == 'M') totalM += item.Value;
                if (item.Key[0] == 'D') totalD += item.Value;
                cantidad++;
            }
            Console.WriteLine("El total de comida es de ${0} ", totalC);
            Console.WriteLine("El total de medicamentos es de ${0} ", totalM);
            Console.WriteLine("El total de deportes es de ${0} ", totalD);
            Console.WriteLine("El total de {0} productos es ${1} ", cantidad, total);
        }
    }
}
