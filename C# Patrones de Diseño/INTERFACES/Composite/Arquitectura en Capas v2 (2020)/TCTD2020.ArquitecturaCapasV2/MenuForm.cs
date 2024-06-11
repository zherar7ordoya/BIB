using System;
using System.Windows.Forms;
using TCTD2020.ArquitecturaCapasV2.BE;
using TCTD2020.ArquitecturaCapasV2.BLL;
using TCTD2020.ArquitecturaCapasV2.Servicios;

namespace TCTD2020.ArquitecturaCapasV2.UI
{
    public partial class MenuForm : Form
    {
        readonly UsuarioBLL _bllUsuarios;

        public MenuForm()
        {
            InitializeComponent();
            ValidarForm();
            _bllUsuarios= new UsuarioBLL();
        }

        public void ValidarForm()
        {
            itemLogin.Enabled = !SingletonSesion.Instancia.IsLogged();
            itemLogout.Enabled = SingletonSesion.Instancia.IsLogged();
            mnuGestores.Enabled = SingletonSesion.Instancia.IsLogged();

            if (SingletonSesion.Instancia.IsLogged())
                toolStripSesion.Text = SingletonSesion.Instancia.Usuario.Email;
            else
                toolStripSesion.Text = "[Sesión no iniciada]";

            //valido permisos
            mnuGestorPermisos.Enabled = SingletonSesion.Instancia.IsInRole(TipoPermiso.GestorPermiso);
            mnuGestorUsuarios.Enabled = SingletonSesion.Instancia.IsInRole(TipoPermiso.GestorUsuario);
        }

        private void ItemLogin_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ItemLogout_Click(object sender, EventArgs e)
        {
           if ( MessageBox.Show("¿Está seguro?", "Confirme", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                _bllUsuarios.Logout();
                ValidarForm();
            }
        }

        private void MnuGestorPermisos_Click(object sender, EventArgs e)
        {
            GestorPermisoForm frm = new GestorPermisoForm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
