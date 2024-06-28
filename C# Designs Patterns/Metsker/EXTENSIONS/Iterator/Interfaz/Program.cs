/* VER EL OTRO EJEMPLO EN DONDE SE EJEMPLIFICA EL USO DIRECTO DE LAS INTERFACES */

using System;
using System.Collections;

namespace Iterador
{
    class Program
    {
        static void Main()
        {
            // Creamos una instancia de Enumerable con la cadena "¡Hola Mundo!"
            IEnumerable cadena = new Enumerable("¡Hola Mundo!");

            // Usamos foreach para recorrer cada caracter de la instancia Enumerable
            foreach (char caracter in cadena)
            {
                Console.Write(caracter); // Imprimimos cada caracter en la consola
            }

            // Esperamos a que el usuario presione una tecla antes de cerrar
            Console.ReadKey();
        }
    }

    /*
     * foreach realiza la llamada a GetEnumerator() de manera implícita. Esto es
     * parte de cómo el compilador de C# maneja el foreach internamente. Por eso,
     * no puede verse una llamada explícita a GetEnumerator() en el código yq que
     * el compilador genera esa llamada automáticamente.
     * Cuando se usa foreach, el compilador llama a GetEnumerator() en la
     * colección que se está iterando. Luego, utiliza el enumerador devuelto para
     * recorrer la colección.
     * -------------------------------------------------------------------------
     * Muchos métodos de LINQ también usan GetEnumerator() para acceder a los
     * elementos de la colección.
     * -------------------------------------------------------------------------
     */

    /// <summary>
    /// Clase que implementa IEnumerable para que podamos usar foreach en una
    /// instancia de esta clase.
    /// </summary>
    public class Enumerable : IEnumerable
    {
        // Constructor que inicializa la cadena
        public Enumerable(string cadena) => _cadena = cadena;

        // Campo que almacena la cadena
        readonly string _cadena;

        /// <summary>
        /// Implementación del método GetEnumerator de IEnumerable (devuelve una
        /// instancia de Enumerator)
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator() => new Enumerator(_cadena);
    }

    /// <summary>
    /// Clase que implementa IEnumerator para proporcionar la funcionalidad de
    /// enumeración.
    /// </summary>
    public class Enumerator : IEnumerator
    {
        // Constructor que inicializa el enumerador con la cadena convertida a
        // un array de caracteres.
        public Enumerator(string cadena)
        {
            // Convertimos la cadena a un array de caracteres
            _cadena = cadena.ToCharArray();

            // Inicializamos la posición a -1
            _posicion = -1;
        }

        // Array de caracteres que representa la cadena
        readonly char[] _cadena;

        // Posición actual del enumerador
        int _posicion;

        // Propiedad Current que devuelve el elemento actual en la colección.
        public object Current
        {
            get
            {
                // Verificamos que la posición actual es válida
                if (_posicion >= 0 && _posicion < _cadena.Length)
                {
                    return _cadena[_posicion]; // Devolvemos el carácter actual
                }
                // Si la posición no es válida, lanzamos una excepción
                throw new InvalidOperationException();
            }
        }

        // Método MoveNext que avanza al siguiente elemento en la colección
        public bool MoveNext()
        {
            // Verificamos si podemos avanzar a la siguiente posición
            if (_posicion < _cadena.Length - 1)
            {
                _posicion++; // Incrementamos la posición.
                return true; // Devolvemos true indicando que hemos avanzado.
            }
            else
            {
                return false; // False indica que se ha llegado al final.
            }
        }

        // Método Reset que restablece la posición inicial del enumerador
        public void Reset() => _posicion = -1; // Restablecemos la posición a -1
    }
}
