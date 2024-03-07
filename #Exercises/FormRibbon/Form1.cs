using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormRibbon
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
            //SalirOrb.Click += ApplicationExit;
        }

        private void ApplicationExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
