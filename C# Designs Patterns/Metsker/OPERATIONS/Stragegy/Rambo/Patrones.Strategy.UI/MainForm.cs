using Patrones.Strategy.Core;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Patrones.Strategy.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Ahhh... así es como sabe cuál es el arma que debe usar...
            _armas = new List<Arma>
            {
                new Pistola(),
                new Bazooka(),
                new M16()
            };
            cboEstrategias.DataSource = _armas; // Es una lista de declaraciones

            _jugador = new Jugador
            {
                Nombre = "Rambo"
            };
            lblJugador.Text = _jugador.Nombre;
        }

        // Esta lista, originalmente, se llamaba "_estrategias".
        readonly List<Arma> _armas;
        readonly Jugador _jugador;

        private void DispararButton_Click(object sender, EventArgs e)
        {
                MessageBox.Show(_jugador.Disparar());
        }

        private void SeleccionarButton_Click(object sender, EventArgs e)
        {
            Arma arma = (Arma)cboEstrategias.SelectedItem;

            // Originalmente, este método se llamaba "CambiarEstrategia".
            _jugador.CambiarArma(arma);
        }
    }
}
