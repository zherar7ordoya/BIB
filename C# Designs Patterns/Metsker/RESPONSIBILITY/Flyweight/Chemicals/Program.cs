using System;

namespace Chemicals
{
    class Program
    {
        static void Main()
        {
            // Agregar un nuevo químico en tiempo de ejecución
            ChemicalFactory.AddChemical("water", "H2O", 18);

            IChemical saltpeter = ChemicalFactory.GetChemical("saltpeter");
            Substance saltpeterBatch = new Substance(500, saltpeter);

            IChemical water = ChemicalFactory.GetChemical("water");
            Substance waterBatch = new Substance(1000, water);

            Console.WriteLine("Saltpeter Batch:");
            Console.WriteLine($"Substance: {saltpeterBatch.Name}");
            Console.WriteLine($"Symbol: {saltpeterBatch.Symbol}");
            Console.WriteLine($"Atomic Weight: {saltpeterBatch.AtomicWeight}");
            Console.WriteLine($"Grams: {saltpeterBatch.Grams}");
            Console.WriteLine($"Moles: {saltpeterBatch.Moles}");
            Console.WriteLine();

            Console.WriteLine("Water Batch:");
            Console.WriteLine($"Substance: {waterBatch.Name}");
            Console.WriteLine($"Symbol: {waterBatch.Symbol}");
            Console.WriteLine($"Atomic Weight: {waterBatch.AtomicWeight}");
            Console.WriteLine($"Grams: {waterBatch.Grams}");
            Console.WriteLine($"Moles: {waterBatch.Moles}");

            Console.ReadLine();
        }
    }
}
