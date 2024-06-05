using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class CFachada
    {
        private CSistemaCompra compra =new CSistemaCompra();
        private CSubsistemaAlmacen almacen =new CSubsistemaAlmacen();
        private CSubsitemaEnvio envio =new CSubsitemaEnvio();

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
