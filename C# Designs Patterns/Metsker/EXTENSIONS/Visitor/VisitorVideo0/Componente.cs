namespace VisitorVideo0
{
    public abstract class Componente
    {
        public Componente(string serial) => _serial = serial;

        readonly string _serial;
        public string Serial => _serial;

        public abstract void Aceptar(IVisitor visitor);
    }
}
