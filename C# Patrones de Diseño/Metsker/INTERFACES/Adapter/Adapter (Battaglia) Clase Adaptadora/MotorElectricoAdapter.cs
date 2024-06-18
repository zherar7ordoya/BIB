/*
Éste es, según el libro, el caso «Clase Adaptadora» (el peor de los casos).
*/
namespace PatrónAdapter_CSharp
{
    public class MotorElectricoAdapter : Motor
    {
        readonly MotorElectrico motorElectrico = new MotorElectrico();

        public override void Acelerar()
        {
            motorElectrico.Mover();
        }

        public override void Arrancar()
        {
            motorElectrico.Conectar();
            motorElectrico.Activar();

        }

        public override void CargarCombustible()
        {
            motorElectrico.Enchufar();
        }

        public override void Detener()
        {
            motorElectrico.Desactivar();
            motorElectrico.Parar();
        }
    }
}
