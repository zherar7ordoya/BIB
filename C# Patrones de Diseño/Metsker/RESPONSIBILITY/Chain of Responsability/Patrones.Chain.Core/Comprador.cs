using System;

namespace TD.Patrones.Chain
{
    public class Comprador : Aprobador
    {
        public override void Procesar(Compra compra)
        {
            if (compra.Importe < 100)
            {
                Console.WriteLine(string.Format("Compra aprobada por el {0}", GetType().Name));
            }
            else
            {
                _siguiente.Procesar(compra);
            }
        }
    }
}