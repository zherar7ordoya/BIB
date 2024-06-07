using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploMachine
{
    internal class Program
    {
        static void Main()
        {
            MachineComponent machine1 = new Machine("Máquina 1");
            MachineComponent machine2 = new Machine("Máquina 2");
            MachineComponent machine3 = new Machine("Máquina 3");
            MachineComponent machine4 = new Machine("Máquina 4");
            MachineComponent machine5 = new Machine("Máquina 5");
            MachineComponent machine6 = new Machine("Máquina 6");
            MachineComponent machine7 = new Machine("Máquina 7");
            MachineComponent machine8 = new Machine("Máquina 8");
            MachineComponent machine9 = new Machine("Máquina 9");
            MachineComponent machine10 = new Machine("Máquina 10");

            MachineComponent composite1 = new MachineComposite("Compuesto 1");
            MachineComponent composite2 = new MachineComposite("Compuesto 2");
            MachineComponent composite3 = new MachineComposite("Compuesto 3");
            MachineComponent composite4 = new MachineComposite("Compuesto 4");

            composite1.AddMachine(machine1);
            composite1.AddMachine(machine2);
            composite1.AddMachine(machine3);

            composite2.AddMachine(machine4);
            composite2.AddMachine(machine5);
            composite2.AddMachine(machine6);

            composite3.AddMachine(machine7);
            composite3.AddMachine(machine8);
            composite3.AddMachine(machine9);

            composite4.AddMachine(machine10);

            composite1.AddMachine(composite2);
            composite1.AddMachine(composite3);
            composite1.AddMachine(composite4);

            Dibujante.Dibujar(composite1);
            Console.WriteLine();
            Console.WriteLine("Total machines: " + composite1.GetMachineCount());
            Console.ReadKey();
        }
    }

    public abstract class MachineComponent
    {
        readonly string _nombre;
        public string Nombre { get { return _nombre; } }
        public MachineComponent(string nombre)
        {
            _nombre = nombre;
        }
        public abstract void AddMachine(MachineComponent machine);
        public abstract void RemoveMachine(MachineComponent machine);
        public abstract int GetMachineCount();
        public abstract IList<MachineComponent> GetMachineComponents();
    }

    public class Machine : MachineComponent
    {
        public Machine(string nombre) : base(nombre) { }
        public override void AddMachine(MachineComponent machine) { }
        public override void RemoveMachine(MachineComponent machine) { }
        public override int GetMachineCount()
        {
            return 1;
        }
        public override IList<MachineComponent> GetMachineComponents()
        {
            return null;
        }
    }

    public class MachineComposite : MachineComponent
    {
        readonly List<MachineComponent> _components;
        public MachineComposite(string nombre) : base(nombre)
        {
            _components = new List<MachineComponent>();
        }

        public override void AddMachine(MachineComponent machine)
        {
            _components.Add(machine);
        }

        public override void RemoveMachine(MachineComponent machine)
        {
            _components.Remove(machine);
        }

        public override int GetMachineCount()
        {
            int count = 0;
            foreach (MachineComponent mc in _components)
            {
                count += mc.GetMachineCount();
            }
            return count;
        }
        public override IList<MachineComponent> GetMachineComponents()
        {
            return _components;
        }
    }

    public static class Dibujante
    {
        public static void Dibujar(MachineComponent componente, string indent = "")
        {
            Console.WriteLine($"{indent} - {componente.Nombre}");
            var hijos = componente.GetMachineComponents();
            if (hijos != null)
            {
                foreach (var hijo in hijos)
                {
                    Dibujar(hijo, indent + "\t");
                }
            }
        }
    }
}
