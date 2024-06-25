namespace State
{
    public class Apagado : Estado
    {
        public override void CambiarEstado(Switch cambio)
        {
            cambio.DefinirEstado(new Encendido());
        }

        public override string InformarEstado()
        {
            return "Estado:\tApagado";
        }
    }
}
