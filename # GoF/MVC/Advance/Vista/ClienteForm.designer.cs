namespace Vista
{
    partial class ClienteForm
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
            this.ClienteTextbox = new System.Windows.Forms.TextBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.ClientesDgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ClienteTextbox
            // 
            this.ClienteTextbox.Location = new System.Drawing.Point(12, 12);
            this.ClienteTextbox.Name = "ClienteTextbox";
            this.ClienteTextbox.Size = new System.Drawing.Size(100, 20);
            this.ClienteTextbox.TabIndex = 0;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(118, 10);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 1;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            // 
            // ClientesDgv
            // 
            this.ClientesDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientesDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientesDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientesDgv.Location = new System.Drawing.Point(12, 39);
            this.ClientesDgv.Name = "ClientesDgv";
            this.ClientesDgv.Size = new System.Drawing.Size(776, 375);
            this.ClientesDgv.TabIndex = 2;
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.ClientesDgv);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.ClienteTextbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.ClientesDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ClienteTextbox;
        public System.Windows.Forms.Button BuscarButton;
        public System.Windows.Forms.DataGridView ClientesDgv;
    }
}