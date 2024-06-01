using System;
using System.Xml.Serialization;

namespace EjemploAvanzado
{
    [Obsolete("Esta clase está obsoleta, use Informal.")] // Atributo de metadatos (Metadata Attribute)
    public class Formalidad // Clase (Class)
    {
        string _mensaje; // Campo (Field)
        bool _visible;   // Campo (Field)
        static int _contador; // Campo estático (Static Field) - Variable de clase (Class Variable)

        [XmlIgnore] // Atributo de metadatos (Metadata Attribute)
        public bool Visible // Propiedad (Property)
        {
            get { return _visible; } // Accesor de lectura (Get accessor)
            set { _visible = value; } // Accesor de escritura (Set accessor)
        }

        public Formalidad(string mensaje) // Constructor (Constructor)
        {
            _mensaje = mensaje;
            _contador++; // Incrementar el campo estático
        }

        public void Saludar() // Método (Method)
        {
            Console.WriteLine("Buenos días, " + _mensaje); // Llamada a método (Method call)
        }

        public static int Contador // Propiedad estática (Static Property)
        {
            get { return _contador; } // Accesor de lectura (Get accessor)
        }
    }
}