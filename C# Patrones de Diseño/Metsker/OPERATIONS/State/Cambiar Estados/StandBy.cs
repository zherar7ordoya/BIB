namespace State
{
    public class StandBy : Estado
    {
        public override void CambiarEstado(Switch sw)
        {
            sw.DefinirEstado(new Apagado());
        }

        public override string InformarEstado()
        {
            return "Estado:\tStand-By";
        }
    }
}
