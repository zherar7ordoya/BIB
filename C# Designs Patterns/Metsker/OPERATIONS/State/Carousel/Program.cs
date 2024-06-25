using System;


namespace Carousel
{
    class Program
    {
        static void Main()
        {
            // Crear una instancia de la clase Door
            Door door = new Door();

            // Suscribir un método al evento Change para mostrar el estado actual cada vez que cambie
            door.Change += () => Console.WriteLine($"\nEstado de la puerta: {door.Status()}");

            // Mostrar el estado inicial de la puerta
            Console.WriteLine($"Estado inicial de la puerta: {door.Status()}");

            // Simular interacciones
            Console.WriteLine("\nSe presiona el botón de la puerta...");
            door.Touch();  // Debería abrir la puerta
            Console.WriteLine("\nLa puerta completa su apertura...");
            door.Complete();  // La puerta debería estar abierta

            Console.WriteLine("\nLa puerta se deja abierta y el sistema indica timeout...");
            door.Timeout();  // La puerta debería comenzar a cerrar

            Console.WriteLine("\nLa puerta está cerrándose, pero se presiona el botón...");
            door.Touch();  // La puerta debería empezar a abrirse de nuevo

            Console.WriteLine("\nLa puerta completa su apertura...");
            door.Complete();  // La puerta debería estar abierta de nuevo

            Console.WriteLine("\nSe presiona el botón para mantener la puerta abierta...");
            door.Touch();  // La puerta debería mantenerse abierta

            Console.WriteLine("\nSe presiona el botón para cerrar la puerta...");
            door.Touch();  // La puerta debería comenzar a cerrarse

            Console.WriteLine("\nLa puerta completa su cierre...");
            door.Complete();  // La puerta debería estar cerrada

            // Esperar a que el usuario presione una tecla para salir
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
