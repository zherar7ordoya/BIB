using ABS;

using BLL;

using System;

namespace Presenter
{
    public class CalculatorPresenter
    {
        private readonly ICalculatorView _view;
        private readonly CalculatorModel _model;

        public CalculatorPresenter(ICalculatorView view, CalculatorModel model)
        {
            _view = view;
            _model = model;

            // Suscripción a los eventos de la vista
            _view.CalculateClicked += OnCalculateClicked;
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            // Obtener números ingresados desde la vista
            int firstNumber = _view.FirstNumber;
            int secondNumber = _view.SecondNumber;

            // Calcular el resultado utilizando la lógica del modelo
            int result = _model.AddNumbers(firstNumber, secondNumber);

            // Actualizar la vista con el resultado
            _view.Result = result;
        }
    }
}
