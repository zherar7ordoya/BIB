namespace Patrones.Command.Core
{
    public class AltaStockCommand : OrdenCommand
    {
        public AltaStockCommand(ProductoReceiver producto,
                                double cantidad) : base(producto, cantidad)
        {
        }

        public override void Ejecutar()
        {
            _producto.SumarStock(_cantidad);
        }
    }
}