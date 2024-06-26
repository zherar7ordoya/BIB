namespace Patrones.Command.Core
{
    public abstract class OrdenCommand
    {
        public abstract void Ejecutar();

        protected ProductoReceiver _producto;
        protected double _cantidad;

        public OrdenCommand(ProductoReceiver producto, double cantidad)
        {
            _producto = producto;
            _cantidad = cantidad;
        }
    }
}