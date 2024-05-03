using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializacionXML
{
    [Serializable]
    public class CAuto
    {
        [XmlAttribute]
        public int Codigo { get ; set ; }
        public string Modelo { get; set; }
        public double Costo { get; set; }

        // El constructor no debe tener parámetros
        //public CAuto()
        //{
        //    Modelo = "Vocho";
        //    Costo = 100000;
        //}

        public void MuestraInformacion()
        {
            Console.WriteLine("Modelo: {0}", Modelo);
            Console.WriteLine("Costo: {0}", Costo);
        }
    }
}
