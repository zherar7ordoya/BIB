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
            List<Cliente> listado = CargarListado();
            ListadoDgv.DataSource = listado;
        }

        private List<Cliente> CargarListado()
        {
            var listado = new List<Cliente>();
            const string connectionString = "Data Source=SQLiteDatabase.db";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM Cliente", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Codigo = reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Telefono = reader.GetString(reader.GetOrdinal("Telefono"))
                        };
                        listado.Add(cliente);
                    }
                }
            }
            return listado;
        }
    }
    // *************************************************************************
}
