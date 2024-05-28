using DemoLibrary;

using System;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        private readonly Cliente customer = new Cliente();

        public Dashboard()
        {
            InitializeComponent();

            LoadTestingData();

            WireUpForm();
        }

        private void LoadTestingData()
        {
            customer.CustomerName = "Tim Corey";
            customer.CheckingAccount = new Cuenta();
            customer.SavingsAccount = new Cuenta();

            customer.CheckingAccount.CuentaNombre = "Tim's Checking Account";
            customer.SavingsAccount.CuentaNombre = "Tim's Savings Account";

            customer.CheckingAccount.Depositar("Initial Balance", 155.43M);
            customer.SavingsAccount.Depositar("Initial Balance", 98.45M);
        }

        private void WireUpForm()
        {
            customerText.Text = customer.CustomerName;
            checkingTransactions.DataSource = customer.CheckingAccount.Transacciones;
            savingsTransactions.DataSource = customer.SavingsAccount.Transacciones;
            checkingBalanceValue.Text = string.Format("{0:C2}", customer.CheckingAccount.Balance);
            savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);

            customer.CheckingAccount.TransaccionAprobadaEvent += CheckingAccount_TransactionApprovedEvent;
            customer.SavingsAccount.TransaccionAprobadaEvent += SavingsAccount_TransactionApprovedEvent;
            customer.CheckingAccount.SobregiroEvent += CheckingAccount_OverdraftEvent;
        }

        private void CheckingAccount_OverdraftEvent(object sender, SobregiroEventArgs e)
        {
            errorMessage.Text = $"You had an overdraft protection transfer of { string.Format("{0:C2}", e.AmountOverdrafted) }";
            e.CancelTransaction = denyOverdraft.Checked;
            errorMessage.Visible = true;
        }

        private void SavingsAccount_TransactionApprovedEvent(object sender, string e)
        {
            savingsTransactions.DataSource = null;
            savingsTransactions.DataSource = customer.SavingsAccount.Transacciones;
            savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);
        }

        private void CheckingAccount_TransactionApprovedEvent(object sender, string e)
        {
            checkingTransactions.DataSource = null;
            checkingTransactions.DataSource = customer.CheckingAccount.Transacciones;
            checkingBalanceValue.Text = string.Format("{0:C2}", customer.CheckingAccount.Balance);
        }

        private void recordTransactionsButton_Click(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions(customer);
            transactions.Show();
        }

        private void errorMessage_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }
    }
}
