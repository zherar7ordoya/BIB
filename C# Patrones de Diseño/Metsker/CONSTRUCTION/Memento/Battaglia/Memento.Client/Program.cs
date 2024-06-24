using Libreria;
using System;


namespace Cliente
{
    class Program
    {
        static readonly CareTaker caretaker = new CareTaker();

        static void Main()
        {
            var persona = new Persona
            {
                Nombre = "Battaglia"
            };
            caretaker.Add(persona.SaveToMemento());

            persona.Nombre = "Gerardo";
            caretaker.Add(persona.SaveToMemento());
            
            persona.Nombre = "Petricor";
            caretaker.Add(persona.SaveToMemento());

            Memento memento;
            Console.WriteLine("Viendo momento 1: " + caretaker.GetMemento(0).Estado);
            Console.WriteLine("Viendo momento 2: " + caretaker.GetMemento(1).Estado);
            Console.WriteLine("Viendo momento 3: " + caretaker.GetMemento(2).Estado);

            memento = caretaker.GetMemento(0);
            persona.RestoreToMemento(memento);
            persona.RestoreToMemento(caretaker.GetMemento(1));

            Console.ReadKey();
        }
    }
}
