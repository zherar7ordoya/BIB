namespace PatronDecoratorC
{
    public class Crema : AgregadoDecorator
    {
        public Crema(BebidaComponent bebida) : base(bebida) { }
        public override double Costo => _bebida.Costo + 4;
        public override string Descripcion => string.Format($"{_bebida.Descripcion}, Crema");
    
    }
}
