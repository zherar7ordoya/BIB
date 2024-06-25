using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Observer1.UI
{
    public class Producto : ISujetoProducto
    {
        double _precio;
        private readonly List<IObserverUsuario> _usuarios;

        public Producto(string nombre, double precio)
        {
            _usuarios = new List<IObserverUsuario>();
            Nombre = nombre;
            _precio = precio;
        }

        public string Nombre { get; set; }

        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value;
                Notificar();
            }
        }

        public override string ToString()
        {
            return $"{Nombre} (${_precio})";
        }


        public void Agregar(IObserverUsuario usuario)
        {
            if (_usuarios.Contains(usuario))
            {
                throw new Exception($"Ya existe una suscripción para {((Usuario)usuario)}");
            }
            else
            {
                _usuarios.Add(usuario);
            }
        }

        public void Quitar(IObserverUsuario usuario)
        {
            if (_usuarios.Contains(usuario))
            {
                _usuarios.Remove(usuario);
            }
            else
            {
                throw new Exception($"Na existe una suscripción para {((Usuario)usuario)}");
            }
        }

        public void Notificar()
        {
            foreach (var usuario in _usuarios)
            {
                usuario.Actualizar(this);
            }

            PrincipalForm formulario = (PrincipalForm)Application.OpenForms[0];

            if (_usuarios.Count == 0)
            {
                formulario.Notificar($"No hay suscripciones");
            }
            formulario.Notificar($"--------------------------------------------------------------------------------------------------------------------");
        }
    }
}
