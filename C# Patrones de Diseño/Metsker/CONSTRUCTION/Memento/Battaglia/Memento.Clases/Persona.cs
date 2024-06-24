using System;

namespace Libreria
{
    public class Persona
    {
        public string Nombre { get; set; }

        public Memento SaveToMemento()
        {
            Console.WriteLine("Originator: Guardando momento: " + Nombre);
            return new Memento(Nombre);
        }

        public void RestoreToMemento(Memento memento)
        {
            Nombre = memento.Estado;
            Console.WriteLine("Originator: Recuperando momento: " + Nombre);
        }
    }
}
