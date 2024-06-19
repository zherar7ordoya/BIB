using System;

namespace ConEvento
{
    internal class Program
    {
        static void Main()
        {
            Subject sujeto = new Subject();

            // Instanciar el Observador
            Observer observador = new Observer();

            // Suscribir el Observador al Sujeto
            observador.Subscribe(sujeto);

            sujeto.State = 1;  // Esto disparará el evento y notificará al observador
            sujeto.State = 2;  // Esto también disparará el evento y notificará al observador
            sujeto.State = 3;  // Y esto también

            Console.ReadKey();
        }
    }
}
