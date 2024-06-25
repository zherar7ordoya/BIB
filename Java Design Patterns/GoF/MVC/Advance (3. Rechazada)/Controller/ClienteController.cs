using Model;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller
{
    public class ClienteController
    {
        //||||||||||||||||||||||||||||||||||||||||||| INICIALIZACIÓN DE LA VISTA

        readonly Form vista;

        // Listado de controles del form con los que voy a trabajar
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
            ListarClientes();
        }

        // Tengo que encontrar los controles en el form que me ha llegado
        private void InicializarControles()
        {
            ListadoDgv = (DataGridView)vista.Controls["ListadoDgv"];
            ClienteTextbox = (TextBox)vista.Controls["ClienteTextbox"];
            BajaButton = (Button)vista.Controls["BajaButton"];
            ConsultaButton = (Button)vista.Controls["ConsultaButton"];
        }

        // Los controles que tengan eventos los agrupo aquí
        private void InicializarEventos()
        {
            ConsultaButton.Click += ConsultarCliente;
            BajaButton.Click += EliminarCliente;
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||| EVENTOS & MÉTODOS

        private void ListarClientes()
        {
            ClienteModel clientes = new ClienteModel();
            ListadoDgv.DataSource = clientes.ReadAll(string.Empty);
        }

        private void ConsultarCliente(object sender, EventArgs e)
        {
            ClienteModel cliente = new ClienteModel();
            ListadoDgv.DataSource = null;
            List<Cliente> clientes = new List<Cliente>
            {
                cliente.ReadById(int.Parse(ClienteTextbox.Text))
            };
            ListadoDgv.DataSource = clientes;
        }

        private void EliminarCliente(object sender, EventArgs e)
        {
            ClienteModel cliente = new ClienteModel();
            cliente.Delete(int.Parse(ClienteTextbox.Text));
            ListarClientes();
        }
    }
}
