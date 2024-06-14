using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paso5
{
    public class Empleado : IID
    {
        public int Id { get; set; }
        public int DNI { get; set; }
        public string NombreApellido { get; set; }
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Cajero, Chofer, Estibador, Logístico, Vendedor
        /// </summary>
        public string Puesto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


        // Login
        public string Username { get; set; }
        public string Password { get; set; }
        public int Intento { get; set; }


        // Define el formato para mostrar al empleado.
        public override string ToString()
        {
            return $"Empleado #{Id}\n" +
                   $"DNI: {DNI}\n" +
                   $"Nombre: {NombreApellido}\n" +
                   $"Fecha de Alta: {FechaAlta:yyyy-MM-dd}\n" +
                   $"Puesto: {Puesto}\n" +
                   $"Dirección: {Direccion}\n" +
                   $"Teléfono: {Telefono}\n" +
                   $"Email: {Email}";
        }
    }
}
