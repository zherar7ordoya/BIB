using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creamos el administrador
            CAdminPrototipos admin = new CAdminPrototipos();

            // Obtenemos dos instancias
            CPersona uno = (CPersona)admin.ObtenerPrototipo("Persona");
            CPersona dos = (CPersona)admin.ObtenerPrototipo("Persona");

            // Verificamos que tengan los valores del prototipo original
            Console.WriteLine(uno);
            Console.WriteLine(dos);
            Console.WriteLine("-*-*-*-*-*-");

            // Modificamos el estado
            uno.Nombre = "Pedro";
            dos.Nombre = "Maria";

            // Verificamos que cada quien tenga su propio estado
            Console.WriteLine(uno);
            Console.WriteLine(dos);
            Console.WriteLine("-*-*-*-*-*-");

            // Creamos una instancia
            CAuto auto = new CAuto("Ford", 2010);

            // Lo colocamos como prototipo
            admin.AdicionarPrototipo("Auto", auto);

            // Obtenemos un objeto de ese prototipo
            CAuto carro = (CAuto)admin.ObtenerPrototipo("Auto");

            // Cambiamos el estado
            carro.Modelo = "Chevrolet";

            // Verificamos que cada quien tenga su propio estado
            Console.WriteLine(auto);
            Console.WriteLine(carro);
            Console.WriteLine("-*-*-*-*-*-");

            // Obtenemos una instancia del objeto costoso
            CValores valores = (CValores)admin.ObtenerPrototipo("Valores");
            Console.WriteLine(valores);

            //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
            Console.ReadKey();
        }
    }
}
