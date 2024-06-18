using System;

namespace PatrónAdapter_CSharp
{
    public class MotorDiesel : Motor
    {
        public override void Acelerar()
        {
            Console.WriteLine("Acelerando el motor diesel..");
        }

        public override void Arrancar()
        {
            Console.WriteLine("Arrancando el motor diesel..");
        }

        public override void CargarCombustible()
        {
            Console.WriteLine("Cargando combustible al motor diesel..");
        }

        public override void Detener()
        {
            Console.WriteLine("Deteniendo el motor diesel..");
        }
    }
}
