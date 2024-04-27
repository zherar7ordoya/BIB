using Controller;
using System.Windows.Forms;

namespace View
{
    public partial class ClienteView : Form
    {
        public ClienteView()
        {
            InitializeComponent();
            _ = new ClienteController(this);
        }
    }
}
