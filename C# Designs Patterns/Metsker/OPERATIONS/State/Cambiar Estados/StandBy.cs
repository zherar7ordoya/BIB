namespace State
{
    public class StandBy : Estado
    {
        public override void CambiarEstado(Switch cambio)
        {
            cambio.DefinirEstado(new Apagado());
        }

        public override string InformarEstado()
        {
            return "Estado:\tStand-By";
        }
    }
}
