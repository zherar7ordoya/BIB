using CompositePersistente.BE;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CompositePersistente.UI.Forms
{
    public partial class frmPatentesFamilias : Form
    {

        readonly BLLPermisos permisoLogic;
        Familia familia;

        // En el constructor del form
        public frmPatentesFamilias()
        {
            InitializeComponent();
            // Instancio el objeto de la BLL Permisos
            permisoLogic= new BLLPermisos();
            // Cargo los permisos atómicos
            cboPermisos.DataSource = permisoLogic.GetAllPermission();
        }   

        //carlo las patentes (permisos estaticos) y las familias creadas
        private void LlenarPatentesFamilias()
        {
          
            cboPatentes.DataSource = permisoLogic.GetAllPatentes();
            cboFamilias.DataSource = permisoLogic.GetAllFamilias();
        }
        private void FrmSeguridad_Load(object sender, EventArgs e)
        {   //cargo todas las patentes con familias
            LlenarPatentesFamilias();
        }

     
        private void BtnGuardarPatente_Click(object sender, EventArgs e)
        {
            Patente oBEPat = new Patente()
            {
                Nombre = txtNombrePatente.Text,
                Permiso = (ETipoPermiso)cboPermisos.SelectedItem

            };

            permisoLogic.GuardarComponente(oBEPat,false);
            LlenarPatentesFamilias();

            MessageBox.Show("Patente guardada correctamente");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Familia oBEFam = new Familia()
            {
                Nombre = txtNombreFamilia.Text

            };




            permisoLogic.GuardarComponente(oBEFam,true);
            LlenarPatentesFamilias();
            MessageBox.Show("Familia guardada correctamente");
        }

     
        void MostrarFamilia(bool init)
        {
            if (familia == null) return;

            
            IList<Componente> componentes = null;
            if (init)
            {
                // Traigo los hijos de la base
                componentes = permisoLogic.GetAll("=" + familia.Id);

                foreach(var componente in componentes)
                  familia.AgregarHijo(componente);
            }
            else
            {
                componentes = familia.Hijos;
            }

            treeConfigurarFamilia.Nodes.Clear();
            TreeNode root = new TreeNode(familia.Nombre)
            {
                Tag = familia
            };
            treeConfigurarFamilia.Nodes.Add(root);

            foreach (var item in componentes)
            {
                MostrarEnTreeView(root, item);
            }

            treeConfigurarFamilia.ExpandAll();
        }


        void MostrarEnTreeView(TreeNode tn, Componente c)
        {   //muetro en el treeview los componenes sean familia con sus patentes
            TreeNode n = new TreeNode(c.Nombre);
            tn.Tag = c;
            tn.Nodes.Add(n);
            if (c.Hijos!=null)
                foreach (var item in c.Hijos)
                {  //funcion recursiva
                    MostrarEnTreeView(n, item);
                }

        }

        private void CmdAgregarPatente_Click(object sender, EventArgs e)
        {
            if (familia != null)
            {
                var patente =(Patente) cboPatentes.SelectedItem;
                if (patente != null)
                {
                    var esta = permisoLogic.Existe(familia,patente.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la patente indicada");
                    else
                    {

                        {
                            familia.AgregarHijo(patente);
                            MostrarFamilia(false);
                        }
                    }
                }
            }
        }

        private void CmdSeleccionar_Click(object sender, EventArgs e)
        {
            var tmp = (Familia)cboFamilias.SelectedItem;
            familia = new Familia
            {
                Id = tmp.Id,
                Nombre = tmp.Nombre
            };

            MostrarFamilia(true);
        }

        private void CmdAgregarFamilia_Click(object sender, EventArgs e)
        {
            if (familia != null)
            {
                var familia = (Familia)cboFamilias.SelectedItem;
                if (familia != null)
                {

                    var esta = permisoLogic.Existe(this.familia, familia.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la familia indicada");
                    else
                    {

                        permisoLogic.FillFamilyComponents(familia);
                        familia.AgregarHijo(familia);
                        MostrarFamilia(false);
                    }

                   
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                permisoLogic.GuardarFamilia(familia);
                MessageBox.Show("Familia guardada correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar la familia");
            }
           
        }
    }
}
