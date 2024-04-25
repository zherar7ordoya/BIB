using ABS;

using BLL;

using Presenter;

using System;
using System.Web.UI;

namespace Web
{
    public partial class WebCalculatorView : Page, ICalculatorView
    {
        public event EventHandler CalculateClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Crear una instancia del modelo
            var model = new CalculatorModel();

            // Crear una instancia del presentador pasando esta vista y el modelo
            var _presenter = new CalculatorPresenter(this, model);

            // Suscribirse al evento Click del botón de calcular
            calculateButton.Click += CalculateButton_Click;
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            // Invocar el evento CalculateClicked de la vista
            CalculateClicked?.Invoke(sender, e);
        }

        // Implementación de la interfaz ICalculatorView
        public int FirstNumber => int.Parse(firstNumberTextBox.Text);
        public int SecondNumber => int.Parse(secondNumberTextBox.Text);
        public int Result { set => resultLabel.Text = value.ToString(); }
    }
}