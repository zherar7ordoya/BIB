using Controller;
using System;
using System.Windows.Forms;


namespace GUI
{
    public partial class Experimental : Form
    {
        readonly ClienteVista ControladorCliente;

        public Experimental()
        {
            InitializeComponent();
            ControladorCliente = new ClienteVista(this);
        }

        /**
         * Si a ClienteVista la obligo a la interfaz IEstandarCRUD, entonces
         * aquí es donde surge el problema y me obliga a referenciar a la BEL
         * (aquí, capa Estructura).
         */
        private void Alta_Click(object sender, EventArgs e)
        {
            try
            {
                ControladorCliente.Alta();
                MessageBox.Show("Cliente dado de alta");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
