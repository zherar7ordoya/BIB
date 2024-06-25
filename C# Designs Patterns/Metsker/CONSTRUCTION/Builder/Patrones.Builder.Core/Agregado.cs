namespace Patrones.Builder.Core
{
    public abstract class Agregado
    {
        protected string _descripcion;
        public string Descripcion { get { return _descripcion; } }
    }


    public class Oregano : Agregado
    {
        public Oregano()
        {
            _descripcion = "Oregano fresco";
        }
    }

    public class Anchoas : Agregado
    {
        public Anchoas()
        {
            _descripcion = "Anchoas en aceite";
        }
    }

    public class Berenjenas : Agregado
    {
        public Berenjenas()
        {
            _descripcion = "Berenjenas sin calorías";
        }
    }
}
