using System;

namespace PatrónAdapter_CSharp
{
    class Program
    {
        static void Main()
        {
            Motor motor1 = new MotorNaftero();
            motor1.Arrancar();
            motor1.Acelerar();
            motor1.Detener();
            motor1.CargarCombustible();

            Motor motor2 = new MotorDiesel();
            motor2.Arrancar();
            motor2.Acelerar();
            motor2.Detener();
            motor2.CargarCombustible();

            Motor motor3 = new MotorElectricoAdapter();
            motor3.Arrancar();
            motor3.Acelerar();
            motor3.Detener();
            motor3.CargarCombustible();

            Console.ReadKey();
        }
    }
}
