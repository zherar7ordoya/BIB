using System;

namespace Model
{
    /// <summary>
    /// Métodos para convertir números decimales, binarios, octales y hexadecimales.
    /// </summary>
    internal class ConversorLogic
    {
        //*--------------------------------------------------------------------*

        private static bool EsBinario(string pBinario)
        {
            foreach (char digit in pBinario)
            {
                if (digit != '0' && digit != '1') return false;
            }
            return true;
        }

        private static bool EsHexadecimal(string pHexadecimal)
        {
            foreach (char caracter in pHexadecimal)
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
        /// Una cadena de texto con la representación binaria del número decimal.
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
        /// Convertir un número decimal a octal.
        /// </summary>
        /// <param name="pDecimal">
        /// El número decimal que se desea convertir a octal.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con la representación octal del número decimal.
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
        /// Una cadena de texto con la representación decimal del número binario.
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
        /// Convertir un número binario a octal.
        /// </summary>
        /// <param name="pBinario">
        /// El número binario que se desea convertir a octal.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con la representación octal del número binario.
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
        /// Convertir un número octal a decimal.
        /// </summary>
        /// <param name="pHexadecimal">
        /// El número octal que se desea convertir a decimal.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// Una cadena de texto con la representación decimal del número octal.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Un número octal no válido.
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
        /// Convertir un número octal a binario.
        /// </summary>
        /// <param name="pHexadecimal">
        /// El número octal que se desea convertir a binario.
        /// </param>
        /// <param name="pLargo">
        /// El número caracteres de longitud que se desea como resultado.
        /// </param>
        /// <returns>
        /// La representación binaria del número octal.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Un número octal no válido.
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
