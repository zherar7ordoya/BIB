/*
 * Evaluación del Código Original
 * 
 * -) Complejidad:  El código original es complejo y puede ser difícil de seguir 
 *                  y mantener. Implementa un patrón Iterator bastante detallado
 *                  para diferenciar entre nodos hoja y nodos compuestos.
 * -) Necesidad:    La diferenciación explícita entre hojas y compuestos puede no
 *                  ser necesaria en todas las aplicaciones. Si la estructura de
 *                  datos es relativamente simple, un enfoque recursivo directo
 *                  podría ser más apropiado.
 * -) Flexibilidad: La implementación de Metsker proporciona una gran flexibilidad
 *                  y control sobre la iteración, permitiendo personalizar la
 *                  manera en que se recorren los nodos. Sin embargo, esta
 *                  flexibilidad viene con un costo en términos de complejidad.
 *
 * ¿Valía la Pena?
 * Para muchos casos prácticos, la respuesta sería no. La implementación de Metsker
 * es útil en escenarios donde necesitas un control muy fino sobre la iteración 
 * y la distinción entre diferentes tipos de nodos en una estructura compleja.
 * Pero para la mayoría de las aplicaciones estándar, esta complejidad no se
 * justifica.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeIterator
{
    class Program
    {
        static void Main()
        {
            // Crear una estructura composite de ejemplo
            Composite root = new Composite("root");
            Composite child1 = new Composite("child1");
            Leaf leaf1 = new Leaf("leaf1");
            Leaf leaf2 = new Leaf("leaf2");

            root.Add(child1);
            root.Add(leaf1);
            child1.Add(leaf2);

            // Iterar y mostrar todos los componentes
            foreach (var component in root.GetAllComponents())
            {
                Console.WriteLine(component);
            }

            Console.ReadKey();
        }
    }

    public interface IComponent
    {
        string Name { get; }
        IEnumerable<IComponent> GetAllComponents();
    }

    public class Composite : IComponent
    {
        private List<IComponent> _children = new List<IComponent>();

        public Composite(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Add(IComponent component)
        {
            _children.Add(component);
        }

        public IEnumerable<IComponent> GetAllComponents()
        {
            yield return this;
            foreach (var child in _children.SelectMany(child => child.GetAllComponents()))
            {
                yield return child;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Leaf : IComponent
    {
        public Leaf(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IEnumerable<IComponent> GetAllComponents()
        {
            yield return this;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
