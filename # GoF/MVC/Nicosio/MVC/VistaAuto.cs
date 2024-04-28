using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    internal class VistaAuto : IVistaAuto
    {
        public void DespliegaAuto(Auto auto)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Nombre: {0}", auto.Nombre);
            Console.WriteLine("Modelo: {0}", auto.Modelo);
            Console.WriteLine("Costo: {0}", auto.Costo);
        }

        public int SolicitaEntrada()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Introduce un número:");
            Console.WriteLine("\t1) Cambiar costo");
            Console.WriteLine("\t2) Cambiar modelo");
            Console.WriteLine("\t3) Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());
            return opcion;
        }
    }
}
