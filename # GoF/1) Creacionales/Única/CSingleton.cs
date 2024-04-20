using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Única
{
    public class CSingleton
    {
        private static CSingleton instancia = null;
        private string nombre = string.Empty;
        private int edad = 0;

        private CSingleton()
        {
            nombre = "Sin asignar";
            edad = 99;
        }

        public static CSingleton ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CSingleton();
                Console.WriteLine("Se ha creado una instancia de la clase CSingleton");
            }
            return instancia;
        }

        public override string ToString()
        {
            return "Nombre: " + nombre + " Edad: " + edad;
        }

        public void PonerDatos(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public void AlgunProceso()
        {
            Console.WriteLine("{0} está trabajando en algo", nombre);
        }
    }
}
