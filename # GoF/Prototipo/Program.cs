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
            CPersona uno = (CPersona)admin.ObtenPrototipo("Persona");
            CPersona dos = (CPersona)admin.ObtenPrototipo("Persona");

            // Verificamos que tengan los valores del prototipo original
            Console.WriteLine(uno);
            Console.WriteLine(dos);
            Console.WriteLine("**********************************************");

            // Modificamos el estado

        }
    }
}
