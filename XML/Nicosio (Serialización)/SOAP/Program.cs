using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionSOAP
{
    internal class Program
    {
        static void Main()
        {
            int opcion = 0;
            string valor = "";

            Console.WriteLine("1.- Crear y serializar Auto");
            Console.WriteLine("2.- Leer (deserializar) Auto");
            Console.WriteLine("3.- Salir");
            Console.Write("Opcion: ");
            valor = Console.ReadLine();
            opcion = Convert.ToInt32(valor);

            switch (opcion)
            {
                case 1:
                    string modelo = "";
                    double costo = 0;
                    Console.Write("Modelo: ");
                    modelo = Console.ReadLine();
                    Console.Write("Costo: ");
                    valor = Console.ReadLine();
                    costo = Convert.ToDouble(valor);
                    CAuto auto = new CAuto(modelo, costo);
                    Console.WriteLine("Informacion del Auto:");
                    auto.MuestraInformacion();

                    Console.WriteLine("Serializando Auto...");
                    SoapFormatter formatter = new SoapFormatter();
                    Stream stream = new FileStream("Autos.xml", FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, auto);
                    stream.Close();
                    break;
                case 2:
                    Console.WriteLine("Deserializando Auto...");
                    formatter = new SoapFormatter();
                    stream = new FileStream("Autos.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                    auto = (CAuto)formatter.Deserialize(stream);
                    stream.Close();
                    Console.WriteLine("Informacion del Auto:");
                    auto.MuestraInformacion();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }

            Console.ReadKey();
        }
    }
}
