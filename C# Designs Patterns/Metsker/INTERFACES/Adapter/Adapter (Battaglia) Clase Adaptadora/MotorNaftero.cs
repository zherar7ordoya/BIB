namespace PatrónAdapter_CSharp
{
    public class MotorNaftero : IMotor
    {
        public string Acelerar() => "Acelerando el motor naftero..";
        public string Arrancar() => "Arrancando el motor naftero..";
        public string CargarCombustible() => "Cargando combustible al motor naftero..";
        public string Detener() => "Deteniendo el motor naftero...";
    }
}
