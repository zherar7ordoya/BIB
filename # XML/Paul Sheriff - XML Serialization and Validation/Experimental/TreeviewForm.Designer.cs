namespace Experimental
{
    partial class TreeviewForm<T>
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
            this.ListadoTview = new System.Windows.Forms.TreeView();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListadoTview
            // 
            this.ListadoTview.Location = new System.Drawing.Point(12, 12);
            this.ListadoTview.Name = "ListadoTview";
            this.ListadoTview.Size = new System.Drawing.Size(560, 337);
            this.ListadoTview.TabIndex = 0;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(497, 361);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 1;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            // 
            // TreeviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 396);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.ListadoTview);
            this.Font = new System.Drawing.Font("Calibri", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TreeviewForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ListadoTview;
        private System.Windows.Forms.Button GuardarButton;
    }
}

