using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Única
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CSingleton uno = CSingleton.ObtenerInstancia();

            uno.PonerDatos("Ana", 27);
            uno.AlgunProceso();
            Console.WriteLine(uno);
            Console.WriteLine("**************");

            CSingleton dos = CSingleton.ObtenerInstancia();

            // Comprobar si es la misma instancia
            Console.WriteLine(dos);

            Console.ReadKey();
        }
    }
}
