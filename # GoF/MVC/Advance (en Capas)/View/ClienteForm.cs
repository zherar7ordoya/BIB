using Controller;
using System.Windows.Forms;

namespace View
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
