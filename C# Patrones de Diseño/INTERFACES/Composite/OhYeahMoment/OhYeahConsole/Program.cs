using System;
using System.Collections.Generic;

namespace OhYeahConsole
{
    // Componente base
    abstract class Autorizacion
    {
        public string Nombre { get; set; }
        public abstract void MostrarPermisos();
    }

    // Hoja
    class Permiso : Autorizacion
    {
        public Permiso(string nombre)
        {
            Nombre = nombre;
        }

        public override void MostrarPermisos()
        {
            Console.WriteLine(Nombre);
        }
    }

    // Compuesto
    class Rol : Autorizacion
    {
        readonly List<Autorizacion> _permisos = new List<Autorizacion>();

        public Rol(string nombre)
        {
            Nombre = nombre;
        }

        public void AgregarPermiso(Autorizacion permiso)
        {
            _permisos.Add(permiso);
        }

        public void RemoverPermiso(Autorizacion permiso)
        {
            _permisos.Remove(permiso);
        }

        public override void MostrarPermisos()
        {
            Console.WriteLine("\nRol: " + Nombre);
            foreach (var permiso in _permisos)
            {
                permiso.MostrarPermisos();
            }
        }
    }

    // Ejemplo de uso
    class Program
    {
        static void Main()
        {
            Permiso venta = new Permiso("Acceso a Ventas");
            Permiso orden = new Permiso("Acceso a Órdenes");
            Permiso facturacion = new Permiso("Acceso a Facturación");

            Rol vendedor = new Rol("Vendedor");
            vendedor.AgregarPermiso(venta);
            vendedor.AgregarPermiso(orden);

            Rol cajero = new Rol("Cajero");
            cajero.AgregarPermiso(venta);
            cajero.AgregarPermiso(facturacion);

            Rol gerente = new Rol("Gerente");
            gerente.AgregarPermiso(vendedor);
            gerente.AgregarPermiso(cajero);

            vendedor.MostrarPermisos();
            cajero.MostrarPermisos();
            gerente.MostrarPermisos();

            Console.ReadKey();
        }
    }
}
