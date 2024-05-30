using ClassLibrary;

using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Pizzeria fabrica = new PizzeriaArgentina();
            Pizza pizza = fabrica.CrearPizza();
            Empanada empanada = fabrica.CrearEmpanada();
            Console.WriteLine($"Pizza: {pizza.Descripcion} :: Empanada: {empanada.Descripcion}");

            fabrica = new PizzeriaItaliana();
            pizza = fabrica.CrearPizza();
            empanada = fabrica.CrearEmpanada();
            Console.WriteLine($"Pizza: {pizza.Descripcion} :: Empanada: {empanada.Descripcion}");

            fabrica = new PizzeriaJaponesa();
            pizza = fabrica.CrearPizza();
            empanada = fabrica.CrearEmpanada();
            Console.WriteLine($"Pizza: {pizza.Descripcion} :: Empanada: {empanada.Descripcion}");

            Console.ReadKey();
        }
    }
}
