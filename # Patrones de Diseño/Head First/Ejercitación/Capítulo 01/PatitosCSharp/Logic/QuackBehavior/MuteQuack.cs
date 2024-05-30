internal class MuteQuack : IQuackBehavior
{
    public void quack()
    {
        Console.WriteLine("<< Silence >>");
    }
}