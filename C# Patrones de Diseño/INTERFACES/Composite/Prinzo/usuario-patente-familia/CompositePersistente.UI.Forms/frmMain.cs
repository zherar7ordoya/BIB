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

            this.lblUsuario.Text = oBEEUsu.Nombre;


           ValidarPermisos();
        }


        void ValidarPermisos()
        {
            if (SimuladorSesion.GetInstance.IsLoggedIn())
            {
                this.mnuEjemplo.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerF);
                this.mnuA.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerA);
                this.mnuB.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerB);
                this.mnuC.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerC);
                this.mnuD.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerD);
                this.mnuE.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerE);
                this.mnuG.Enabled = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerG);

            }
            else
            {
                this.mnuEjemplo.Enabled = false;
                this.mnuA.Enabled = false;
                this.mnuB.Enabled = false;
                this.mnuC.Enabled = false;
                this.mnuD.Enabled = false;
                this.mnuE.Enabled = false;
                this.mnuG.Enabled = false;

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
