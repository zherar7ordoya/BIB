using CompositePersistente.BE;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CompositePersistente.UI.Forms
{
    public partial class frmPatentesFamilias : Form
    {

        BLLPermisos oBLLPer;
        Familia oBEFam;

        //en el constructor del form
        public frmPatentesFamilias()
        {
            InitializeComponent();
            //intancio el objeto de la BLL Permisos
            oBLLPer= new BLLPermisos();
            //cargo los permisos "Atómicos"
            this.cboPermisos.DataSource = oBLLPer.GetAllPermission();

        }   

        //carlo las patentes (permisos estaticos) y las familias creadas
        private void LlenarPatentesFamilias()
        {
          
            this.cboPatentes.DataSource = oBLLPer.GetAllPatentes();
            this.cboFamilias.DataSource = oBLLPer.GetAllFamilias();
        }
        private void FrmSeguridad_Load(object sender, EventArgs e)
        {   //cargo todas las patentes con familias
            LlenarPatentesFamilias();
        }

     
        private void BtnGuardarPatente_Click(object sender, EventArgs e)
        {
            Patente oBEPat = new Patente()
            {
                Nombre = this.txtNombrePatente.Text,
                Permiso = (ETipoPermiso)this.cboPermisos.SelectedItem

            };

            oBLLPer.GuardarComponente(oBEPat,false);
            LlenarPatentesFamilias();

            MessageBox.Show("Patente guardada correctamente");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Familia oBEFam = new Familia()
            {
                Nombre = this.txtNombreFamilia.Text

            };




            oBLLPer.GuardarComponente(oBEFam,true);
            LlenarPatentesFamilias();
            MessageBox.Show("Familia guardada correctamente");
        }

     
        void MostrarFamilia(bool init)
        {
            if (oBEFam == null) return;

            
            IList<Componente> flia = null;
            if (init)
            {
                //traigo los hijos de la base
                flia = oBLLPer.GetAll("=" + oBEFam.Id);
             

                foreach(var i in flia)
                  oBEFam.AgregarHijo(i);
            }
            else
            {
                flia = oBEFam.Hijos;
            }

            this.treeConfigurarFamilia.Nodes.Clear();

            TreeNode root = new TreeNode(oBEFam.Nombre);
            root.Tag = oBEFam;
            this.treeConfigurarFamilia.Nodes.Add(root);

            foreach (var item in flia)
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
            if (oBEFam != null)
            {
                var patente =(Patente) cboPatentes.SelectedItem;
                if (patente != null)
                {
                    var esta = oBLLPer.Existe(oBEFam,patente.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la patente indicada");
                    else
                    {

                        {
                            oBEFam.AgregarHijo(patente);
                            MostrarFamilia(false);
                        }
                    }
                }
            }
        }

        private void CmdSeleccionar_Click(object sender, EventArgs e)
        {
            var tmp = (Familia)this.cboFamilias.SelectedItem;
            oBEFam = new Familia();
            oBEFam.Id = tmp.Id;
            oBEFam.Nombre = tmp.Nombre;
           
            MostrarFamilia(true);
        }

        private void CmdAgregarFamilia_Click(object sender, EventArgs e)
        {
            if (oBEFam != null)
            {
                var familia = (Familia)cboFamilias.SelectedItem;
                if (familia != null)
                {

                    var esta = oBLLPer.Existe(oBEFam,familia.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la familia indicada");
                    else
                    {

                        oBLLPer.FillFamilyComponents(familia);
                        oBEFam.AgregarHijo(familia);
                        MostrarFamilia(false);
                    }

                   
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                oBLLPer.GuardarFamilia(oBEFam);
                MessageBox.Show("Familia guardada correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar la familia");
            }
           
        }
    }
}
