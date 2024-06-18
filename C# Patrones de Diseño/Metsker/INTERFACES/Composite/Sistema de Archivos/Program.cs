using System;

namespace CompositeSistemaDeArchivos
{
    class Program
    {
        static void Main()
        {
            Componente root = new Directorio("raiz");

            Componente archivo1 = new Archivo("archivo1.txt", 10);
            Componente archivo2 = new Archivo("archivo2.txt", 30);
            Componente archivo3 = new Archivo("archivo3.txt", 120);
            Componente archivo4 = new Archivo("archivo4.txt", 800);
            Componente archivo5 = new Archivo("archivo5.txt", 340);

            Componente dir1 = new Directorio("dir1");
            Componente dir2 = new Directorio("dir2");
            Componente dir3 = new Directorio("dir3");

            dir1.AgregarHijo(archivo1);
            dir2.AgregarHijo(archivo2);
            dir3.AgregarHijo(archivo3);
            dir3.AgregarHijo(archivo4);
            dir1.AgregarHijo(dir3);

            root.AgregarHijo(dir1);
            root.AgregarHijo(dir2);
            root.AgregarHijo(archivo5);

            Console.WriteLine($"El tamaño del directorio {root.Nombre} es {root.Tamaño}");
            Console.WriteLine($"El tamaño del directorio {dir1.Nombre} es {dir1.Tamaño}");
            Console.WriteLine($"El tamaño del directorio {dir2.Nombre} es {dir2.Tamaño}");
            Console.WriteLine($"El tamaño del directorio {dir3.Nombre} es {dir3.Tamaño}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nJerarquía de archivos y directorios:");
            Console.ResetColor();
            DibujadorDeJerarquia.Dibujar(root);

            Console.ReadKey();
        }
    }
}
