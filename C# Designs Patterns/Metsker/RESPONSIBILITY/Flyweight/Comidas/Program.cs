/*
EL OBJETIVO DE ESTE PROGRAMA ES MANEJAR LA SIGUIENTE TABLA:

Tipo       | Carnes          | Sopas      | Ensaladas        | ¿?
---------- | --------------- | ---------- | ---------------- | ------
Americana  | Hamburguesa     |            | Wisconsin Cheese |
Italiana   |                 | Minestrone | Antipasto        | Pizza
Mexicana   | Tacos al pastor | Coditos    | Nopales          |

Rápida     | Hamburguesa | Tacos al pastor | Pizza |

8 en lugar de 21

8 se debe referir a los menúes:
    1) carnes
    2) sopas
    3) ensalada
    4) (suelta)
    5) americana
    6) italiana
    7) mexicana
    8) rápida

21 se debe referir a los "cruces" de menúes:
    1) Hamburguesa: americana, carnes, rápida
    2) Wisconsin Cheese: americana, ensalada
    3) Minestrone: italiana, sopas
    4) etc.
Explicación: cada platillo en la parte superior pertenece a dos categorías,
             excepto pizza (categoría suelta). Son 7 pares + 1 suelto = 15.
             En la parte inferior, 3 platillos que pertenecen a 2 categorías.
             Son 3 pares = 6. Más los anteriores: 15 + 6 = 21.
*/
using System;
using System.Collections.Generic;

namespace Flyweight
{
    internal class Program
    {
        static void Main()
        {
            List<int> Americana = new List<int>();
            List<int> Italiana = new List<int>();
            List<int> Mexicana = new List<int>();
            List<int> Carnes = new List<int>();
            List<int> Sopas = new List<int>();
            List<int> Ensaladas = new List<int>();
            List<int> Rapida = new List<int>();

            FlyweightFactory factory = new FlyweightFactory();

            int i = factory.Agregar("Hamburguesa");
            Americana.Add(i);
            Carnes.Add(i);
            Rapida.Add(i);

            i = factory.Agregar("Wisconsin cheese");
            Americana.Add(i);
            Ensaladas.Add(i);

            i = factory.Agregar("Minestrone");
            Italiana.Add(i);
            Sopas.Add(i);

            i = factory.Agregar("Antipasto");
            Ensaladas.Add(i);
            Italiana.Add(i);

            i = factory.Agregar("Tacos al pastor");
            Mexicana.Add(i);
            Carnes.Add(i);
            Rapida.Add(i);

            i = factory.Agregar("Coditos");
            Mexicana.Add(i);
            Sopas.Add(i);

            i = factory.Agregar("Pizza");
            Italiana.Add(i);
            Rapida.Add(i);

            // Con esto induzco dos errores: uno manejado y el otro no.
            //i = factory.Agregar("Pizza");
            //Italiana.Add(i);

            foreach (int n in Italiana)
            {
                Receta receta = (Receta)factory[n];
                receta.CalcularCosto();
                receta.Mostrar();
            }
            Console.WriteLine("-----");
            Console.ReadKey();
        }
    }
}
