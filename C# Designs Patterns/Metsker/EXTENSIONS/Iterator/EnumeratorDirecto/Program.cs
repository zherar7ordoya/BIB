/*
 * EJEMPLO DE CÓMO SE PUEDE USAR GetEnumerator() DIRECTAMENTE
 * En este ejemplo, llamamos directamente a GetEnumerator() y usamos un bucle
 * while con MoveNext() y Current para iterar sobre la colección.
 */


using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        IEnumerable cadena = new Enumerable("¡Hola Mundo!");
        IEnumerator enumerator = cadena.GetEnumerator();

        while (enumerator.MoveNext())
        {
            char caracter = (char)enumerator.Current;
            Console.Write(caracter);
        }

        Console.ReadKey();
    }
}

public class Enumerable : IEnumerable
{
    public Enumerable(string cadena) => _cadena = cadena;

    readonly string _cadena;

    public IEnumerator GetEnumerator() => new Enumerator(_cadena);
}

public class Enumerator : IEnumerator
{
    public Enumerator(string cadena)
    {
        _cadena = cadena.ToCharArray();
        _posicion = -1;
    }

    readonly char[] _cadena;
    int _posicion;

    public object Current
    {
        get
        {
            if (_posicion >= 0 && _posicion < _cadena.Length)
            {
                return _cadena[_posicion];
            }
            throw new InvalidOperationException();
        }
    }

    public bool MoveNext()
    {
        if (_posicion < _cadena.Length - 1)
        {
            _posicion++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reset() => _posicion = -1;
}
