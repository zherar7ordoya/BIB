using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionBinaria
{
    [Serializable]
    internal class CAuto
    {
        private string modelo;
        private double costo;

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
