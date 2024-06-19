using System;

namespace ConEvento
{
    public class Observer
    {
        public void Subscribe(Subject subject)
        {
            subject.StateChanged += Update;
        }

        private void Update(object sender, EventArgs e)
        {
            // Esta línea nos permitirá ver en la consola cuando el observador
            // es notificado de un cambio en el estado del sujeto.
            Console.WriteLine("Observer notified. Subject state changed.");
        }
    }
}
