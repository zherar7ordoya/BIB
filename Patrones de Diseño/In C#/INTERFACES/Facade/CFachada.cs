namespace Subsistemas
{
    public class CFachada
    {
        readonly CSistemaCompra compra = new CSistemaCompra();
        readonly CSubSistemaAlmacen almacen = new CSubSistemaAlmacen();
        readonly CSubSistemaEnvio envio = new CSubSistemaEnvio();

        public void Compra()
        {
            if (compra.Comprar())
            {
                if (almacen.SacarAlmacen())
                {
                    envio.EnviarPedido();
                }
            }
        }
    }
}
