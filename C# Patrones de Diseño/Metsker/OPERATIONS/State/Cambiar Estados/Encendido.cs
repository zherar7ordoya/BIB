namespace State
{
    public class Encendido : Estado
    {
        public override void CambiarEstado(Switch sw)
        {
            sw.DefinirEstado(new StandBy());
        }

        public override string InformarEstado()
        {
            return "Estado:\tEncendido";
        }
    }
}
