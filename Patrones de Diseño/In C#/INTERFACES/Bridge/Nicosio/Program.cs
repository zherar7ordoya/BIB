using System;
using System.Collections.Generic;

namespace Bridge
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, double> productos = new Dictionary<string, double>
            {
                { "M101", 56.32 },
                { "M234", 23.88 },
                { "C654", 974.56 },
                { "M401", 43.28 },
                { "C345", 785.12 },
                { "D567", 432.56 },
                { "M103", 874.54 },
                { "D901", 23.18 },
                { "C732", 43.12 },
                { "M056", 21.42 },
            };

            Console.WriteLine("Usando uno de los constructores...\n");
            Abstraction abstraccion = new Abstraction(new ImplementationBlock(), productos);
            abstraccion.MostrarTotales();
            Console.WriteLine();
            abstraccion.Listar();

            Console.ResetColor();

            Console.WriteLine("\nUsando el otro constructor...\n");
            abstraccion = new Abstraction(3, productos);
            abstraccion.MostrarTotales();
            Console.WriteLine();
            abstraccion.Listar();

            Console.ReadKey();
        }
    }
    
    
}
