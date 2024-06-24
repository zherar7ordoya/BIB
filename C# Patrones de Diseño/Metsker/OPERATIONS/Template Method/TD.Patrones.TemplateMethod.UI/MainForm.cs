using System;
using System.Collections.Generic;
using System.Windows.Forms;

using TD.PatronesTemplateMethod.Core;

namespace TD.Patrones.TemplateMethod.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            _clientes = new List<Cliente>
            {
                new Cliente() { Nombre = "Roberto Gómez" },
                new Cliente() { Nombre = "Marta Sánchez" }
            };
            cboClientes.DataSource = _clientes;

            _creditos = new List<string>
            {
                "Personal",
                "Hipotecario"
            };
            cboCreditos.DataSource = _creditos;
        }

        readonly List<Cliente> _clientes;
        readonly List<string> _creditos;

        private void SolicitarButton_Click(object sender, EventArgs e)
        {
            var credito = cboCreditos.SelectedItem.ToString();
            var cliente = (Cliente) cboClientes.SelectedItem;

            try
            {
                if (credito == null) throw new Exception("Debe seleccionar un cliente");
                Credito caso;

                switch (credito)
                {
                    case "Hipotecario":
                        caso = new CreditoHipotecario(cliente);
                        break;
                    case "Personal":
                        caso = new CreditoPersonal(cliente);
                        break;
                    default:
                        throw new Exception("Debe seleccionar un crédito");
                }
                resultado.Clear();
                resultado.Lines = caso.Verificar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
