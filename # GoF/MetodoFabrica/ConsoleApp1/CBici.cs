using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CBici : IVehiculo
    {
        public void Acelerar()
        {
            Console.WriteLine("La bicicleta acelera");
        }

        public void Encender()
        {
            Console.WriteLine("La bicicleta enciende");
        }

        public void Frenar()
        {
            Console.WriteLine("La bicicleta frena");
        }

        public void Girar()
        {
            Console.WriteLine("La bicicleta gira");
        }
    }
}
