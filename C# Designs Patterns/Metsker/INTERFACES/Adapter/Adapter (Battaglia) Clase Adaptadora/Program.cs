using System;

namespace PatrónAdapter_CSharp
{
    class Program
    {
        static void Main()
        {
            IMotor motor1 = new MotorNaftero();
            Console.WriteLine(motor1.Arrancar());
            Console.WriteLine(motor1.Acelerar());
            Console.WriteLine(motor1.Detener());
            Console.WriteLine(motor1.CargarCombustible());

            IMotor motor2 = new MotorDiesel();
            Console.WriteLine(motor2.Arrancar());
            Console.WriteLine(motor2.Acelerar());
            Console.WriteLine(motor2.Detener());
            Console.WriteLine(motor2.CargarCombustible());

            IMotor motor3 = new MotorElectricoAdapter();
            Console.WriteLine(motor3.Arrancar());
            Console.WriteLine(motor3.Acelerar());
            Console.WriteLine(motor3.Detener());
            Console.WriteLine(motor3.CargarCombustible());

            Console.ReadKey();
        }
    }
}
