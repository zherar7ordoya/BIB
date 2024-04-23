using System;
using Desktop.Vistas;
using Desktop.Modelos.DAO;

namespace Desktop.Controladores
{
    internal class ClientesController
    {
        readonly ClientesForm Vista;

        public ClientesController(ClientesForm vista)
        {
            Vista = vista;
            Vista.Load += new EventHandler(ConsultaCliente);
            Vista.cmdBuscar.Click += new EventHandler(ConsultaCliente);
            Vista.tboxFiltrar.TextChanged += new EventHandler(ConsultaCliente);
        }

        private void ConsultaCliente(object sender, EventArgs e)
        {
            ClienteDAO database = new ClienteDAO();
            Vista.dgvClientes.DataSource = database.RecuperarRegistros(Vista.tboxFiltrar.Text);
        }
    }
}
