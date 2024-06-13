using CompositePersistente.BE;

using System;
using System.Windows.Forms;

namespace CompositePersistente.UI.Forms
{
    public partial class frmMain : Form
    {

        BLLUsuario oBLLUsuarios;
        BLLPermisos oBLLPermisos;
        BLLSesion oBLLSesion;

        private void usuario_Click(object sender, EventArgs e)
        {


            Usuario oBEEUsu =(Usuario)((ToolStripMenuItem)sender).Tag;

            oBLLSesion.Login(oBEEUsu);

            lblUsuario.Text = oBEEUsu.Nombre;


           ValidarPermisos();
        }


        void ValidarPermisos()
        {
            if (SimuladorSesion.GetInstance.IsLoggedIn())
            {
                mnuEjemplo.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerF);
                mnuA.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerA);
                mnuB.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerB);
                mnuC.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerC);
                mnuD.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerD);
                mnuE.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerE);
                mnuG.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerG);

            }
            else
            {
                mnuEjemplo.Enabled = false;
                mnuA.Enabled = false;
                mnuB.Enabled = false;
                mnuC.Enabled = false;
                mnuD.Enabled = false;
                mnuE.Enabled = false;
                mnuG.Enabled = false;

            }
        }


        public frmMain()
        {
            InitializeComponent();

            oBLLPermisos = new BLLPermisos();
            oBLLUsuarios = new BLLUsuario();
            oBLLSesion = new BLLSesion();
            var usuarios = oBLLUsuarios.ListarTodo();

            foreach (var item in usuarios)
            {
                ToolStripMenuItem t = new ToolStripMenuItem(item.Nombre);
                t.Tag = item;
                oBLLPermisos.FillUserComponents(item);

                t.Click += usuario_Click;
                mnuSimularSesion.DropDownItems.Add(t);
            }

            ValidarPermisos();
        }

      

        private void SeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatentesFamilias frm = new frmPatentesFamilias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FormNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerG))
            {
                frmNuevo frm = new frmNuevo();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("no tiene permisos");
            }
        
        }

        private void VentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                BllVentas oBLLV = new BllVentas();
                oBLLV.Facturar();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
