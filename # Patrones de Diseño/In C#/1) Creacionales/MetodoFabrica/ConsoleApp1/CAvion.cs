using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CAvion : IVehiculo
    {
        public void Acelerar()
        {
            Console.WriteLine("El avion acelera");
        }

        public void Encender()
        {
            Console.WriteLine("El avion enciende");
        }

        public void Frenar()
        {
            Console.WriteLine("El avion frena");
        }

        public void Girar()
        {
            Console.WriteLine("El avion gira");
        }
    }
}
