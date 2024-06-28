using System;

namespace PatronDecoratorC
{
    class Program
    {
        static void Main()
        {
            // Café descafeinado hereda de BebidaComponent
            BebidaComponent cafe = new CafeDescafeinado();
            
            // Crema hereda de AgregadoDecorator que hereda de BebidaComponent
            cafe = new Crema(cafe);
            cafe = new Edulcorante(cafe);
            cafe = new Canela(cafe);

            Console.WriteLine(
                $"Producto: {cafe.Descripcion}\n" +
                $"Costo: {cafe.Costo:C}\n");

            cafe = new CafeExpresso();
            cafe = new Leche(cafe);
            cafe = new Edulcorante(cafe);
            cafe = new Canela(cafe);

            Console.WriteLine(
                $"Producto: {cafe.Descripcion}\n" +
                $"Costo: {cafe.Costo:C}\n");

            cafe = new CafeSolo();
            cafe = new Edulcorante(cafe);

            Console.WriteLine(
                $"Producto: {cafe.Descripcion}\n" +
                $"Costo: {cafe.Costo:C}\n");

            Console.ReadKey();
        }
    }
}
