using System;

namespace EjemploAvanzado
{
    public class Lista<T> : ContenedorBase<T>, ILista<T>, IImprimible
    {
        public override void Agregar(T item)
        {
            elementos.Add(item);
            OnElementoAgregado();
        }

        public void Remover(T item)
        {
            elementos.Remove(item);
        }

        public void Imprimir()
        {
            Console.WriteLine("Elementos en la lista:");
            foreach (var elemento in elementos)
            {
                Console.WriteLine(elemento);
            }
        }
    }
}