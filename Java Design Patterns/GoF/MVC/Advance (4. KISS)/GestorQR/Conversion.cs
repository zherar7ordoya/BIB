using System;

namespace GestorQR
{
    internal static class Conversion
    {
        private static bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1') return false;
            }
            return true;
        }

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
    }
}
