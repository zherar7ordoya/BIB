using System;
using System.Windows.Forms;
using TCTD2020.ArquitecturaCapasV2.BLL;
using TCTD2020.ArquitecturaCapasV2.BE;
using TCTD2020.ArquitecturaCapasV2.Interfaces;

namespace TCTD2020.ArquitecturaCapasV2.UI
{


    public partial class GestorPermisoForm : Form
    {

        UsuarioBLL _bllusuarios;

        Usuario _usuario;
        public GestorPermisoForm()
        {
            _bllusuarios = new UsuarioBLL();
            InitializeComponent();

            var users = _bllusuarios.GetAll();
            cboUsuarios.DataSource = users;
        }

        private void CboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _usuario = (Usuario)cboUsuarios.SelectedItem;
            MostrarPermisos();
        }

        private TreeNode CrearNodo(IPermiso item)
        {
            TreeNode tn = new TreeNode(item.Nombre);
            tn.Tag = item;

            return tn;
        }


        private void MostrarPermisosRecursivo(IPermiso p, TreeNode tn)
        {
            foreach (var item in p.ObtenerHijos())
            {
                var tnn = CrearNodo(item);
                tn.Nodes.Add(tnn);


                if (item.ObtenerHijos().Count > 0)
                {
                    MostrarPermisosRecursivo(item, tnn);
                }
            }
        }
        private void MostrarPermisos()
        {
            if (_usuario != null)
            {
                treeView1.Nodes.Clear();
                TreeNode raiz = new TreeNode("Permisos");
                treeView1.Nodes.Add(raiz);

                foreach (var item in _usuario.Permisos)
                {
                    var tn = CrearNodo(item);
                    raiz.Nodes.Add(tn);

                    if (item.ObtenerHijos().Count > 0)
                    {
                        MostrarPermisosRecursivo(item, tn);
                    }
                }
            }



        }



    }
}
