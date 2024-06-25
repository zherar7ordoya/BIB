namespace Patrones.Builder.Core
{
    public class PizzaItalianaBuilder : PizzaBuilder
    {

        public PizzaItalianaBuilder()
        {
            _descripcion = "Pizza Italiana";
        }
        public override Agregado BuildAgregado()
        {
            return new Anchoas();
        }

        public override Masa BuildMasa()
        {
            return new ALaPiedra();
        }

        public override Salsa BuildSalsa()
        {
            return new Oliva();
        }
    }
}
