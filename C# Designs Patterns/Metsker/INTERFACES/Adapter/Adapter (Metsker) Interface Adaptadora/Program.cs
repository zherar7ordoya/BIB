/*
 * A fireworks simulation designer establishes an interface that defines the
 * behaviors your object must possess to participate in the simulation.
 * De paso, ver las notas en IRocketSim.cs
 */

using System;

namespace AdapterInterface
{
    internal class Program
    {
        static void Main()
        {
            IRocketSim sim = new OozinozRocket(0.1, 0.1, 1000, 10000);
            sim.SetSimTime(0.0);
            Console.WriteLine("Mass is " + sim.GetMass());
            Console.WriteLine("Thrust is " + sim.GetThrust());
            sim.SetSimTime(2.0);
            Console.WriteLine("Mass is " + sim.GetMass());
            Console.WriteLine("Thrust is " + sim.GetThrust());
            Console.ReadKey();
        }
    }
}
