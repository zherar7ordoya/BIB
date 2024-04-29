namespace Model
{
    internal class QrLogic
    {
        public string ConvertirBinario1(string texto)
        {
            return QrHelper.Binario_a_Hexadecimal(texto, 1);
        }

        public string ConvertirBinario2(string texto)
        {
            return QrHelper.Binario_a_Hexadecimal(texto, 2);
        }

        public string ConvertirBinario3(string texto)
        {
            return QrHelper.Binario_a_Hexadecimal(texto, 3);
        }

        public string ConvertirBinario4(string texto)
        {
            return QrHelper.Binario_a_Hexadecimal(texto, 6);
        }

        public string ConvertirHexadecimal1(string texto)
        {
            return QrHelper.Hexadecimal_a_Binario(texto, 2);
        }

        public string ConvertirHexadecimal2(string texto)
        {
            return QrHelper.Hexadecimal_a_Binario(texto, 4);
        }

        public string ConvertirHexadecimal3(string texto)
        {
            return QrHelper.Hexadecimal_a_Binario(texto, 8);
        }

        public string ConvertirHexadecimal4(string texto)
        {
            return QrHelper.Hexadecimal_a_Binario(texto, 16);
        }
    }
}
