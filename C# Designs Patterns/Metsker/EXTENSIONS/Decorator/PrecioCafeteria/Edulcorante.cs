namespace PatronDecoratorC
{
    public  class Edulcorante :AgregadoDecorator
    {
        public Edulcorante(BebidaComponent bebida) : base(bebida) { }
        public override double Costo => _bebida.Costo + 1;
        public override string Descripcion => string.Format($"{_bebida.Descripcion}, Edulcorante");

    }
}
