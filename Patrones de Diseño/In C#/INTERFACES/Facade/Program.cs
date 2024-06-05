using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CFachada fachada = new CFachada();

            fachada.Compra();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----");

            Console.ReadLine();
        }
    }
}
