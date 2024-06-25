namespace State
{
    public class Apagado : Estado
    {
        public override void CambiarEstado(Switch sw)
        {
            sw.DefinirEstado(new Encendido());
        }

        public override string InformarEstado()
        {
            return "Estado:\tApagado";
        }
    }
}
