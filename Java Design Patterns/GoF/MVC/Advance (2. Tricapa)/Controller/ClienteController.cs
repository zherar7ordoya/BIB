using System;
using System.Windows.Forms;

namespace Controller
{
    public class ClienteController
    {
        readonly Form vista;
        DataGridView ListadoDgv;
        TextBox ClienteTextbox;
        Button ConsultaButton;
        Button BajaButton;

        public ClienteController(Form formulario)
        {
            vista = formulario;
            vista.Load += VistaLoad;
        }

        private void VistaLoad(object sender, EventArgs e)
        {
            InicializarControles();
            InicializarEventos();
            ClienteEvento.ListarClientes(ListadoDgv);
        }

        private void InicializarControles()
        {
            ListadoDgv = (DataGridView)vista.Controls["ListadoDgv"];
            ClienteTextbox = (TextBox)vista.Controls["ClienteTextbox"];
            BajaButton = (Button)vista.Controls["BajaButton"];
            ConsultaButton = (Button)vista.Controls["ConsultaButton"];
        }

        private void InicializarEventos()
        {
            ConsultaButton.Click += (sender, e) => ClienteEvento.ConsultarCliente(ListadoDgv, ClienteTextbox);
            BajaButton.Click += (sender, e) => ClienteEvento.EliminarCliente(ListadoDgv, ClienteTextbox);
        }
    }
}
