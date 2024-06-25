using System;

namespace TD.Patrones.Chain
{
    public class Director : Aprobador
    {
        public override void Procesar(Compra c)
        {

            if (c.Importe < 5000)
                Console.WriteLine(string.Format("Compra aprobada por el {0}", GetType().Name));
            else
                _siguiente.Procesar(c);        
        }
    }
}