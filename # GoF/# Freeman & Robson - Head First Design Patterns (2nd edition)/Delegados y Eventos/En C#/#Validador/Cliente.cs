using System;
using System.Xml.Serialization;

namespace Validador
{
    [Serializable]
    public class Cliente
    {
        // Eventos para feedback de validación
        public event EventHandler<string> ValidacionFallida;

        // Propiedades con validación
        private string _nombre;

        [XmlElement]
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (!Validaciones.ValidarNombre(value, OnValidacionFallida))
                    throw new ArgumentException("Nombre no es válido.");
                _nombre = value;
            }
        }

        private string _email;

        [XmlElement]
        public string Email
        {
            get => _email;
            set
            {
                if (!Validaciones.ValidarEmail(value, OnValidacionFallida))
                    throw new ArgumentException("Email no es válido.");
                _email = value;
            }
        }

        // Constructor público para serialización (verificar si esto es así)
        public Cliente() { }

        // Constructor personalizado
        public Cliente(string nombre, string email)
        {
            ValidacionFallida += Cliente_ValidacionFallida;

            Nombre = nombre;
            Email = email;
        }

        private void Cliente_ValidacionFallida(object sender, string e)
        {
            throw new ArgumentException(e);
        }

        private void OnValidacionFallida(string mensajeError)
        {
            ValidacionFallida?.Invoke(this, mensajeError);
        }
    }
}
