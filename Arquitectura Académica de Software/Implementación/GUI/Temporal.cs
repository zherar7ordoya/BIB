using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class Temporal : Form
    {
        public Temporal()
        {
            InitializeComponent();
        }

        // --- WORKBENCH ------------------------------------------------------╗
        /**
         * La hago corta: por lo que he podido estudiar, el archivo App.config
         * (que es el que contiene la cadena de conexión) debe estar en el
         * directorio del proyecto señalado como el inicial.
         * Yo pensaba que debería pertenecer a la DAL (DataAccess aquí), pero
         * resulta que, el que deba estar en el proyecto de inicio de la 
         * solución, es una cuestión de diseño del lenguaje C#.
         */
        readonly string CadenaConexion = 
            ConfigurationManager
            .ConnectionStrings["CadenaConexion"].ConnectionString;

        private void Temporal_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM Cliente";
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                /**
                 * You can't bind a datareader directly to a DataGridView in
                 * WinForms. Instead you could load a datatable with your reader
                 * and assign it to the datasource of the DataGridView.
                 * https://stackoverflow.com/a/18151694/14009797
                 */
                DataTable tabla = new DataTable();

                tabla.Load(lector);
                dataGridView1.DataSource = tabla;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexion.Close(); }
        }
        // --- WORKBENCH ------------------------------------------------------╝
    }
}
