using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Experimental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string XmlFileName = "Mudanzas.xml";


            MudanzaCollection entity = new MudanzaCollection();

            // Read XML from a file
            string xml = File.ReadAllText(XmlFileName);

            // Deserialize XML to an object
            entity = entity.Deserialize(xml);

            if (entity != null)
            {
                TreeViewHelper.LoadList(entity.Mudanzas, treeView1);
                //foreach (Mudanza row in entity.Mudanzas)
                //{
                //    if (row != null)
                //    {
                //        MessageBox.Show(row.ToString());
                //    }
                //}
            }



        }
    }
}
