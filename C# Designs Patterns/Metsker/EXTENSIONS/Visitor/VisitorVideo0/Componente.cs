namespace VisitorVideo0
{
    public abstract class Componente
    {
        string _serial;

        public Componente(string serial)
        {
            _serial = serial;
        }
        public string Serial { 
            get {
                return _serial;
            }
        }
        public abstract void Aceptar(IVisitor visitor);
    }
}
