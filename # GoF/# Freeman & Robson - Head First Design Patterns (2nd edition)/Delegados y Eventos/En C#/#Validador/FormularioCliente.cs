using System;
using System.Windows.Forms;

namespace Validador
{
    public partial class FormularioCliente : Form
    {
        public FormularioCliente()
        {
            InitializeComponent();
            CrearClienteButton.Click += CrearClienteButton_Click;
        }

        private void CrearClienteButton_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;

            try
            {
                Cliente cliente = new Cliente(nombre, email);
                cliente.ValidacionFallida += Cliente_ValidacionFallida;

                MessageBox.Show("Cliente creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cliente_ValidacionFallida(object sender, string e)
        {
            MessageBox.Show(e, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
