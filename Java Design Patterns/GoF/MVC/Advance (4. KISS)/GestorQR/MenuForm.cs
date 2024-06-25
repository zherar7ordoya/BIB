using System;
using System.Windows.Forms;

namespace GestorQR
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            LlamarGestorButton.Click += LlamarGestorButton_Click;
        }

        // A los fines de la simulación, se generan números binarios aleatorios.
        private void LlamarGestorButton_Click(object sender, EventArgs e)
        {
            int longitud = 30;
            string binario = GenerarNumeroBinario(longitud);
            GestorQR formulario = new GestorQR(binario);
            formulario.ShowDialog();
        }
        
        static string GenerarNumeroBinario(int longitud)
        {
            Random aleatorio = new Random();
            string binario = "";
            for (int i = 0; i < longitud; i++)
            {
                int bit = aleatorio.Next(0, 2);
                binario += bit;
            }
            return binario;
        }
    }
}
