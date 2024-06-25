namespace State
{
    public class Encendido : Estado
    {
        public override void CambiarEstado(Switch cambio)
        {
            cambio.DefinirEstado(new StandBy());
        }

        public override string InformarEstado()
        {
            return "Estado:\tEncendido";
        }
    }
}
