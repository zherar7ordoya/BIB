using System.Windows.Forms;
using Controlador;


namespace Vista
{
    public partial class ClienteForm : Form
    {
        public ClienteForm()
        {
            InitializeComponent();
            _ = new ClienteController(this);
        }
    }
}
