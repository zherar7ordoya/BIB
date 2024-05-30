namespace ClassLibrary
{
    public class PizzeriaArgentina: Pizzeria
    {
        public override Empanada CrearEmpanada()
        {
            return new EmpanadaCarne();
        }
        public override Pizza CrearPizza()
        {
            return new PizzaCancha();
        }
    }
}
