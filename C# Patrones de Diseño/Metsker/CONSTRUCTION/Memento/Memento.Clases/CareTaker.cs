using System.Collections.Generic;

namespace Libreria
{
    public class CareTaker
    {
        readonly List<Memento> _mementos = new List<Memento>();

        public void Add(Memento memento)
        {
            _mementos.Add(memento);
        }

        public Memento GetMemento(int index)
        {
            return _mementos[index];
        }
    }
}
