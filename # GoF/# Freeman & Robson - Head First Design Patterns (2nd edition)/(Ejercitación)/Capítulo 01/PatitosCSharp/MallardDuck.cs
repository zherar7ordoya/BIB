namespace PatitosCSharp
{
    internal class MallardDuck : Duck
    {
        readonly IQuackBehavior quackBehavior;
        readonly IFlyBehavior flyBehavior;
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings();
        }
        public override void display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }
}
