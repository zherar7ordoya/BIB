using System;

namespace PatrónAdapter_CSharp
{
    public class MotorNaftero : IMotor
    {
        public void Acelerar()
        {
            Console.WriteLine("Acelerando el motor naftero..");
        }

        public void Arrancar()
        {
            Console.WriteLine("Arrancando el motor naftero..");
        }

        public void CargarCombustible()
        {
            Console.WriteLine("Cargando combustible al motor naftero..");
        }

        public void Detener()
        {
            Console.WriteLine("Deteniendo el motor naftero..");
        }
    }
}
