using DemoLibrary;

using System;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        private readonly Cliente cliente = new Cliente();

        public Dashboard()
        {
            InitializeComponent();

            CargarDato();

            ConfigurarFormulario();
        }

        private void CargarDato()
        {
            cliente.NombreApellido = "Tim Corey";

            cliente.TarjetaCredito = new Cuenta
            {
                CuentaNombre = "Tarjeta de Crédito"
            };
            cliente.TarjetaCredito.Depositar("Crédito inicial", 155.43M);

            cliente.TarjetaDebito = new Cuenta
            {
                CuentaNombre = "Tarjeta de Débito"
            };
            cliente.TarjetaDebito.Depositar("Efectivo inicial", 98.45M);
        }

        private void ConfigurarFormulario()
        {
            ClienteLabel.Text = cliente.NombreApellido;
            CreditoListbox.DataSource = cliente.TarjetaCredito.Transacciones;
            EfectivoListbox.DataSource = cliente.TarjetaDebito.Transacciones;
            CreditoLabel.Text = string.Format("{0:C2}", cliente.TarjetaCredito.Balance);
            EfectivoLabel.Text = string.Format("{0:C2}", cliente.TarjetaDebito.Balance);

            cliente.TarjetaCredito.TransaccionAprobadaEvent += CheckingAccount_TransactionApprovedEvent;
            cliente.TarjetaDebito.TransaccionAprobadaEvent += SavingsAccount_TransactionApprovedEvent;
            cliente.TarjetaCredito.SobregiroEvent += CheckingAccount_OverdraftEvent;
        }

        private void CheckingAccount_OverdraftEvent(object sender, SobregiroEventArgs e)
        {
            AdvertenciaLabel.Text = $"You had an overdraft protection transfer of { string.Format("{0:C2}", e.MontoSobregirado) }";
            e.CancelarTransaccion = DenegarCheckbox.Checked;
            AdvertenciaLabel.Visible = true;
        }

        private void SavingsAccount_TransactionApprovedEvent(object sender, string e)
        {
            EfectivoListbox.DataSource = null;
            EfectivoListbox.DataSource = cliente.TarjetaDebito.Transacciones;
            EfectivoLabel.Text = string.Format("{0:C2}", cliente.TarjetaDebito.Balance);
        }

        private void CheckingAccount_TransactionApprovedEvent(object sender, string e)
        {
            CreditoListbox.DataSource = null;
            CreditoListbox.DataSource = cliente.TarjetaCredito.Transacciones;
            CreditoLabel.Text = string.Format("{0:C2}", cliente.TarjetaCredito.Balance);
        }

        private void recordTransactionsButton_Click(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions(cliente);
            transactions.Show();
        }

        private void errorMessage_Click(object sender, EventArgs e)
        {
            AdvertenciaLabel.Visible = false;
        }
    }
}
