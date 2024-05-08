using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Experimental
{
    public partial class TreeviewForm<T> : Form
    {
        private List<T> data;

        public TreeviewForm()
        {
            InitializeComponent();
            Load += TreeviewForm_Load;
            GuardarButton.Click += GuardarDatosEnXML;
        }

        private void TreeviewForm_Load(object sender, EventArgs e)
        {
            // Carga los datos y muestra en el TreeView
            data = CargarDatosDesdeXML();
            TreeviewHelper.CargarTreeview(data, ListadoTview);
        }

        // Método genérico para cargar los datos desde un archivo XML
        private List<T> CargarDatosDesdeXML()
        {
            string archivo = $"{typeof(T).Name}.xml";
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(List<T>));
                using (StreamReader lector = new StreamReader(archivo, Encoding.Unicode))
                {
                    return (List<T>)serializador.Deserialize(lector);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos desde el archivo XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<T>();
            }
        }

        // Método genérico para guardar los datos en un archivo XML
        private void GuardarDatosEnXML(List<T> datos)
        {
            string archivo = $"{typeof(T).Name}.xml";
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(List<T>));
                using (StreamWriter escritor = new StreamWriter(archivo, false, Encoding.Unicode))
                {
                    serializador.Serialize(escritor, datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos en el archivo XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de botón para guardar los datos en un archivo XML
        private void GuardarDatosEnXML(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show
                (
                "¿Desea guardar los cambios?",
                "Guardar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (resultado == DialogResult.Yes) GuardarDatosEnXML(data);
        }
    }
}
