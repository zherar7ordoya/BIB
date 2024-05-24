//using System;
//using System.Xml.Serialization;

//namespace Validador
//{
//    [Serializable]
//    public class Cliente
//    {
//        // Eventos para feedback de validación
//        public event EventHandler<string> ValidacionFallida;

//        // Propiedades con validación
//        private string _nombre;

//        [XmlElement]
//        public string Nombre
//        {
//            get => _nombre;
//            set
//            {
//                if (!Validaciones.ValidarNombre(value, OnValidacionFallida))
//                    throw new ArgumentException("Nombre no es válido.");
//                _nombre = value;
//            }
//        }

//        private string _email;

//        [XmlElement]
//        public string Email
//        {
//            get => _email;
//            set
//            {
//                if (!Validaciones.ValidarEmail(value, OnValidacionFallida))
//                    throw new ArgumentException("Email no es válido.");
//                _email = value;
//            }
//        }

//        // Constructor público para serialización (verificar si esto es así)
//        public Cliente() { }

//        // Constructor personalizado
//        public Cliente(string nombre, string email)
//        {
//            ValidacionFallida += Cliente_ValidacionFallida;

//            Nombre = nombre;
//            Email = email;
//        }

//        private void Cliente_ValidacionFallida(object sender, string e)
//        {
//            throw new ArgumentException(e);
//        }

//        private void OnValidacionFallida(string mensajeError)
//        {
//            ValidacionFallida?.Invoke(this, mensajeError);
//        }
//    }
//}

using System;
using System.Xml.Serialization;

namespace Validador
{
    [Serializable]
    public class Cliente
    {
        // Evento para notificar de validaciones fallidas
        public event EventHandler<string> ValidacionFallida;

        // Propiedades con validación
        [XmlElement]
        public string Nombre { get; private set; }

        [XmlElement]
        public string Email { get; private set; }

        // Constructor público para serialización
        public Cliente() { }

        // Constructor personalizado
        public Cliente(string nombre, string email)
        {
            ValidarYAsignarNombre(nombre);
            ValidarYAsignarEmail(email);
        }

        // Método privado para validar y asignar el nombre
        private void ValidarYAsignarNombre(string nombre)
        {
            if (!Validaciones.ValidarNombre(nombre, OnValidacionFallida))
            {
                //OnValidacionFallida("Nombre no es válido.");
                throw new ArgumentException("Nombre no es válido.");
            }
            Nombre = nombre;
        }

        // Método privado para validar y asignar el email
        private void ValidarYAsignarEmail(string email)
        {
            if (!Validaciones.ValidarEmail(email, OnValidacionFallida))
            {
                //OnValidacionFallida("Email no es válido.");
                throw new ArgumentException("Email no es válido.");
            }
            Email = email;
        }

        // Método para invocar el evento de validación fallida
        private void OnValidacionFallida(string mensajeError)
        {
            ValidacionFallida?.Invoke(this, mensajeError);
        }
    }
}
