namespace PatrónAdapter_CSharp
{
    public class MotorDiesel : IMotor
    {
        public string Acelerar() => "Acelerando el motor diesel..";
        public string Arrancar() => "Arrancando el motor diesel..";
        public string CargarCombustible() => "Cargando combustible al motor diesel..";
        public string Detener() => "Deteniendo el motor diesel...";
    }
}
