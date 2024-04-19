using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo
{
    public class CValores : IPrototipo
    {
        private double sumatoria;
        private int m = 1;

        public double Sumatoria
        {
            get { return sumatoria; }
            set { sumatoria = value; }
        }
        public int M
        {
            get { return m; }
            set { m = value; }
        }

        public CValores() { }

        // Éste es el constructor costoso
        public CValores(int pM)
        {
            m = pM;
            for (int n = 0; n < 90; n++)
            {
                sumatoria += Math.Sin(n * 0.0175);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", sumatoria * m);
        }

        public object Clonar()
        {
            CValores clon = new CValores();
            clon.M = m;
            clon.Sumatoria = sumatoria;
            return clon;
        }
    }
}
