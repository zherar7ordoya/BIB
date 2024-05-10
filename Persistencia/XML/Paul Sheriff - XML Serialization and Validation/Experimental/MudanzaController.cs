using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimental
{
    internal class MudanzaController
    {
        private List<Mudanza> listado;
        private DAL<Mudanza> dal = new DAL<Mudanza>();

        private Form formulario;
        private TreeView ListadoTreeview;
        private Button GuardarButton;

        public MudanzaController(Form form)
        {
            formulario = form;
            AsignarControles();
            AsignarEventos();
        }

        private void AsignarControles()
        {
            ListadoTreeview = (TreeView)formulario.Controls["ListadoTreeview"];
            GuardarButton = (Button)formulario.Controls["GuardarButton"];
        }

        private void AsignarEventos()
        {
            formulario.Load += Form_Load;
            GuardarButton.Click += GuardarDatosEnXML;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Carga los datos y muestra en el TreeView
            listado = dal.CargarDatosDesdeXML();
            TreeviewController.CargarTreeview(listado, ListadoTreeview);
        }
        
        private void GuardarDatosEnXML(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show
                (
                "¿Desea guardar los cambios?",
                "Guardar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (resultado == DialogResult.Yes)
            {
                dal.GuardarDatosEnXML(listado);
            }
        }

    }
}
