using Patrones.Strategy.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patrones.Strategy.UI
{
    public partial class Form1 : Form
    {

        List<Arma> _estrategiasDisparo;
        Jugador jugador;
        public Form1()
        {
            InitializeComponent();

            _estrategiasDisparo = new List<Arma>();

            _estrategiasDisparo.Add(new Pistola());
            _estrategiasDisparo.Add(new Bazooka());
            _estrategiasDisparo.Add(new Ak47());

            this.cboEstrategias.DataSource = _estrategiasDisparo;


            jugador = new Jugador();
            jugador.Nombre = "Rambo";
            this.lblJugador.Text = jugador.Nombre;

        }

        private void cmdDisparar_Click(object sender, EventArgs e)
        {
          
                MessageBox.Show(jugador.Disparar());
           
         
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            Arma arma = (Arma)this.cboEstrategias.SelectedItem;
            jugador.CambiarEstrategia(arma);
        }
    }
}
