using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QrModel
    {
        private readonly QrCRUD qrCRUD;
        private readonly QrLogic qrLogic;

        public QrModel()
        {
            qrCRUD = new QrCRUD();
            qrLogic = new QrLogic();
        }

        public List<Qr> Leer() => qrCRUD.Leer();

        public string ConvertirBinario1(string texto) => qrLogic.ConvertirBinario1(texto);
        public string ConvertirBinario2(string texto) => qrLogic.ConvertirBinario2(texto);
        public string ConvertirBinario3(string texto) => qrLogic.ConvertirBinario3(texto);
        public string ConvertirBinario4(string texto) => qrLogic.ConvertirBinario4(texto);
        public string ConvertirHexadecimal1(string texto) => qrLogic.ConvertirHexadecimal1(texto);
        public string ConvertirHexadecimal2(string texto) => qrLogic.ConvertirHexadecimal2(texto);
        public string ConvertirHexadecimal3(string texto) => qrLogic.ConvertirHexadecimal3(texto);
        public string ConvertirHexadecimal4(string texto) => qrLogic.ConvertirHexadecimal4(texto);
    }
}
