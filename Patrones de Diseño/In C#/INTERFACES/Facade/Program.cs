using Subsistemas;

using System;

namespace Facade
{
    internal class Program
    {
        static void Main()
        {
            CFachada fachada = new CFachada();

            fachada.Compra();

            Console.ForegroundColor = ConsoleColor.White;

            Console.ResetColor();
            Console.WriteLine("**************************");
            Console.ReadLine();
        }
    }
}
