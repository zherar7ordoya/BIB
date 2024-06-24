using System;
using System.Collections.Generic;
using System.Windows.Forms;

using TD.PatronesTemplateMethod.Core;

namespace TD.Patrones.TemplateMethod.UI
{

    public partial class Form1 : Form
    {
        List<Cliente> _clientes;
        List<String> _creditos;
        public Form1()
        {
            InitializeComponent();

            _clientes = new List<Cliente>();
            _clientes.Add(new Cliente() { Nombre = "Roberto Gómez" });
            _clientes.Add(new Cliente() { Nombre = "Marta Sánchez" });
            this.cboClientes.DataSource = _clientes;

            _creditos = new List<String>();
            _creditos.Add("Personal");
            _creditos.Add("Hipotecario");
            this.cboCreditos.DataSource = _creditos;


        }

        private void cmdSolicitar_Click(object sender, EventArgs e)
        {
          
            var credito = this.cboCreditos.SelectedItem.ToString();
            var cliente = (Cliente) this.cboClientes.SelectedItem;

            try
            {
                if (credito == null) throw new Exception("Debe seleccionar un cliente");

                Credito c;

                switch (credito)
                {
                    case "Hipotecario":
                        c = new CreditoHipotecario(cliente);
                        break;
                    case "Personal":
                        c = new CreditoPersonal(cliente);
                        break;
                    default:
                        throw new Exception("Debe seleccionar un crédito");
                }
                this.resultado.Clear();
                this.resultado.Lines = c.Verificar();

            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }

         
        }
    }
}
