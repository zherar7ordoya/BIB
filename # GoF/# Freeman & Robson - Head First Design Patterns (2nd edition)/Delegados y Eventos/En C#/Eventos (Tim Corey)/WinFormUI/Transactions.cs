using DemoLibrary;

using System;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Transactions : Form
    {
        private Cliente _customer;
        public Transactions(Cliente customer)
        {
            InitializeComponent();
            _customer = customer;

            customerText.Text = _customer.CustomerName;
            _customer.CheckingAccount.SobregiroEvent += CheckingAccount_OverdraftEvent;
        }

        private void CheckingAccount_OverdraftEvent(object sender, SobregiroEventArgs e)
        {
            errorMessage.Visible = true;
        }

        private void makePurchaseButton_Click(object sender, EventArgs e)
        {
            bool paymentResult = _customer.CheckingAccount.Pagar("Credit Card Purchase", amountValue.Value, _customer.SavingsAccount);
            amountValue.Value = 0;
        }

        private void errorMessage_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }
    }
}
