using System;
using System.Windows.Forms;

using TCTD2020.ArquitecturaCapasV2.BLL;
using TCTD2020.ArquitecturaCapasV2.Servicios;


namespace TCTD2020.ArquitecturaCapasV2.UI
{
    public partial class frmLogin : Form
    {

        UsuarioBLL _usuarioBLL;
        public frmLogin()
        {
            InitializeComponent();
            _usuarioBLL = new UsuarioBLL();
        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            try
            {
                var res = _usuarioBLL.Login(this.txtEmail.Text, this.txtPassword.Text);
                frmMdiPrincipal frm = (frmMdiPrincipal)this.MdiParent;
                frm.ValidarForm();
            
                this.Close();
            }
            catch (LoginException error)
            {
                switch (error.Result)
                {
                    case LoginResult.InvalidUsername:
                        MessageBox.Show("Usuario incorrecto");
                        break;
                    case LoginResult.InvalidPassword:
                        MessageBox.Show("Password Incorrecto");
                        break;
                   
                    default:
                        break;
                }

            }

             


        }
    }
}
