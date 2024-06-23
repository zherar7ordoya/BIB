namespace AplicacionLibreria
{
    public enum TipoPizza
    {
        Cancha,
        Napolitana
    }

    public abstract class Pizza
    {
        protected string _descripcion;
        protected string _origen;

        public string Render()
        {
            return $"Pizza {_descripcion} hecha en {_origen}";
        }
    }

    public class PizzaCancha : Pizza
    {
        public PizzaCancha(string origen)
        {
            _descripcion = "Cancha\t\t";
            _origen = origen;
        }
    }

    public class PizzaNapolitana : Pizza
    {
        public PizzaNapolitana(string origen)
        {
            _descripcion = "Napolitana\t";
            _origen = origen;
        }
    }

    public abstract class Pizzeria
    {
        public abstract Pizza CrearPizza(TipoPizza tipo);
    }

    public class PizzeriaArgentina : Pizzeria
    {
        public override Pizza CrearPizza(TipoPizza tipo)
        {
            if (tipo == TipoPizza.Cancha)
            {
                return new PizzaCancha("Argentina");
            }
            else if (tipo == TipoPizza.Napolitana)
            {
                return new PizzaNapolitana("Argentina");
            }
            else
            {
                return null;
            }
        }
    }

    public class PizzeriaItaliana : Pizzeria
    {
        public override Pizza CrearPizza(TipoPizza tipo)
        {
            if (tipo == TipoPizza.Cancha)
            {
                return new PizzaCancha("Italia");
            }
            else if (tipo == TipoPizza.Napolitana)
            {
                return new PizzaNapolitana("Italia");
            }
            else
            {
                return null;
            }
        }
    }
}
