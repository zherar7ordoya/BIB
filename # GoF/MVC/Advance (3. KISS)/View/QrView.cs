using System.Windows.Forms;

namespace View
{
    public partial class QrView : Form
    {
        public QrView()
        {
            InitializeComponent();
            _ = new Controller.QrController(this);
        }
    }
}
