using Model;

using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller
{
    internal class ClienteEvento
    {
        public static void ListarClientes(DataGridView dgv)
        {
            // Los métodos, por lo general, responden a eventos de la vista
            int resultado = ClienteMetodo.Sumar();
            MessageBox.Show($"Hice una suma usando un método. Resultado: {resultado}");

            ClienteModel clientes = new ClienteModel();
            dgv.DataSource = clientes.ReadAll(string.Empty);
        }

        public static void ConsultarCliente(DataGridView dgv, TextBox txt)
        {
            ClienteModel cliente = new ClienteModel();
            dgv.DataSource = null;
            List<Cliente> clientes = new List<Cliente>
            {
                cliente.ReadById(int.Parse(txt.Text))
            };
            dgv.DataSource = clientes;
        }

        public static void EliminarCliente(DataGridView dgv, TextBox txt)
        {
            ClienteModel cliente = new ClienteModel();
            cliente.Delete(int.Parse(txt.Text));
            ListarClientes(dgv);
        }
    }
}
