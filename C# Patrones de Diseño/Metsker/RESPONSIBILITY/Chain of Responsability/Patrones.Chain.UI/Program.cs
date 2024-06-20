using Patrones.Chain.Core;

using System;

using TD.Patrones.Chain;

namespace Patrones.Chain.UI
{
    class Program
    {
        static void Main()
        {
            Aprobador comprador = new Comprador();
            var gerente = new Gerente();
            var director = new Director();
            var directorGeneral = new DirectorGeneral();

            director.AgregarSiguiente(directorGeneral);
            gerente.AgregarSiguiente(director);
            comprador.AgregarSiguiente(gerente);

            var compra = new Compra();

            while (true)
            {
                Console.WriteLine("Ingrese el importe de la compra (0 para terminar)");
                double importe = double.Parse(Console.ReadLine());
                if (importe == 0) { break; }
                compra.Importe = importe;
                comprador.Procesar(compra);
            }
        }
    }
}
