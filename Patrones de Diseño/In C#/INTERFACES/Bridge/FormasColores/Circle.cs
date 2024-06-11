using System;

namespace FormasColores
{
    public class Circle : Shape
    {
        public Circle(IColor color) : base(color) { }

        public override void Draw()
        {
            Console.Write("Drawing Circle. ");
            color.ApplyColor();
        }
    }
}
