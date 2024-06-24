using System;

namespace State
{
    class Program
    {
        static void Main()
        {
            Switch _switch = new Switch();

            _switch.PulsarBoton();
            _switch.PulsarBoton();
            _switch.PulsarBoton();
            _switch.PulsarBoton();
            _switch.PulsarBoton();
            _switch.PulsarBoton();

            Console.ReadKey();
        }
    }
}
