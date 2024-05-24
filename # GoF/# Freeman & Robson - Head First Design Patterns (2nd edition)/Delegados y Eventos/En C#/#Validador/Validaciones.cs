using System;
using System.Text.RegularExpressions;

namespace Validador
{
    public static class Validaciones
    {
        public delegate bool ValidacionDelegate(string valor);

        public static bool Validar(string valor, string patron)
        {
            return Regex.IsMatch(valor, patron);
        }

        public static bool ValidarNombre(string nombre, Action<string> onValidacionFallida)
        {
            return ValidarConFeedback(nombre, ExpresionesRegulares.Nombre, "Nombre no es válido.", onValidacionFallida);
        }

        public static bool ValidarEmail(string email, Action<string> onValidacionFallida)
        {
            return ValidarConFeedback(email, ExpresionesRegulares.Email, "Email no es válido.", onValidacionFallida);
        }

        private static bool ValidarConFeedback(string valor, string patron, string mensajeError, Action<string> onValidacionFallida)
        {
            bool esValido = Validar(valor, patron);
            if (!esValido)
            {
                onValidacionFallida?.Invoke(mensajeError);
            }
            return esValido;
        }
    }
}
