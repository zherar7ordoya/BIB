/*
 * A code generator inserts behavior that provides the illusion that an object
 * executing on another machine is local.
 */

using System;
using Proxy.Application;
using Real.Application;

namespace Proxy
{
    class Program
    {
        static void Main()
        {
            try
            {
                IRepository repositorio = new CustomerRepositoryProxy();

                Session.CanSave = false;
                Session.CanGetAll = true;

                // Este patrón, ¿no debería estar manejando un solo cliente?
                // No. Este ejemplo está diseñado para ilustrar cómo el patrón
                // Proxy puede controlar el acceso a funcionalidades basadas en
                // roles o permisos globales, en lugar de permisos individuales
                // por cliente.
                Customer cliente1 = new Customer("Cliente 1");
                Customer cliente2 = new Customer("Cliente 2");

                foreach (var cliente in repositorio.GetAll())
                {
                    Console.WriteLine($"{cliente.Name}");
                }

                repositorio.GetAll();
                repositorio.Save(cliente2);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.ReadKey();
        }
    }
}
