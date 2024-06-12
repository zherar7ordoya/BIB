using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionSOAP
{
    [Serializable]
    internal class CAuto
    {
        private readonly string modelo;
        private readonly double costo;

        public CAuto(string pModelo, double pCosto)
        {
            modelo = pModelo;
            costo = pCosto;
        }

        public void MuestraInformacion()
        {
            Console.WriteLine("Modelo: {0}", modelo);
            Console.WriteLine("Costo: {0}", costo);
        }
    }
}
