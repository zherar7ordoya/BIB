using System;

namespace Model
{
    /// <summary>
    /// Métodos para la conversión entre números (en cadena de texto):
    /// * decimales
    /// * binarios
    /// * hexadecimales
    /// </summary>
    internal static class QrHelper
    {
        //*--------------------------------------------------------------------*

        private static bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1') return false;
            }
            return true;
        }

        private static bool EsHexadecimal(string hexadecimal)
        {
            foreach (char caracter in hexadecimal)
            {
                if (
                    !char.IsDigit(caracter) &&
                    !(caracter >= 'A' && caracter <= 'F') &&
                    !(caracter >= 'a' && caracter <= 'f'))
                {
                    return false;
                }
            }
            return true;
        }

        //*--------------------------------------------------------------------*

        /// <summary>
        /// Convertir un número decimal a binario.
        /// </summary>
        /// <param name="pDecimal">
        /// El número decimal que se desea convertir a binario.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con el decimal convertido a binario.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Este método no contempla la conversión de números decimales negativos.
        /// </exception>
        public static string Decimal_a_Binario(long pDecimal, int pLargo)
        {
            if (pDecimal < 0)
            {
                throw new ArgumentException("El número decimal no puede ser negativo.");
            }
            string binario = Convert.ToString(pDecimal, 2).PadLeft(pLargo, '0');
            return binario;
        }

        //*--------------------------------------------------------------------*

        /// <summary>
        /// Convertir un número decimal a hexadecimal.
        /// </summary>
        /// <param name="pDecimal">
        /// El número decimal que se desea convertir a hexadecimal.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con el decimal convertido a hexadecimal.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Este método no contempla la conversión de números decimales negativos.
        /// </exception>
        public static string Decimal_a_Hexadecimal(long pDecimal, int pLargo)
        {
            if (pDecimal < 0)
            {
                throw new ArgumentException("El número decimal no puede ser negativo.");
            }
            string hexadecimal = Convert.ToString(pDecimal, 16).ToUpper().PadLeft(pLargo, '0');
            return hexadecimal;
        }

        //*--------------------------------------------------------------------*

        /// <summary>
        /// Convertir un número binario a decimal.
        /// </summary>
        /// <param name="pBinario">
        /// El número binario que se desea convertir a decimal.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con el binario convertido a decimal.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Un número binario no válido.
        /// </exception>
        public static string Binario_a_Decimal(string pBinario, int pLargo)
        {
            if (EsBinario(pBinario))
            {
                long decimalNumber = Convert.ToInt64(pBinario, 2);
                return decimalNumber.ToString().PadLeft(pLargo, '0');
            }
            throw new ArgumentException("El número binario no es válido.");
        }

        //*--------------------------------------------------------------------*

        /// <summary>
        /// Convertir un número binario a hexadecimal.
        /// </summary>
        /// <param name="pBinario">
        /// El número binario que se desea convertir a hexadecimal.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con el binario convertido a hexadecimal.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Un número binario no válido.
        /// </exception>
        public static string Binario_a_Hexadecimal(string pBinario, int pLargo)
        {
            if (EsBinario(pBinario))
            {
                string hexadecimal = Convert.ToInt64(pBinario, 2).ToString("X");
                return hexadecimal.PadLeft(pLargo, '0');
            }
            throw new ArgumentException("El número binario no es válido.");
        }

        //*--------------------------------------------------------------------*

        /// <summary>
        /// Convertir un número hexadecimal a decimal.
        /// </summary>
        /// <param name="pHexadecimal">
        /// El número hexadecimal que se desea convertir a decimal.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con el hexadecimal convertido a decimal.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Un número hexadecimal no válido.
        /// </exception>
        public static string Hexadecimal_a_Decimal(string pHexadecimal, int pLargo)
        {
            if (EsHexadecimal(pHexadecimal))
            {
                long decimalNumber = Convert.ToInt64(pHexadecimal, 16);
                return decimalNumber.ToString().PadLeft(pLargo, '0');
            }
            throw new ArgumentException("El número hexadecimal no es válido.");
        }

        //*--------------------------------------------------------------------*

        /// <summary>
        /// Convertir un número hexadecimal a binario.
        /// </summary>
        /// <param name="pHexadecimal">
        /// El número hexadecimal que se desea convertir a binario.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con el hexadecimal convertido a binario.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Un hexadecimal no válido.
        /// </exception>
        public static string Hexadecimal_a_Binario(string pHexadecimal, int pLargo)
        {
            if (!EsHexadecimal(pHexadecimal))
            {
                throw new ArgumentException("El número hexadecimal no es válido.");
            }
            string binaryNumber = Convert.ToString(Convert.ToInt64(pHexadecimal, 16), 2);
            return binaryNumber.PadLeft(pLargo, '0');
        }

        //*--------------------------------------------------------------------*
    }
}
