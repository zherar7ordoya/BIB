using System;

namespace ConEvento
{
    // Antes esta clase se llamaba Observador (Observer).
    public class Curioso
    {
        /*** -------------------------------------------------------------- ***\
                          EL OBSERVADOR (CURIOSO) TIENE QUE...
        \*** -------------------------------------------------------------- ***/

        // 1. Suscribirse.
        public void Suscribir(Interesante sujeto)
        {
            sujeto.CambioHandler += Reaccionar;
        }

        // 2. Reaccionar.
        private void Reaccionar(object sender, EventArgs e)
        {
            if (sender is Interesante interesante)
            {
                Console.WriteLine(
                    $"Observer (o sea, yo) notified. " +
                    $"{interesante.Nombre} (la clase que manejo) state changed. " +
                    $"Ahora es {interesante.Estado}");
            }
        }
    }
}
