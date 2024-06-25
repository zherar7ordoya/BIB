using CompositePersistente.BE;

using System;
using System.Windows.Forms;

namespace CompositePersistente.UI.Forms
{
    public partial class frmUsuarios : Form
    {

        BLLUsuario oBLLUsu;
        BLLPermisos oBLLPermiso;
        Usuario seleccion;
        Usuario tmp;
        public frmUsuarios()
        {
            InitializeComponent();

            oBLLUsu = new BLLUsuario();
            oBLLPermiso = new BLLPermisos();
            cboUsuarios.DataSource = oBLLUsu.ListarTodo();
            cboFamilias.DataSource = oBLLPermiso.GetAllFamilias();
            cboPatentes.DataSource = oBLLPermiso.GetAllPatentes();


        }

      
        void LlenarTreeView(TreeNode padre, Componente c)
        {
            TreeNode hijo = new TreeNode(c.Nombre);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);

            foreach (var item in c.Hijos)
            {
                LlenarTreeView(hijo, item);
            }

        }

        void MostrarPermisos(Usuario u)
        {
            treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(u.Nombre);

            foreach (var item in u.Permisos)
            {
                LlenarTreeView(root, item);
            }   

            treeView1.Nodes.Add(root);
            treeView1.ExpandAll();
        }

        private void CmdConfigurar_Click(object sender, EventArgs e)
        {
            seleccion = (Usuario)cboUsuarios.SelectedItem;
        
            //hago una copia del objeto para no modificr el que esta en el combo.
            tmp = new Usuario();
            tmp.Id = seleccion.Id;
            tmp.Nombre = seleccion.Nombre;
            oBLLPermiso.FillUserComponents(tmp);

            MostrarPermisos(tmp);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (tmp != null)
            {
                var patente = (Patente)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    var esta = false;

                    foreach (var item in tmp.Permisos)
                    {
                        if (oBLLPermiso.Existe(item, patente.Id))
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta)
                        MessageBox.Show("El usuario ya tiene la patente indicada");
                    else
                    {
                        {
                            tmp.Permisos.Add(patente);
                            MostrarPermisos(tmp);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (tmp != null)
            {
                var flia = (Familia)cboFamilias.SelectedItem;
                if (flia != null)
                {
                    var esta = false;
                    //verifico que ya no tenga el permiso. TODO: Esto debe ser parte de otra capa.
                    foreach (var item in tmp.Permisos)
                    {
                        if (oBLLPermiso.Existe(item, flia.Id))
                        {
                            esta = true;
                        }
                    }

                    if (esta)
                        MessageBox.Show("El usuario ya tiene la familia indicada");
                    else
                    {
                        {
                            oBLLPermiso.FillFamilyComponents(flia);

                            tmp.Permisos.Add(flia);
                            MostrarPermisos(tmp);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void CmdGuardarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                oBLLUsu.GuardarPermisos(tmp);
                MessageBox.Show("Usuario guardado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar el usuario");
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
