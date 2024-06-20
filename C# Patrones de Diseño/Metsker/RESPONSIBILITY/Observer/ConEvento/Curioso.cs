using System;

namespace ConEvento
{
    // Antes esta clase se llamaba Observador (Observer).
    public class Curioso
    {
        public void Suscribir(Interesante sujeto)
        {
            sujeto.CambioHandler += Reaccionar;
        }

        /*** Está claro: El OBSERVADOR tiene que suscribirse y reaccionar ***/

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
