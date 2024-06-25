public abstract class Duck
{
    public IFlyBehavior? flyBehavior;
    public IQuackBehavior? quackBehavior;

    public Duck() { }

    public abstract void Display();

    public void PerformFly()
    {
        flyBehavior?.fly();
    }

    public void PerformQuack()
    {
        quackBehavior?.quack();
    }

    public void Swim()
    {
        Console.WriteLine("All ducks float, even decoys!");
    }

    public void SetFlyBehavior(IFlyBehavior fb)
    {
        flyBehavior = fb;
    }

    public void SetQuackBehavior(IQuackBehavior qb)
    {
        quackBehavior = qb;
    }
}