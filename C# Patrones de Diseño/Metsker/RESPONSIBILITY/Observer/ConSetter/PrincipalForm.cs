using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Observer1.UI
{
    public partial class PrincipalForm : Form
    {
        public void Notificar(string mensaje)
        {
            NotificacionesListbox.Items.Add(mensaje);
        }

        private readonly List<ISujetoProducto> _productos;
        private readonly List<IObserverUsuario> _usuarios;

        private ISujetoProducto _producto;
        private IObserverUsuario _usuario;

        public PrincipalForm()
        {
            InitializeComponent();

            _productos = new List<ISujetoProducto>();
            _usuarios = new List<IObserverUsuario>();
            SimularDatos();
        }

        private void SimularDatos()
        {
            _productos.Add(new Producto("producto a", 100));
            _productos.Add(new Producto("producto b", 200));
            _productos.Add(new Producto("producto c", 300));
            _productos.Add(new Producto("producto d", 400));
            _usuarios.Add(new Usuario("Diego", "Maradona"));
            _usuarios.Add(new Usuario("Leonel", "Messi"));
            _usuarios.Add(new Usuario("Paulo", "Silas"));

            MostrarProductos();
            MostrarUsuarios();
        }

        private void MostrarProductos()
        {
            ProductosListbox.DataSource = null;
            ProductosListbox.DataSource = _productos;

        }
        private void MostrarUsuarios()
        {
            UsuariosListbox.DataSource = null;
            UsuariosListbox.DataSource = _usuarios;
        }

        private void ProductosListbox_SelectedValueChanged(object sender, EventArgs e)
        {
            _producto = (ISujetoProducto)((ListBox)sender).SelectedItem;
        }

        private void ProductosListbox_DoubleClick(object sender, EventArgs e)
        {
            if (double.TryParse(Interaction.InputBox("Ingrese el nuevo precio: "),
                                out double precio))
            {
                ((Producto)_producto).Precio = precio;
                MostrarProductos();
            }
        }

        private void UsuariosListbox_SelectedValueChanged(object sender, EventArgs e)
        {
            _usuario = (IObserverUsuario)((ListBox)sender).SelectedItem;
        }

        private void SuscribirButton_Click(object sender, EventArgs e)
        {
            if (_producto != null && _usuario != null)
            {
                try
                {
                    _producto.Agregar(_usuario);
                    MessageBox.Show("Suscripción correcta");
                }
                catch (Exception ee) { MessageBox.Show(ee.Message); }
            }
            else { MessageBox.Show("Debe seleccionar producto y usuario"); }
        }

        private void DesuscribirButton_Click(object sender, EventArgs e)
        {
            if (_producto != null && _usuario != null)
            {
                try
                {
                    _producto.Quitar(_usuario);
                    MessageBox.Show("Desuscripción correcta");
                }
                catch (Exception ee) { MessageBox.Show(ee.Message); }
            }
            else { MessageBox.Show("Debe seleccionar producto y usuario"); }
        }
    }
}
