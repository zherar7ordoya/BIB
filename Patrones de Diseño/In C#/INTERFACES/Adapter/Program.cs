using System;

namespace PatrónAdapter_CSharp
{
    class Program
    {
        static void Main()
        {
            IMotor motor1 = new MotorNaftero();
            motor1.Arrancar();
            motor1.Acelerar();
            motor1.Detener();
            motor1.CargarCombustible();

            Console.WriteLine();

            IMotor motor2 = new MotorDiesel();
            motor2.Arrancar();
            motor2.Acelerar();
            motor2.Detener();
            motor2.CargarCombustible();

            Console.WriteLine();

            IMotor motor3 = new MotorElectricoAdapter();
            motor3.Arrancar();
            motor3.Acelerar();
            motor3.Detener();
            motor3.CargarCombustible();

            Console.ReadKey();
        }
    }
}
