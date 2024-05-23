using System;

namespace CalderaApp
{
    class Program
    {
        static void Main()
        {
            // Crear una instancia de la caldera con una temperatura inicial
            Caldera miCaldera = new Caldera(50);

            // Suscribirse a los eventos
            miCaldera.CalderaMuyCaliente += () => Console.WriteLine("¡Advertencia! La caldera está muy caliente.");
            miCaldera.CalderaMuyFria += () => Console.WriteLine("¡Advertencia! La caldera está muy fría.");

            // Cambiar la temperatura usando los delegados
            Console.WriteLine($"Temperatura inicial: {miCaldera.Temperatura}°C");

            miCaldera.Incrementar(30);
            Console.WriteLine($"Temperatura actual: {miCaldera.Temperatura}°C");

            miCaldera.Incrementar(30);
            Console.WriteLine($"Temperatura actual: {miCaldera.Temperatura}°C");

            miCaldera.Decrementar(90);
            Console.WriteLine($"Temperatura actual: {miCaldera.Temperatura}°C");

            miCaldera.Decrementar(30);
            Console.WriteLine($"Temperatura actual: {miCaldera.Temperatura}°C");

            Console.ReadKey();
        }
    }
}
