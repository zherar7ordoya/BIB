using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Experimental
{
    public partial class MudanzaForm<T> : Form
    {
        public MudanzaForm()
        {
            InitializeComponent();
            _ = new MudanzaController(this);
        }


        

    }
}
