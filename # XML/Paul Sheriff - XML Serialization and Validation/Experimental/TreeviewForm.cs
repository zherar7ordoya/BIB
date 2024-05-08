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
        private List<T> listado;
        private List<Mudanza> mudanzas;

        public TreeviewForm()
        {
            InitializeComponent();
            Load += TreeviewForm_Load;
            GuardarButton.Click += GuardarDatosEnXML;
        }

        private void TreeviewForm_Load(object sender, EventArgs e)
        {
            // Carga los datos y muestra en el TreeView
            listado = CargarDatosDesdeXML();
            TreeviewHelper.CargarTreeview(listado, ListadoTview);

            // Prueba de datos
            mudanzas = MockDatos();
            TreeviewHelper.CargarTreeview(mudanzas, ListadoTview);
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
            if (resultado == DialogResult.Yes)
            {
                GuardarDatosEnXML(listado);
            }
        }

        // Método genérico para cargar datos de prueba
        private List<Mudanza> MockDatos()
        {
            return new List<Mudanza>
            {
                new Mudanza
                {
                    Codigo = 1,
                    Fecha = new DateTime(1972, 8, 26),
                    Camion = new Camion
                    {
                        Marca = "Scania",
                        Patente = "ABC123"
                    },
                    Chofer = new Chofer
                    {
                        DNI = 12345678,
                        NombreApellido = "Gerardo Tordoya"
                    },
                    Estibadores = new List<Estibador>
                    {
                        new Estibador
                        {
                            DNI = 23456789,
                            NombreApellido = "Carlos González",
                        },
                        new Estibador
                        {
                            DNI = 34567890,
                            NombreApellido = "Ana López",
                        }
                    },
                    Insumos = new List<Insumo>
                    {
                        new Insumo
                        {
                            Cantidad = 10,
                            Descripcion = "Cajas de cartón"
                        },
                        new Insumo
                        {
                            Cantidad = 5,
                            Descripcion = "Cinta adhesiva"
                        }
                    },
                    OrdenID = 1
                },
                new Mudanza
                {
                    Codigo = 2,
                    Fecha = DateTime.Now,
                    Camion = new Camion
                    {
                        Marca = "Mercedes Benz",
                        Patente = "DEF456"
                    },
                    Chofer = new Chofer
                    {
                        DNI = 45678901,
                        NombreApellido = "María Rodríguez"
                    },
                    Estibadores = new List<Estibador>
                    {
                        new Estibador
                        {
                            DNI = 56789012,
                            NombreApellido = "Pedro Martínez",
                        },
                        new Estibador
                        {
                            DNI = 67890123,
                            NombreApellido = "Laura Gómez",
                        }
                    },
                    Insumos = new List<Insumo>
                    {
                        new Insumo
                        {
                            Cantidad = 15,
                            Descripcion = "Cajas de cartón"
                        },
                        new Insumo
                        {
                            Cantidad = 8,
                            Descripcion = "Cinta adhesiva"
                        }
                    },
                    OrdenID = 2
                }
            };
        }



    }
}
