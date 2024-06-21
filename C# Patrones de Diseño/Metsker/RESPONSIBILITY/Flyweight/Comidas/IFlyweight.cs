namespace Flyweight
{
    public interface IFlyweight
    {
        void ColocarNombre(string nombre);
        void CalcularCosto();
        void Mostrar();
        string ObtenerNombre();
    }
}
