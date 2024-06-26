using System;

namespace Recommendations
{
    class Program
    {
        static void Main()
        {
            /// <summary>
            /// I just used this to ensure I was actually finding the 
            /// properties file that lists a strategic promotion. If you 
            /// set your classpath to include the "oozinoz" directory that 
            /// you can download from oozinoz.com, this program will find 
            /// the strategy.dat file that lists a promoted firework. In 
            /// short it's an example of finding and reading from a 
            /// properties file.
            /// </summary>
            new Customer().GetRecommended();

            // Crear una instancia del cliente
            Customer customer = new Customer();

            // Obtener la recomendación de producto
            Firework recommendedFirework = customer.GetRecommended();
            // Si prefieres usar el método refactorizado, usa GetRecommended_2
            // Firework recommendedFirework = customer.GetRecommended_2();

            // Imprimir detalles del producto recomendado
            if (recommendedFirework != null)
            {
                Console.WriteLine("Producto recomendado:");
                Console.WriteLine($"Nombre: {recommendedFirework.Name}");
                Console.WriteLine($"Peso: {recommendedFirework.Mass} kg");
                Console.WriteLine($"Precio: ${recommendedFirework.Price}");
            }
            else
            {
                Console.WriteLine("No se pudo recomendar un producto.");
            }

            // Esperar a que el usuario presione una tecla para salir
            Console.ReadKey();
        }
    }
}
