using System;
using System.Collections.Generic;

namespace Flyweight
{
    public class FlyweightFactory
    {
        readonly List<IFlyweight> flyweights = new List<IFlyweight>();
        private int conteo = 0;

        public int Conteo { get => conteo; set => conteo = value; }

        public int Agregar(string nombre)
        {
            bool existe = false;

            foreach (IFlyweight item in flyweights)
            {
                if (item.ObtenerNombre() == nombre)
                {
                    existe = true;
                }
            }
            if (existe)
            {
                Console.WriteLine("El objeto existe");
                return -1;
            }
            else
            {
                Receta receta = new Receta();
                receta.ColocarNombre(nombre);
                flyweights.Add(receta);
                conteo = flyweights.Count;
                return conteo - 1;
            }
        }

        public IFlyweight this[int index]
        {
            get { return flyweights[index]; }
        }
    }
}
