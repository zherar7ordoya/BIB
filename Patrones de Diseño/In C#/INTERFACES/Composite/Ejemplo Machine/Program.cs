using System;
using System.Collections.Generic;

namespace EjemploMachine
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("\nCreando máquinas individuales...");
            var machine1 = new Machine(1, "Machine 1");
            var machine2 = new Machine(2, "Machine 2");
            var machine3 = new Machine(3, "Machine 3");

            Console.WriteLine("\nCreando máquina compuesta...");
            var composite1 = new MachineComposite(4, "Composite 1");
            composite1.AddMachine(machine1);
            composite1.AddMachine(machine2);

            Console.WriteLine("\nCreando una máquina compuesta más grande...");
            var composite2 = new MachineComposite(5, "Composite 2");
            composite2.AddMachine(composite1);
            composite2.AddMachine(machine3);

            Console.WriteLine("\nImprimiendo la jerarquía de la máquina compuesta más grande...");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Tool.PrintHierarchy(composite2);
            Console.ResetColor();

            Console.WriteLine("\nProbando si máquina compuesta más grande es árbol...");
            Console.WriteLine($"IsTree (composite2): {composite2.IsTree()}");

            Console.WriteLine("\nContando las máquinas individuales de la máquina compuesta más grande...");
            Console.WriteLine($"Machine count (composite2): {composite2.GetMachineCount()}");

            Console.WriteLine("\nEliminando una máquina individual de la máquina compuesta más grande...");
            composite2.RemoveMachine(machine3);
            
            Console.WriteLine("After removing Machine 3:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Tool.PrintHierarchy(composite2);
            Console.ResetColor();

            Console.WriteLine("\nCorriendo de nuevo las pruebas sobre la máquina compuesta más grande...");
            Console.WriteLine($"IsTree (composite2): {composite2.IsTree()}");
            Console.WriteLine($"Machine count (composite2): {composite2.GetMachineCount()}");

            Console.ReadKey();
        }
    }

    public abstract class MachineComponent
    {
        readonly int _id;
        readonly string _nombre;
        public int Id { get { return _id; } }
        public string Nombre { get { return _nombre; } }

        public MachineComponent(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        public abstract void AddMachine(MachineComponent machine);
        public abstract void RemoveMachine(MachineComponent machine);
        public abstract int GetMachineCount();
        public abstract IList<MachineComponent> GetMachineComponents();
        public abstract bool IsTree();
        public abstract bool IsTree(HashSet<int> visited);
    }

    public class Machine : MachineComponent
    {
        // Constructor que inicializa una máquina con un ID y un nombre.
        public Machine(int id, string nombre) : base(id, nombre) { }

        // Método para agregar una máquina. No hace nada porque una máquina individual no puede contener otras máquinas.
        public override void AddMachine(MachineComponent machine) { }

        // Método para remover una máquina. No hace nada porque una máquina individual no puede contener otras máquinas.
        public override void RemoveMachine(MachineComponent machine) { }

        // Método que devuelve la cantidad de máquinas contenidas. Para una máquina individual, siempre es 1.
        public override int GetMachineCount()
        {
            return 1;
        }

        // Método que devuelve los componentes hijos de la máquina. Para una máquina individual, siempre es null.
        public override IList<MachineComponent> GetMachineComponents()
        {
            return null;
        }

        // Método que verifica si la estructura es un árbol. Para una máquina individual, se inicia una nueva colección HashSet y se llama a la sobrecarga de IsTree.
        public override bool IsTree()
        {
            return IsTree(new HashSet<int>());
        }

        // Método sobrecargado que verifica si la estructura es un árbol, utilizando una colección HashSet para rastrear máquinas visitadas.
        public override bool IsTree(HashSet<int> visited)
        {
            visited.Add(Id); // Agrega el ID de esta máquina al conjunto de visitados.
            return true; // Una máquina individual siempre es un árbol.
        }
    }


    public class MachineComposite : MachineComponent
    {
        // Lista para almacenar los componentes hijos de la máquina compuesta.
        readonly List<MachineComponent> _components;

        // Constructor que inicializa una máquina compuesta con un ID y un nombre.
        public MachineComposite(int id, string nombre) : base(id, nombre)
        {
            _components = new List<MachineComponent>(); // Inicializa la lista de componentes.
        }

        // Método para agregar una máquina a la lista de componentes hijos.
        public override void AddMachine(MachineComponent machine)
        {
            _components.Add(machine);
        }

        // Método para remover una máquina de la lista de componentes hijos.
        public override void RemoveMachine(MachineComponent machine)
        {
            _components.Remove(machine);
        }

        // Método que devuelve la cantidad total de máquinas contenidas en esta máquina compuesta.
        public override int GetMachineCount()
        {
            int count = 0;
            foreach (MachineComponent mc in _components)
            {
                count += mc.GetMachineCount(); // Suma el conteo de cada componente hijo.
            }
            return count; // Devuelve el conteo total.
        }

        // Método que devuelve los componentes hijos de la máquina compuesta.
        public override IList<MachineComponent> GetMachineComponents()
        {
            return _components; // Devuelve la lista de componentes hijos.
        }

        // Método que verifica si la estructura es un árbol. Para una máquina compuesta, se inicia una nueva colección HashSet y se llama a la sobrecarga de IsTree.
        public override bool IsTree()
        {
            return IsTree(new HashSet<int>());
        }

        // Método sobrecargado que verifica si la estructura es un árbol, utilizando una colección HashSet para rastrear máquinas visitadas.
        public override bool IsTree(HashSet<int> visited)
        {
            visited.Add(Id); // Agrega el ID de esta máquina compuesta al conjunto de visitados.

            foreach (MachineComponent mc in _components)
            {
                // Verifica si el ID del componente ya ha sido visitado o si el componente no es un árbol.
                if (visited.Contains(mc.Id) || !mc.IsTree(visited))
                {
                    return false; // Si alguna de estas condiciones es verdadera, no es un árbol.
                }
            }
            return true; // Si todos los componentes son árboles, entonces es un árbol.
        }
    }


    //\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\\

    public static class Tool
    {
        public static void PrintHierarchy(MachineComponent componente, string sangria = "")
        {
            Console.WriteLine($"{sangria} - {componente.Nombre}");
            var hijos = componente.GetMachineComponents();
            if (hijos != null)
            {
                foreach (var hijo in hijos)
                {
                    PrintHierarchy(hijo, sangria + "\t");
                }
            }
        }
    }
}
