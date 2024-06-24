using ABS;
using BLL;
using Presenter;

using System;
using System.Windows.Forms;

namespace Desktop
{
    public partial class DesktopCalculatorView : Form, ICalculatorView
    {
        public event EventHandler CalculateClicked;

        public DesktopCalculatorView()
        {
            InitializeComponent();

            // Crear instancia del modelo
            var model = new CalculatorModel();

            // Crear instancia del presentador pasando esta vista y el modelo
            var presenter = new CalculatorPresenter(this, model);

            // Asociar el evento Click del botón con el método OnCalculateClicked
            calculateButton.Click += OnCalculateClicked;
        }

        // Implementación de la propiedad FirstNumber de la interfaz ICalculatorView
        public int FirstNumber
        {
            get { return int.Parse(firstNumberTextBox.Text); }
        }

        // Implementación de la propiedad SecondNumber de la interfaz ICalculatorView
        public int SecondNumber
        {
            get { return int.Parse(secondNumberTextBox.Text); }
        }

        // Implementación de la propiedad Result de la interfaz ICalculatorView
        public int Result
        {
            set { resultLabel.Text = value.ToString(); }
        }

        // Evento que se dispara cuando se hace clic en el botón de calcular
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            // Invocar el evento CalculateClicked de la vista
            CalculateClicked?.Invoke(sender, e);
        }
    }
}
