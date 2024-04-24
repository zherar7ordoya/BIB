using System;
using Vista;
using Modelo;


namespace Controlador
{
    internal class ClienteController
    {
        readonly ClienteForm vista;

        public ClienteController(ClienteForm vista)
        {
            this.vista = vista;
            this.vista.Load += new EventHandler(ConsultarCliente);
            this.vista.BuscarButton.Click += new EventHandler(ConsultarCliente);
            this.vista.ClienteTextbox.TextChanged += new EventHandler(ConsultarCliente);
        }

        private void ConsultarCliente(object sender, EventArgs e)
        {
            ClienteDAO datos = new ClienteDAO();
            vista.ClientesDgv.DataSource = datos.Consultar(vista.ClienteTextbox.Text);
        }
    }
}
