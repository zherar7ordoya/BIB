namespace VisitorVideo2
{
    public class IngresoBruto : IVisitor
    {
        private double impuestoClase1 = 1.21d;
        private double impuestoClase2 = 1.105d;

        public double Visitar(ProductoClase2 p)
        {
            return p.Precio * impuestoClase2;

        }

        public double Visitar(ProductoClase1 p)
        {
            return p.Precio * impuestoClase1;
        }
    }

    public class IVA : IVisitor
    {
        private double impuestoClase1 = 1.21d;
        private double impuestoClase2 = 1.105d;

        public double Visitar(ProductoClase2 p)
        {
            return p.Precio * impuestoClase2;

        }

        public double Visitar(ProductoClase1 p)
        {
            return p.Precio * impuestoClase1;
        }
    }
}