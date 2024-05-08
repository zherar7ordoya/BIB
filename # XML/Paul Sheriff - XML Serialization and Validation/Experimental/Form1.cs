using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Experimental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ListadoMudanzas mudanzas = new ListadoMudanzas
            {
                Mudanzas = new List<Mudanza>
                {
                    new Mudanza
                    {
                        Codigo = 1,
                        Fecha = DateTime.Now,
                        Camion = new Camion
                        {
                            Codigo = 1,
                            Patente = "ABC123",
                            Marca = "Ford"
                        },
                        Chofer = new Chofer
                        {
                            Codigo = 1,
                            DNI = 12345678,
                            NombreApellido = "Juan Perez"
                        },
                        Estibadores = new List<Estibador>
                        {
                            new Estibador
                            {
                                Codigo = 2,
                                DNI = 23456789,
                                NombreApellido = "Pedro Gomez"
                            },
                            new Estibador
                            {
                                Codigo = 3,
                                DNI = 34567890,
                                NombreApellido = "Maria Lopez"
                            },
                            new Estibador
                            {
                                Codigo = 4,
                                DNI = 45678901,
                                NombreApellido = "Carlos Rodriguez"
                            }
                        },
                        Insumos = new List<Insumo>
                        {
                            new Insumo
                            {
                                Cantidad = 10,
                                Descripcion = "Cajas"

                            },
                            new Insumo
                            {
                                Cantidad = 5,
                                Descripcion = "Cintas"
                            },
                            new Insumo
                            {
                                Cantidad = 2,
                                Descripcion = "Carretillas"
                            }
                        },
                        OrdenID = 5
                    },
                    new Mudanza
                    {
                        Codigo = 2,
                        Fecha = new DateTime(2021, 10, 10),
                        Camion = new Camion
                        {
                            Codigo = 2,
                            Patente = "DEF456",
                            Marca = "Mercedes Benz"
                        },
                        Chofer = new Chofer
                        {
                            Codigo = 2,
                            DNI = 23456789,
                            NombreApellido = "Pedro Gomez"
                        },
                        Estibadores = new List<Estibador>
                        {
                            new Estibador
                            {
                                Codigo = 3,
                                DNI = 34567890,
                                NombreApellido = "Maria Lopez"
                            },
                            new Estibador
                            {
                                Codigo = 4,
                                DNI = 45678901,
                                NombreApellido = "Carlos Rodriguez"
                            }
                        },
                        Insumos = new List<Insumo>
                        {
                            new Insumo
                            {
                                Cantidad = 10,
                                Descripcion = "Cajas"

                            },
                            new Insumo
                            {
                                Cantidad = 5,
                                Descripcion = "Cintas"
                            },
                            new Insumo
                            {
                                Cantidad = 2,
                                Descripcion = "Carretillas"
                            }
                        },
                        OrdenID = 6
                    }
                }
            };

          

            // Serialize the Object
            string xml = mudanzas.MapearDesdeObjetoHaciaXml<ListadoMudanzas>();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Mudanza>));
            //StringWriter stringWriter = new StringWriter();
            //xmlSerializer.Serialize(stringWriter, mudanzas);
            //string xml = stringWriter.ToString();

            // Write XML to File
            File.WriteAllText("Mudanza.xml", xml, Encoding.Unicode);

            // Recover the XML
            string xmlRecovered = File.ReadAllText("Mudanza.xml");

            // Convert the XML to List of Object
            StringReader stringReader = new StringReader(xmlRecovered);
            //List<Mudanza> mudanzasRecovered = (List<Mudanza>)xmlSerializer.Deserialize(stringReader);

            // Display the XML
            //TreeViewHelper.CargarTreeview(mudanzasRecovered, treeView1);


        }
    }
}
