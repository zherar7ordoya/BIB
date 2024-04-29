namespace GestorQR
{
    internal class Conversor
    {
        public static string Convertir(string cadena)
        {
            string hexadecimal;

            // Ésta es la información que necesitamos clara: posición y largo
            string binario1 = cadena.Substring(0, 2);
            string binario2 = cadena.Substring(2, 4);
            string binario3 = cadena.Substring(6, 8);
            string binario4 = cadena.Substring(14, 16);

            // Esta información necesitamos: largo del retorno
            hexadecimal = Conversion.Binario_a_Hexadecimal(binario1, 1);
            hexadecimal += Conversion.Binario_a_Hexadecimal(binario2, 2);
            hexadecimal += Conversion.Binario_a_Hexadecimal(binario3, 3);
            hexadecimal += Conversion.Binario_a_Hexadecimal(binario4, 6);

            return hexadecimal;
        }
    }
}
