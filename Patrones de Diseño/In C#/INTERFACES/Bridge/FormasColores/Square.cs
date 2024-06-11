using System;

namespace FormasColores
{
    public class Square : Shape
    {
        public Square(IColor color) : base(color) { }

        public override void Draw()
        {
            Console.Write("Drawing Square. ");
            color.ApplyColor();
        }
    }
}
