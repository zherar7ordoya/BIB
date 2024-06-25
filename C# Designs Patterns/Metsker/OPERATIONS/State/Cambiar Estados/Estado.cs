namespace State
{
    public abstract class Estado
    {
        public abstract void CambiarEstado(Switch cambio);
        public abstract string InformarEstado();
    }
}
