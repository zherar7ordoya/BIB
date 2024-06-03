using System;

namespace PatrónAdapter_CSharp
{
    public class MotorDiesel : IMotor
    {
        public void Acelerar()
        {
            Console.WriteLine("Acelerando el motor diesel..");
        }

        public void Arrancar()
        {
            Console.WriteLine("Arrancando el motor diesel..");
        }

        public void CargarCombustible()
        {
            Console.WriteLine("Cargando combustible al motor diesel..");
        }

        public void Detener()
        {
            Console.WriteLine("Deteniendo el motor diesel..");
        }
    }
}
