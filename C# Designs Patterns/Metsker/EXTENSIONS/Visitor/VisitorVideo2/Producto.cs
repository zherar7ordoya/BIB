
namespace VisitorVideo2
{
    public abstract class Producto : IVisitable
    {
        public double Precio { get; set; }

        public abstract double Aceptar(IVisitor v);
    }
}