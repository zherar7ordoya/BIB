using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Strategy.Core
{
    public abstract class Arma
    {

        public override string ToString()
        {
            return this.GetType().Name;
        }
        public abstract string Disparar();

    }
}
