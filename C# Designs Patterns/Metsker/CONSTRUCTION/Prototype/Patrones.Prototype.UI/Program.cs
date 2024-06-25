using Patrones.Prototype.Core;

using System;

namespace Patrones.Prototype.UI
{
    class Program
    {
        static void Main()
        {
            AutoPrototype fiat = new FiatPrototype();
            AutoPrototype ds = new DSPrototype();
            AutoPrototype alfa = new AlfaRomeoPrototype();

            AutoPrototype fiatPalio = fiat.Clonar();
            fiatPalio.Modelo = "Palio Fire";
            fiatPalio.Color = "negro";
            Console.WriteLine(fiatPalio.VerAuto());

            AutoPrototype fiatUno = fiat.Clonar();
            fiatUno.Modelo = "Uno SRC";
            fiatUno.Color = "blanco";
            Console.WriteLine(fiatUno.VerAuto());

            AutoPrototype ds3 = ds.Clonar();
            ds3.Modelo = "3 Chic";
            ds3.Color = "blanco";
            Console.WriteLine(ds3.VerAuto());

            AutoPrototype ds4 = ds.Clonar();
            ds4.Modelo = "4 Sport";
            ds4.Color = "negro";
            Console.WriteLine(ds4.VerAuto());

            AutoPrototype alfa145 = alfa.Clonar();
            alfa145.Modelo = "145";
            alfa145.Color = "negro";
            Console.WriteLine(alfa145.VerAuto());

            AutoPrototype alfa146 = alfa.Clonar();
            alfa146.Modelo = "146";
            alfa146.Color = "blanco";
            Console.WriteLine(alfa146.VerAuto());

            Console.ReadKey();
        }
    }
}
