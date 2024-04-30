namespace PatitosCSharp
{
    internal abstract class Duck
    {
        public IFlyBehavior? flyBehavior;
        public IQuackBehavior? quackBehavior;

        public Duck() { }

        public abstract void display();


        // El operador "?." verifica si "flyBehavior" es nulo antes de llamar a
        // "fly()". Se conoce como el operador de navegación segura
        // (null-conditional operator) es útil para escribir código más limpio y
        // conciso, evitando la necesidad de comprobar manualmente si cada
        // objeto es nulo antes de intentar acceder a sus miembros.
        public void performFly()
        {
            flyBehavior?.fly();
        }

        public void performQuack()
        {
            quackBehavior?.quack();
        }

        public void swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }
    }
}
