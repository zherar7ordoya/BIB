namespace GestorQR
{
    partial class GestorQR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QrPicturebox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BinariaTextbox = new System.Windows.Forms.TextBox();
            this.HexadecimalTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QrPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // QrPicturebox
            // 
            this.QrPicturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QrPicturebox.Location = new System.Drawing.Point(415, 37);
            this.QrPicturebox.Name = "QrPicturebox";
            this.QrPicturebox.Size = new System.Drawing.Size(355, 355);
            this.QrPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QrPicturebox.TabIndex = 0;
            this.QrPicturebox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadena binaria recibida";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BinariaTextbox
            // 
            this.BinariaTextbox.Location = new System.Drawing.Point(12, 129);
            this.BinariaTextbox.Name = "BinariaTextbox";
            this.BinariaTextbox.Size = new System.Drawing.Size(355, 25);
            this.BinariaTextbox.TabIndex = 2;
            // 
            // HexadecimalTextbox
            // 
            this.HexadecimalTextbox.Location = new System.Drawing.Point(12, 270);
            this.HexadecimalTextbox.Name = "HexadecimalTextbox";
            this.HexadecimalTextbox.Size = new System.Drawing.Size(355, 25);
            this.HexadecimalTextbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cadena hexadecimal (conversión del binario)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(415, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Código QR generado a partir del hexadecimal";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GestorQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HexadecimalTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BinariaTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QrPicturebox);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GestorQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestorQR";
            ((System.ComponentModel.ISupportInitialize)(this.QrPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox QrPicturebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BinariaTextbox;
        private System.Windows.Forms.TextBox HexadecimalTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}