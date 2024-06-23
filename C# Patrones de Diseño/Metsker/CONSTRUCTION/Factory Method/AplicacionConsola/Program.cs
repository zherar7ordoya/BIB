using AplicacionLibreria;

using System;

namespace AplicacionConsola
{
    internal class Program
    {
        static void Main()
        {
            Pizzeria pizzeria;
            Pizza pizza;

            pizzeria = new PizzeriaArgentina();
            pizza = pizzeria.CrearPizza(TipoPizza.Napolitana);
            Console.WriteLine(pizza.Render());
            pizza = pizzeria.CrearPizza(TipoPizza.Cancha);
            Console.WriteLine(pizza.Render());

            pizzeria = new PizzeriaItaliana();
            pizza = pizzeria.CrearPizza(TipoPizza.Napolitana);
            Console.WriteLine(pizza.Render());
            pizza = pizzeria.CrearPizza(TipoPizza.Cancha);
            Console.WriteLine(pizza.Render());

            Console.ReadKey();
        }
    }
}
