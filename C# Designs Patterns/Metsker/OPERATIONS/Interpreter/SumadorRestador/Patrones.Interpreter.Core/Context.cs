
namespace Interpreter
{
    public class Context
    {
        private string _proximo = "";
        private int _operador = 0;
        private int _resultado = 0;

        public int ObtenerEntero(string ingreso)
        {
            var opcion = ingreso.ToLower();

            switch (opcion)
            {
                case "cero": return 0;
                case "uno": return 1;
                case "dos": return 2;
                case "tres": return 3;
                case "cuatro": return 4;
                case "cinco": return 5;
                case "seis": return 6;
                case "siete": return 7;
                case "ocho": return 8;
                case "nueve": return 9;
                default: return -1;
            }
        }

        public void EstablecerOperador(int operador)
        {
            _operador = operador;
        }

        public void EstablecerOperacion(string operacion)
        {
            if (operacion.ToLower().Equals("mas"))
            {
                _proximo = "+";
            }
            else if (operacion.ToLower().Equals("menos"))
            {
                _proximo = "-";
            }
        }

        public void Calcular()
        {
            if (_proximo.Equals("+") || _proximo.Equals(""))
            {
                _resultado += _operador;
            }
            else if (_proximo.Equals("-"))
            {
                _resultado -= _operador;
            }
        }

        public int ObtenerResultado()
        {
            return _resultado;
        }
    }
}