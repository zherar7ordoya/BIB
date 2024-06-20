using System;
using TD.Patrones.Chain;

namespace Patrones.Chain.Core
{
    public class DirectorGeneral : Aprobador
    {
        public override void Procesar(Compra c)
        {
            Console.WriteLine(string.Format("Compra aprobada por el {0}", GetType().Name));
        }
    }
}
