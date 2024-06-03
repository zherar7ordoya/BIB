namespace GestorQR
{
    internal class Conversor
    {
        public static string Convertir(string cadena)
        {
            string hexadecimal;

            // Ésta es la información que necesitamos clara: posición y largo
            string nombreDelCampoEnBBDD = cadena.Substring(0, 2);
            string nombre = cadena.Substring(2, 4);
            string apellido = cadena.Substring(6, 8);
            string dni = cadena.Substring(14, 16);

            // Esta información necesitamos: largo del retorno
            hexadecimal = Conversion.Binario_a_Hexadecimal(nombreDelCampoEnBBDD, 1);
            hexadecimal += Conversion.Binario_a_Hexadecimal(nombre, 2);
            hexadecimal += Conversion.Binario_a_Hexadecimal(apellido, 3);
            hexadecimal += Conversion.Binario_a_Hexadecimal(dni, 6);

            return hexadecimal;
        }
    }
}
