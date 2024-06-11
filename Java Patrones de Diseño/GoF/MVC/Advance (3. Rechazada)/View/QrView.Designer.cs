namespace View
{
    partial class QrView
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
            this.ListadoDgv = new System.Windows.Forms.DataGridView();
            this.QrPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConcatenadoTextbox = new System.Windows.Forms.TextBox();
            this.HexadecimalTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BinarioTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ComprobacionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ListadoDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QrPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ListadoDgv
            // 
            this.ListadoDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ListadoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListadoDgv.Location = new System.Drawing.Point(12, 12);
            this.ListadoDgv.Name = "ListadoDgv";
            this.ListadoDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListadoDgv.Size = new System.Drawing.Size(480, 348);
            this.ListadoDgv.TabIndex = 0;
            // 
            // QrPictureBox
            // 
            this.QrPictureBox.Location = new System.Drawing.Point(725, 99);
            this.QrPictureBox.Name = "QrPictureBox";
            this.QrPictureBox.Size = new System.Drawing.Size(174, 174);
            this.QrPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QrPictureBox.TabIndex = 1;
            this.QrPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(495, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Registro concatenado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConcatenadoTextbox
            // 
            this.ConcatenadoTextbox.Location = new System.Drawing.Point(498, 37);
            this.ConcatenadoTextbox.Name = "ConcatenadoTextbox";
            this.ConcatenadoTextbox.Size = new System.Drawing.Size(220, 25);
            this.ConcatenadoTextbox.TabIndex = 3;
            // 
            // HexadecimalTextBox
            // 
            this.HexadecimalTextBox.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HexadecimalTextBox.Location = new System.Drawing.Point(501, 186);
            this.HexadecimalTextBox.Name = "HexadecimalTextBox";
            this.HexadecimalTextBox.Size = new System.Drawing.Size(217, 25);
            this.HexadecimalTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(498, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Concatenado a hexadecimal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BinarioTextbox
            // 
            this.BinarioTextbox.Location = new System.Drawing.Point(501, 335);
            this.BinarioTextbox.Name = "BinarioTextbox";
            this.BinarioTextbox.Size = new System.Drawing.Size(217, 25);
            this.BinarioTextbox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(498, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hexadecimal revertido a binario";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(722, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Imagen QR";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComprobacionLabel
            // 
            this.ComprobacionLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComprobacionLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ComprobacionLabel.Location = new System.Drawing.Point(722, 71);
            this.ComprobacionLabel.Name = "ComprobacionLabel";
            this.ComprobacionLabel.Size = new System.Drawing.Size(177, 25);
            this.ComprobacionLabel.TabIndex = 11;
            this.ComprobacionLabel.Text = "Comprobación";
            this.ComprobacionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QrView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 374);
            this.Controls.Add(this.ComprobacionLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BinarioTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HexadecimalTextBox);
            this.Controls.Add(this.ConcatenadoTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QrPictureBox);
            this.Controls.Add(this.ListadoDgv);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QrView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QrView";
            ((System.ComponentModel.ISupportInitialize)(this.ListadoDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QrPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ListadoDgv;
        private System.Windows.Forms.PictureBox QrPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConcatenadoTextbox;
        private System.Windows.Forms.TextBox HexadecimalTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BinarioTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ComprobacionLabel;
    }
}