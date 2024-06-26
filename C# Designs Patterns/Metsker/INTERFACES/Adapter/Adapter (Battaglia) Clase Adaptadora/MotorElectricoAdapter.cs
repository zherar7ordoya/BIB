/*
Éste es, según el libro, el caso «Clase Adaptadora» (el peor de los casos).
*/
namespace PatrónAdapter_CSharp
{
    public class MotorElectricoAdapter : IMotor
    {
        readonly MotorElectrico motorElectrico = new MotorElectrico();

        public string Acelerar() => motorElectrico.Mover();
        public string Arrancar()
        {
            return motorElectrico.Conectar() + motorElectrico.Activar();
        }

        public string CargarCombustible() => motorElectrico.Enchufar();

        public string Detener()
        {
            return motorElectrico.Desactivar() + motorElectrico.Parar();
        }
    }
}
