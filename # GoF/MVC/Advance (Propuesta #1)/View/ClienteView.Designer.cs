namespace View
{
    partial class ClienteView
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
            this.ConsultaButton = new System.Windows.Forms.Button();
            this.ClienteTextbox = new System.Windows.Forms.TextBox();
            this.AltaButton = new System.Windows.Forms.Button();
            this.BajaButton = new System.Windows.Forms.Button();
            this.ModificacionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListadoDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ListadoDgv
            // 
            this.ListadoDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListadoDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListadoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListadoDgv.Location = new System.Drawing.Point(12, 80);
            this.ListadoDgv.Name = "ListadoDgv";
            this.ListadoDgv.Size = new System.Drawing.Size(776, 347);
            this.ListadoDgv.TabIndex = 5;
            // 
            // ConsultaButton
            // 
            this.ConsultaButton.Location = new System.Drawing.Point(336, 28);
            this.ConsultaButton.Name = "ConsultaButton";
            this.ConsultaButton.Size = new System.Drawing.Size(75, 25);
            this.ConsultaButton.TabIndex = 4;
            this.ConsultaButton.Text = "Consulta";
            this.ConsultaButton.UseVisualStyleBackColor = true;
            // 
            // ClienteTextbox
            // 
            this.ClienteTextbox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClienteTextbox.Location = new System.Drawing.Point(12, 28);
            this.ClienteTextbox.Name = "ClienteTextbox";
            this.ClienteTextbox.Size = new System.Drawing.Size(75, 25);
            this.ClienteTextbox.TabIndex = 3;
            // 
            // AltaButton
            // 
            this.AltaButton.Enabled = false;
            this.AltaButton.Location = new System.Drawing.Point(93, 28);
            this.AltaButton.Name = "AltaButton";
            this.AltaButton.Size = new System.Drawing.Size(75, 25);
            this.AltaButton.TabIndex = 6;
            this.AltaButton.Text = "Alta";
            this.AltaButton.UseVisualStyleBackColor = true;
            // 
            // BajaButton
            // 
            this.BajaButton.Location = new System.Drawing.Point(174, 28);
            this.BajaButton.Name = "BajaButton";
            this.BajaButton.Size = new System.Drawing.Size(75, 25);
            this.BajaButton.TabIndex = 7;
            this.BajaButton.Text = "Baja";
            this.BajaButton.UseVisualStyleBackColor = true;
            // 
            // ModificacionButton
            // 
            this.ModificacionButton.Enabled = false;
            this.ModificacionButton.Location = new System.Drawing.Point(255, 28);
            this.ModificacionButton.Name = "ModificacionButton";
            this.ModificacionButton.Size = new System.Drawing.Size(75, 25);
            this.ModificacionButton.TabIndex = 8;
            this.ModificacionButton.Text = "Modificación";
            this.ModificacionButton.UseVisualStyleBackColor = true;
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ModificacionButton);
            this.Controls.Add(this.BajaButton);
            this.Controls.Add(this.AltaButton);
            this.Controls.Add(this.ListadoDgv);
            this.Controls.Add(this.ConsultaButton);
            this.Controls.Add(this.ClienteTextbox);
            this.Name = "ClienteForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ListadoDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView ListadoDgv;
        public System.Windows.Forms.Button ConsultaButton;
        public System.Windows.Forms.TextBox ClienteTextbox;
        private System.Windows.Forms.Button AltaButton;
        private System.Windows.Forms.Button BajaButton;
        private System.Windows.Forms.Button ModificacionButton;
    }
}

