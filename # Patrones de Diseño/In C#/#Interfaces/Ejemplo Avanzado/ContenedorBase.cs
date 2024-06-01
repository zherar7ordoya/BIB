using System;
using System.Collections.Generic;

namespace EjemploAvanzado
{
    public abstract class ContenedorBase<T> : IContenedor<T>
    {
        protected List<T> elementos = new List<T>();

        public int Conteo => elementos.Count;

        public abstract void Agregar(T item);

        public event EventHandler ElementoAgregado;

        protected virtual void OnElementoAgregado()
        {
            ElementoAgregado?.Invoke(this, EventArgs.Empty);
        }

        public T this[int index]
        {
            get => elementos[index];
            set => elementos[index] = value;
        }
    }
}