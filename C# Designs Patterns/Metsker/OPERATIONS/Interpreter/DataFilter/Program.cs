/*
 * Definición enigmática (si las hay):
 * A toolkit that lets you compose executable objects at runtime.
 */

using System;

/*
 * En este ejemplo, las clases que implementan IFilterExpression (AndExpression,
 * OrExpression, y PriceFilterExpression) representan la gramática del sistema
 * de filtrado. Estas clases permiten construir y evaluar expresiones de filtrado
 * complejas a partir de componentes más simples, siguiendo las reglas de la
 * gramática definida por la interfaz IFilterExpression.
 */

namespace DataFilter
{
    /// <summary>
    /// Definición de la interfaz del patrón Interpreter: Define el método
    /// Interpret, que debe ser implementado por todas las expresiones. Este
    /// método es el núcleo del patrón Interpreter, ya que permite evaluar una
    /// expresión en un contexto dado (en este caso, un objeto Item).
    /// 
    /// Define la estructura básica de todas las expresiones en la gramática.
    /// 
    /// </summary>
    public interface IFilterExpression
    {
        // Método que interpretará el contexto (en este caso, un objeto Item).
        bool Interpret(Item item);
    }

    /// <summary>
    /// Clase que representa una expresión lógica AND en el patrón Interpreter.
    /// AndExpression y OrExpression son ejemplos de composiciones de expresiones,
    /// lo que permite combinar múltiples expresiones de forma lógica. Este es un
    /// aspecto clave del patrón Interpreter, donde las expresiones pueden ser
    /// combinadas para formar árboles de sintaxis abstracta.
    /// 
    /// Expresiones No Terminales:
    /// Estas son expresiones que combinan otras expresiones(terminales o no
    /// terminales) para formar expresiones más complejas. En el ejemplo,
    /// AndExpression y OrExpression son expresiones no terminales que combinan
    /// dos expresiones usando operadores lógicos AND y OR.
    /// 
    /// </summary>
    public class AndExpression : IFilterExpression
    {
        private readonly IFilterExpression _expr1;
        private readonly IFilterExpression _expr2;

        // Constructor que recibe dos expresiones que serán evaluadas con un
        // operador AND.
        public AndExpression(IFilterExpression expr1, IFilterExpression expr2)
        {
            _expr1 = expr1;
            _expr2 = expr2;
        }

        // Implementación del método Interpret que evalúa ambas expresiones con
        // un AND lógico.
        public bool Interpret(Item item)
        {
            return _expr1.Interpret(item) && _expr2.Interpret(item);
        }
    }

    /// <summary>
    /// Clase que representa una expresión lógica OR en el patrón Interpreter.
    /// AndExpression y OrExpression son ejemplos de composiciones de expresiones,
    /// lo que permite combinar múltiples expresiones de forma lógica. Este es un
    /// aspecto clave del patrón Interpreter, donde las expresiones pueden ser
    /// combinadas para formar árboles de sintaxis abstracta.
    /// 
    /// Expresiones No Terminales:
    /// Estas son expresiones que combinan otras expresiones(terminales o no
    /// terminales) para formar expresiones más complejas. En el ejemplo,
    /// AndExpression y OrExpression son expresiones no terminales que combinan
    /// dos expresiones usando operadores lógicos AND y OR.
    /// 
    /// </summary>
    public class OrExpression : IFilterExpression
    {
        private readonly IFilterExpression _expr1;
        private readonly IFilterExpression _expr2;

        // Constructor que recibe dos expresiones que serán evaluadas con un
        // operador OR.
        public OrExpression(IFilterExpression expr1, IFilterExpression expr2)
        {
            _expr1 = expr1;
            _expr2 = expr2;
        }

        // Implementación del método Interpret que evalúa ambas expresiones con
        // un OR lógico.
        public bool Interpret(Item item)
        {
            return _expr1.Interpret(item) || _expr2.Interpret(item);
        }
    }

    /// <summary>
    /// Clase que representa una expresión de filtro por precio.
    /// PriceFilterExpression es una expresión concreta que evalúa una condición
    /// específica (el precio del ítem).
    /// 
    /// Expresiones Terminales: Estas son las expresiones más simples y que no 
    /// se pueden descomponer más. En el ejemplo, PriceFilterExpression es una
    /// expresión terminal que compara el precio de un ítem con un valor dado.
    /// 
    /// </summary>
    public class PriceFilterExpression : IFilterExpression
    {
        private readonly int _price;

        // Constructor que recibe el precio máximo para el filtro.
        public PriceFilterExpression(int price)
        {
            _price = price;
        }

        // Implementación del método Interpret que compara el precio del ítem
        // con el precio del filtro.
        public bool Interpret(Item item)
        {
            return item.Price <= _price;
        }
    }

    /// <summary>
    /// Clase que representa el objeto que será interpretado por las expresiones
    /// de filtro. Representa el contexto en el que las expresiones son evaluadas.
    /// En este ejemplo, los ítems tienen un precio, y las expresiones de filtro
    /// actúan sobre esta propiedad.
    /// </summary>
    public class Item
    {
        public int Price { get; set; }
        // Otros atributos...
    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Este filtro evalúa si el precio de un ítem es menor o igual al valor especificado.\n");
            Console.WriteLine("Cargando datos...\n");

            // El programa define dos ítems con precios diferentes:
            var item1 = new Item { Price = 50 };
            Console.WriteLine("Item 1: " + item1.Price);

            var item2 = new Item { Price = 100 };
            Console.WriteLine("Item 2: " + item2.Price);

            // Construcción de una expresión compuesta. Esta expresión evalúa si
            // el precio del ítem es menor o igual a 60 y a 120.
            Console.WriteLine("\nConstruyendo expresión de filtro: Y(60, 120)");
            var expr = new AndExpression(new PriceFilterExpression(60),
                                         new PriceFilterExpression(120));

            // Evaluación de las expresiones con dos ítems diferentes.
            Console.WriteLine(
                "\nLa evaluación del Item 1 devolverá TRUE ya que ya que " +
                "50 <= 60 y 50 <= 120");

            // Output: True (ya que 50 <= 60 y 50 <= 120)
            Console.WriteLine(expr.Interpret(item1));

            Console.WriteLine(
                "\nLa evaluación del Item 2 devolverá FALSE ya que 100 > 60");

            // Output: False (ya que 100 > 60)
            Console.WriteLine(expr.Interpret(item2));

            Console.ReadKey();
        }
    }
}
