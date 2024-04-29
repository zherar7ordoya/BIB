namespace GestorQR
{
    partial class MenuForm
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
            this.LlamarGestorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LlamarGestorButton
            // 
            this.LlamarGestorButton.Location = new System.Drawing.Point(67, 54);
            this.LlamarGestorButton.Name = "LlamarGestorButton";
            this.LlamarGestorButton.Size = new System.Drawing.Size(100, 100);
            this.LlamarGestorButton.TabIndex = 0;
            this.LlamarGestorButton.Text = "Llamar al Gestor QR";
            this.LlamarGestorButton.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.LlamarGestorButton);
            this.Name = "MenuForm";
            this.Text = "Menú Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LlamarGestorButton;
    }
}

