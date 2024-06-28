/*
 * A design lets you register for callbacks that will be issued when an object
 * changes.
 */

using System;

namespace ConEvento
{
    internal class Program
    {
        static void Main()
        {
            Interesante interes1 = new Interesante("Breaking Bad");
            Interesante interes2 = new InteresanteAvanzado("Better Call Saul");

            // Instanciar el Observador
            Curioso observador = new Curioso();

            // Suscribir el Observador al Sujeto
            observador.Suscribir(interes1);
            observador.Suscribir(interes2);

            // Esto disparará el evento y notificará al observador
            interes1.Estado = 1;
            interes2.Estado = 2;
            interes1.Estado = 3;
            interes2.Estado = 4;

            Console.ReadKey();
        }
    }
}
