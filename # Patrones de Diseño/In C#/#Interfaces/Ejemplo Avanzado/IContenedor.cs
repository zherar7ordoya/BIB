using System;

namespace EjemploAvanzado
{
    public interface IContenedor<T>
    {
        // Propiedad
        int Conteo { get; }

        // Método
        void Agregar(T item);

        // Evento
        event EventHandler ElementoAgregado;

        // Indexador
        T this[int index] { get; set; }
    }
}