using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cap_07_Interfaz_callBack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creamos el refri
            CRefri miRefri = new CRefri(70, -20);
            Random rnd = new Random();

            //creamos el sink
            CRefriSink miSink1 = new CRefriSink();

            //adicionamos el sink al refri
            miRefri.AgregarSink(miSink1);

            //el refri hace su trabajo
            while (miRefri.Kilos > 0)
            {
                //el refri trabaja y le saca kilos al azar
                miRefri.Trabajar(rnd.Next(1, 5));
            }

            Console.ReadKey();
        }
    }
}
