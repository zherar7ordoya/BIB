namespace State
{
    public abstract class Estado
    {
        public abstract void CambiarEstado(Switch sw);
        public abstract string InformarEstado();
    }
}
