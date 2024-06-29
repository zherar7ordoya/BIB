namespace VisitorVideo0
{
    public interface IVisitor
    {
        void Visitar(DiscoRigido componente);
        void Visitar(PlacaBase componente);
        void Visitar(Procesador componente);
    }
}
