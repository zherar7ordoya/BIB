namespace VisitorVideo0
{
    public class DiscoRigido : Componente
    {
        public DiscoRigido(string serial) : base(serial) { }
      
        public override void Aceptar(IVisitor visitor)
        {
            visitor.Visitar(this);
        }
    }
}
