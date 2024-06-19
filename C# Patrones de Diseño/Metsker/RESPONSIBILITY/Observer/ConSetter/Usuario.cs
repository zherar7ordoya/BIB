using System.Windows.Forms;

namespace Observer1.UI
{
    public class Usuario : IObserverUsuario
    {
        public Usuario(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }


        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }


        public void Actualizar(Producto producto)
        {
            PrincipalForm formulario = (PrincipalForm)Application.OpenForms[0];
            formulario.Notificar($"El usuario {this} recibio la notificacion del producto {producto}");
        }
    }
}
