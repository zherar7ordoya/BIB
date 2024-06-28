namespace PatronDecoratorC
{
    public abstract class AgregadoDecorator : BebidaComponent
    {
        // Constructor
        public AgregadoDecorator(BebidaComponent bebida) => _bebida = bebida;

        protected BebidaComponent _bebida;
    }
}
