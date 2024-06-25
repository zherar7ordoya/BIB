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
            Usuario usuario = (Usuario)((ToolStripMenuItem)sender).Tag;
            oBLLSesion.Login(usuario);
            lblUsuario.Text = usuario.Nombre;
            ValidarPermisos();
        }


        void ValidarPermisos()
        {
            if (SimuladorSesion.GetInstance.IsLoggedIn())
            {
                mnuEjemplo.Visible = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerF);
                mnuA.Visible = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerA);
                mnuB.Visible = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerB);
                mnuC.Visible = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerC);
                mnuD.Visible = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerD);
                mnuE.Visible = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerE);
                mnuG.Visible = SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerG);
            }
            else
            {
                mnuEjemplo.Visible = false;
                mnuA.Visible = false;
                mnuB.Visible = false;
                mnuC.Visible = false;
                mnuD.Visible = false;
                mnuE.Visible = false;
                mnuG.Visible = false;
            }
        }


        public frmMain()
        {
            InitializeComponent();

            oBLLPermisos = new BLLPermisos();
            oBLLUsuarios = new BLLUsuario();
            oBLLSesion = new BLLSesion();

            // Videoconferencia: 17.30
            var usuarios = oBLLUsuarios.ListarTodo();

            foreach (var usuario in usuarios)
            {
                ToolStripMenuItem t = new ToolStripMenuItem(usuario.Nombre)
                {
                    Tag = usuario
                };
                oBLLPermisos.FillUserComponents(usuario);

                t.Click += usuario_Click;
                menuSimularSesion.DropDownItems.Add(t);
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
    }
}
