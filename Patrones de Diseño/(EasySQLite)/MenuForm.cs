using System;
using System.Collections.Generic;
using System.Data.SQLite; // <== Agregar esta referencia (no Microsoft.Data.Sqlite)
using System.Windows.Forms;

namespace EasySQLite
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ConnectToDatabase();
            List<Cliente> listado = CargarListado();
            ListadoDgv.DataSource = listado;
        }

        private List<Cliente> CargarListado() {
            List<Cliente> listado = new List<Cliente>();
            string connectionString = "Data Source=SQLiteDatabase.db";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Cliente";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Codigo = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.GetString(3),
                            Telefono = reader.GetString(4)
                        };
                        listado.Add(cliente);
                    }
                }
            }
            return listado;
        }

        private void ConnectToDatabase()
        {
            string connectionString = "Data Source=SQLiteDatabase.db";
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexión exitosa a la base de datos SQLite");

                    // Aquí puedes realizar operaciones con la base de datos
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión: {ex.Message}");
                }
            }
        }
    }
}
