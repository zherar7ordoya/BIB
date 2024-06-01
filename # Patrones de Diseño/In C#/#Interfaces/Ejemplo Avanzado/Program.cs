using System;

namespace EjemploAvanzado
{
    public class Program
    {
        public static void Main()
        {
            // Crear una instancia de Lista
            ILista<string> miLista = new Lista<string>();

            // Suscribirse al evento ElementoAgregado
            miLista.ElementoAgregado += (sender, e) =>
            {
                Console.WriteLine("Un elemento ha sido agregado a la lista.");
            };

            // Usar las propiedades, métodos e indexadores
            miLista.Agregar("Elemento 1");
            miLista.Agregar("Elemento 2");
            Console.WriteLine($"Conteo: {miLista.Conteo}");

            Console.WriteLine($"Elemento en índice 0: {miLista[0]}");

            miLista[1] = "Elemento Modificado";
            Console.WriteLine($"Elemento en índice 1 después de modificar: {miLista[1]}");

            miLista.Remover("Elemento 1");
            Console.WriteLine($"Conteo después de remover: {miLista.Conteo}");

            // Llamar al método Imprimir
            ((IImprimible)miLista).Imprimir();

            // Parar y observar
            Console.ReadKey();
        }
    }
}