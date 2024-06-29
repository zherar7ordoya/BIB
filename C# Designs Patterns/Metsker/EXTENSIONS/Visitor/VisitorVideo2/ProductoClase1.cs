
namespace VisitorVideo2
{
    public class ProductoClase1 : Producto
    {
        public override double Aceptar(IVisitor v)
        {
            return v.Visitar(this);
        }
    }
}