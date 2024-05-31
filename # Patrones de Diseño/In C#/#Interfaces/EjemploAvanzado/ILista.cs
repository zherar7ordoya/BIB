namespace EjemploAvanzado
{
    public interface ILista<T> : IContenedor<T>
    {
        // Método adicional específico para listas
        void Remover(T item);
    }
}