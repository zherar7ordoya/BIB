using System.Windows.Forms;
using Desktop.Controladores;

namespace Desktop.Vistas
{
    public partial class ClientesForm : Form
    {
        public ClientesForm()
        {
            InitializeComponent();
            _ = new ClientesController(this);
        }
    }
}
