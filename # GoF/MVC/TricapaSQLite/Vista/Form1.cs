using System;
using System.Windows.Forms;

using Controlador;

namespace Vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.Text = "Hola Mundo";
            ControladorTabla controlador = new ControladorTabla();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = controlador.ObtenerDatosTabla();
        }
    }
}
