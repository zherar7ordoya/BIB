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
            Composite root = new Composite("Root");
            Composite child1 = new Composite("Child 1 (pertenece a Root)");
            Leaf leaf1 = new Leaf("Leaf 1 (pertenece a Root)");
            Leaf leaf2 = new Leaf("Leaf 2 (pertenece a Child 1)");

            root.Add(child1);
            root.Add(leaf1);
            child1.Add(leaf2);

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

    // Clase Composite que puede contener otros IComponent (nodos e hojas)
    public class Composite : IComponent
    {
        // Constructor: Asignar el nombre al composite
        public Composite(string name) => Name = name;
        public string Name { get; }
        public override string ToString() => Name;

        readonly List<IComponent> _children = new List<IComponent>();
        public void Add(IComponent component) => _children.Add(component);

        /// <summary>
        /// Método para obtener todos los componentes (el propio composite y sus hijos)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IComponent> GetAllComponents()
        {
            // Retornar el propio composite primero
            yield return this;

            // Retornar recursivamente todos los hijos y los componentes dentro
            // de ellos. SelectMany aplana estas secuencias en una sola secuencia
            // continua de componentes. VER NOTA ABAJO.
            foreach (var child in _children.SelectMany(child => child.GetAllComponents()))
            {
                yield return child;
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////
    /*
     * ¿Por Qué yield return Simplifica?
     * 
     * Mantenimiento del Estado:
     * yield return se encarga de mantener el estado de la iteración entre
     * llamadas. No tienes que preocuparte por las variables de estado o por
     * implementar interfaces adicionales.
     * 
     * Recursividad Simplificada:
     * El método puede llamarse a sí mismo recursivamente sin necesidad de
     * complejos bucles o estructuras de datos adicionales para gestionar el
     * recorrido jerárquico.
     * 
     * Claridad y Brevedad:
     * El código es más claro y más fácil de leer. No necesitas escribir mucho
     * código para lograr un iterador complejo.
     */
    ////////////////////////////////////////////////////////////////////////////

    // Clase Leaf que representa una hoja en la estructura composite
    public class Leaf : IComponent
    {
        // Constructor: Asignar el nombre a la hoja
        public Leaf(string name) => Name = name;
        public string Name { get; }
        public override string ToString() => Name;

        // Método para obtener todos los componentes (solo retorna la propia hoja)
        public IEnumerable<IComponent> GetAllComponents()
        {
            yield return this;
        }
    }
}
