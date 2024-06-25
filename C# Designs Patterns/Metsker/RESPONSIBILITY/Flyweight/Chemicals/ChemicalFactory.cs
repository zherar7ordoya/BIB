using System;
using System.Collections.Generic;

namespace Chemicals
{
    /// <summary>
    ///  This class creates and returns IChemical objects. This is
    ///  a refactoring that ensures that the factory class is the
    ///  only class that can instantiate the Chemical class.
    /// </summary>
    public class ChemicalFactory
    {
        private readonly static Dictionary<string, IChemical> _chemicals = new Dictionary<string, IChemical>();

        private class Chemical : IChemical
        {
            readonly string _name;
            readonly string _symbol;
            readonly double _atomicWeight;

            internal Chemical(
                string name, string symbol, double atomicWeight)
            {
                _name = name;
                _symbol = symbol;
                _atomicWeight = atomicWeight;
            }

            public string Name
            {
                get { return _name; }
            }

            public string Symbol
            {
                get { return _symbol; }
            }

            public double AtomicWeight
            {
                get { return _atomicWeight; }
            }
        }

        static ChemicalFactory()
        {
            _chemicals["carbon"] = new Chemical("Carbon", "C", 12);
            _chemicals["sulfur"] = new Chemical("Sulfur", "S", 32);
            _chemicals["saltpeter"] = new Chemical("Saltpeter", "KNO3", 101);
            //...
        }

        /// <summary>
        /// Return the IChemical object for the given name.
        /// </summary>
        /// <param name="name">the name of the interesting chemical</param>
        /// <returns>the IChemical object for the given name</returns>
        public static IChemical GetChemical(string name)
        {
            _chemicals.TryGetValue(name.ToLower(), out IChemical chemical);
            return chemical;
        }

        /// <summary>
        /// Add a new IChemical object to the dictionary.
        /// </summary>
        /// <param name="name">The name of the chemical.</param>
        /// <param name="symbol">The symbol of the chemical.</param>
        /// <param name="atomicWeight">The atomic weight of the chemical.</param>
        public static void AddChemical(string name, string symbol, double atomicWeight)
        {
            string key = name.ToLower();
            if (!_chemicals.ContainsKey(key))
            {
                _chemicals[key] = new Chemical(name, symbol, atomicWeight);
            }
        }
    }
}
