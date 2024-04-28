using Model;

using QRCoder;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public class QrController
    {
        readonly Form vista;
        DataGridView ListadoDgv;
        Label ComprobacionLabel;
        PictureBox QrPictureBox;
        TextBox ConcatenadoTextbox;
        TextBox HexadecimalTextbox;
        TextBox BinarioTextbox;

        public QrController(Form formulario)
        {
            vista = formulario;
            vista.Load += VistaLoad;
        }

        private void VistaLoad(object sender, EventArgs e)
        {
            InicializarControles();
            InicializarEventos();
            ListarQr();
        }

        private void InicializarControles()
        {
            ListadoDgv = (DataGridView)vista.Controls["ListadoDgv"];
            QrPictureBox = (PictureBox)vista.Controls["QrPictureBox"];
            ComprobacionLabel = (Label)vista.Controls["ComprobacionLabel"];
            ConcatenadoTextbox = (TextBox)vista.Controls["ConcatenadoTextbox"];
            HexadecimalTextbox = (TextBox)vista.Controls["HexadecimalTextbox"];
            BinarioTextbox = (TextBox)vista.Controls["BinarioTextbox"];
        }

        private void InicializarEventos()
        {
            ListadoDgv.CellClick += SeleccionarQr;
        }

        public void ListarQr()
        {
            QrModel qrModel = new QrModel();
            ListadoDgv.DataSource = null;
            ListadoDgv.DataSource = qrModel.Leer();
        }

        private void SeleccionarQr(object sender, DataGridViewCellEventArgs e)
        {
            Qr qr = (Qr)ListadoDgv.Rows[e.RowIndex].DataBoundItem;
            Concatenar(qr);
            Convertir(qr);
            Revertir();
            Comprobar();
            Imaginar();
        }

        private void Concatenar(Qr qr)
        {
            string texto = qr.Binario1 + qr.Binario2 + qr.Binario3 + qr.Binario4;
            ConcatenadoTextbox.Text = texto;
        }

        private void Convertir(Qr qr)
        {
            QrModel qrModel = new QrModel();
            string texto = qrModel.ConvertirBinario1(qr.Binario1);
            texto += qrModel.ConvertirBinario2(qr.Binario2);
            texto += qrModel.ConvertirBinario3(qr.Binario3);
            texto += qrModel.ConvertirBinario4(qr.Binario4);
            HexadecimalTextbox.Text = texto;
        }

        private void Revertir()
        {
            QrModel qrModel = new QrModel();

            string binario = HexadecimalTextbox.Text;
            string hexadecimal1 = binario.Substring(0, 1);
            string hexadecimal2 = binario.Substring(1, 2);
            string hexadecimal3 = binario.Substring(3, 3);
            string hexadecimal4 = binario.Substring(6, 6);

            string texto = qrModel.ConvertirHexadecimal1(hexadecimal1);
            texto += qrModel.ConvertirHexadecimal2(hexadecimal2);
            texto += qrModel.ConvertirHexadecimal3(hexadecimal3);
            texto += qrModel.ConvertirHexadecimal4(hexadecimal4);

            BinarioTextbox.Text = texto;
        }

        private void Comprobar()
        {
            string concatenado1 = ConcatenadoTextbox.Text;
            string concatenado2 = BinarioTextbox.Text;
            ComprobacionLabel.Text = concatenado1 == concatenado2 ? "Correcto" : "Incorrecto";
        }

        private void Imaginar()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(HexadecimalTextbox.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            QrPictureBox.Image = qrCodeImage;
        }
    }
}
