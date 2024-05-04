using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializacionBinaria
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("1.- Crear y serializar Auto");
            Console.WriteLine("2.- Leer (deserializar) Auto");
            Console.WriteLine("3.- Salir");
            Console.Write("Opcion: ");
            string valor = Console.ReadLine();
            int opcion = Convert.ToInt32(valor);

            switch (opcion)
            {
                case 1:
                    Console.Write("Modelo: ");
                    string modelo = Console.ReadLine();

                    Console.Write("Costo: ");
                    valor = Console.ReadLine();
                    double costo = Convert.ToDouble(valor);

                    Console.Write("Cilindros: ");
                    valor = Console.ReadLine();
                    int cilindros = Convert.ToInt32(valor);

                    Console.Write("HP: ");
                    valor = Console.ReadLine();
                    int hp = Convert.ToInt32(valor);
                    CAuto auto = new CAuto();
                    CMotor motor = new CMotor();

                    motor.Cilindros = cilindros;
                    motor.HP = hp;

                    auto.Modelo = modelo;
                    auto.Costo = costo;
                    auto.Motor = motor;

                    Console.WriteLine("Informacion del Auto:");
                    auto.MuestraInformacion();

                    Console.WriteLine("Serializando Auto...");
                    BinaryFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("Auto.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, auto);
                    stream.Close();
                    break;

                case 2:
                    Console.WriteLine("Deserializando Auto...");
                    formatter = new BinaryFormatter();
                    stream = new FileStream("Auto.bin", FileMode.Open, FileAccess.Read, FileShare.None);
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
