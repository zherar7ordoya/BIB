using System;

namespace Subsistemas
{
    internal class CSistemaCompra
    {
        public bool Comprar()
        {
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ingrese número de tarjeta:");
            string dato = Console.ReadLine();

            if (dato == "1234")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pago aceptado");
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pago rechazado");
                return false;
            }
        }
    }
}
