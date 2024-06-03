using QRCoder;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestorQR
{
    public partial class GestorQR : Form
    {
        private readonly string cadena;
        public GestorQR(string texto)
        {
            InitializeComponent();
            cadena = texto;
            this.Load += GestorQR_Load;
        }

        private void GestorQR_Load(object sender, EventArgs e)
        {
            BinariaTextbox.Text = cadena;
            GenerarHexadecimal();
            GenerarImagen();
        }

        private void GenerarHexadecimal()
        {
            string hexadecimal = Conversor.Convertir(cadena);
            HexadecimalTextbox.Text = hexadecimal;
        }

        private void GenerarImagen()
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(cadena, QRCodeGenerator.ECCLevel.H);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                QrPicturebox.Image = qrCodeImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
