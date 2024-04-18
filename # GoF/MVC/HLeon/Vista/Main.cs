using Controlador;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MainController mainController = new MainController();
            ListadoDgv.DataSource = null;
            //ListadoDgv.DataSource = mainController.GetList();
        }
    }
}
