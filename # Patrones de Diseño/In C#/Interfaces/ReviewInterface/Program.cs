using System;
using System.Collections.Generic;

namespace ReviewInterface
{
    public class Program
    {
        public static void Main()
        {
            // Crear una instancia de Lista
            ILista<string> miLista = new Lista<string>();

            // Suscribirse al evento ElementoAgregado
            miLista.ElementoAgregado += (sender, e) =>
            {
                Console.WriteLine("Un elemento ha sido agregado a la lista.");
            };

            // Usar las propiedades, métodos e indexadores
            miLista.Agregar("Elemento 1");
            miLista.Agregar("Elemento 2");
            Console.WriteLine($"Conteo: {miLista.Conteo}");

            Console.WriteLine($"Elemento en índice 0: {miLista[0]}");

            miLista[1] = "Elemento Modificado";
            Console.WriteLine($"Elemento en índice 1 después de modificar: {miLista[1]}");

            miLista.Remover("Elemento 1");
            Console.WriteLine($"Conteo después de remover: {miLista.Conteo}");

            // Llamar al método Imprimir
            ((IImprimible)miLista).Imprimir();

            // Parar y observar
            Console.ReadKey();
        }
    }


    public interface ILista<T> : IContenedor<T>
    {
        // Método adicional específico para listas
        void Remover(T item);
    }


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


    public interface IImprimible
    {
        void Imprimir();
    }


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

        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    }
}
