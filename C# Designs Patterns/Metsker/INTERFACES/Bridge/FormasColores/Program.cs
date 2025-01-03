﻿/*
 * A design lets you deﬁne abstract operations that depend on a well-defined
 * interface and lets you add new drivers that fulfill the interface.
 */

/*
Escalabilidad:
Agregar nuevas formas o nuevos colores es sencillo. Solo necesitas crear nuevas
implementaciones de Shape o IColor.
*/

using System;

namespace FormasColores
{
    internal class Program
    {
        static void Main()
        {
            Shape redCircle = new Circle(new RedColor());
            redCircle.Draw();

            Shape blueSquare = new Square(new BlueColor());
            blueSquare.Draw();

            Shape redSquare = new Square(new RedColor());
            redSquare.Draw();

            Console.ReadKey();
        }
    }
}
