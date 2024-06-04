namespace PatrónAdapter_CSharp
{
    public class MotorElectricoAdapter : IMotor
    {
        MotorElectrico motorElectrico = new MotorElectrico();

        public void Acelerar()
        {
            motorElectrico.Mover();
        }

        public void Arrancar()
        {
            motorElectrico.Conectar();
            motorElectrico.Activar();
        }

        public void CargarCombustible()
        {
            motorElectrico.Enchufar();
        }

        public void Detener()
        {
            motorElectrico.Desactivar();
            motorElectrico.Parar();
        }
    }
}
