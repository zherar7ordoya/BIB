using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CAuto : IVehiculo
    {
        public void Acelerar()
        {
            Console.WriteLine("El auto acelera");
        }

        public void Encender()
        {
            Console.WriteLine("El auto enciende");
        }

        public void Frenar()
        {
            Console.WriteLine("El auto frena");
        }

        public void Girar()
        {
            Console.WriteLine("El auto gira");
        }
    }
}
