namespace PatronDecoratorC
{
    public class Leche : AgregadoDecorator
    {
        public Leche(BebidaComponent bebida) : base(bebida) { }
        public override double Costo => _bebida.Costo + 2;
        public override string Descripcion => string.Format($"{_bebida.Descripcion}, Leche");
    }
}
