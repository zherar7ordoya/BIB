using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Experimental
{
    internal class DAL<T> where T : class
    {
        // Método genérico para cargar los datos desde un archivo XML
        public List<T> CargarDatosDesdeXML()
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
        public void GuardarDatosEnXML(List<T> datos)
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
    }
}
