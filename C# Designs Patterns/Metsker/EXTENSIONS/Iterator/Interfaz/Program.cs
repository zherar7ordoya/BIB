using System;
using System.Collections;

namespace IteratorV1
{
    class Program
    {
        static void Main()
        {
            var palabra = new Palabra("hola mundo");

            foreach (var item in palabra)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    public class Palabra : IEnumerable
    {
        // Constructor
        public Palabra(string palabra) => _palabra = palabra;

        readonly string _palabra;

        public IEnumerator GetEnumerator() => new PalabraIterator(_palabra);
    }

    public class PalabraIterator : IEnumerator
    {
        // Constructor
        public PalabraIterator(string palabra) => _palabra = palabra.ToCharArray();

        readonly char[] _palabra;
        int _pos;

        public object Current => _palabra[_pos];

        public bool MoveNext()
        {
            if (_pos < _palabra.Length - 1)
            {
                _pos++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset() => _pos = -1;
    }
}
