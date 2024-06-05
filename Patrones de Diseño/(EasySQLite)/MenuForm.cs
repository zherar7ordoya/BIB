// Agregar esta referencia, no "Microsoft.Data.Sqlite".
using System.Data.SQLite; 
// ****************************************************

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EasySQLite
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
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

    // *************************************************************************
    }
}
