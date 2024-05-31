using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cap_10_DelegadosII
{
    internal class Program
    {
        static void Main()
        {
            //creamos el refri
            Refrigerador refrigerador = new Refrigerador(70, -20);
            Random rnd = new Random();

            //adicionamos los handlers
            refrigerador.AsignaMetodoReservas(new Refrigerador.ReservasDelegate(InformeKilos));
            refrigerador.AsignaMetodoDescongelado(new Refrigerador.DescongeladoDelegate(InformeGrados));

            //el refri trabajando
            while (refrigerador.Kilos > 0)
            {
                refrigerador.Trabajar(rnd.Next(1, 5));
            }

            Console.ReadKey();
        }

        public static void InformeKilos(int kilos )
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Reserva baja de alimentos: {kilos} kilos.");
        }

        public static void InformeGrados(int grados)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Temperatura alta de trabajo: {grados} grados.");
        }
    }
}
