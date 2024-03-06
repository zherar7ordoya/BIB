namespace GUI
{
    partial class Experimental
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteForm));
            this.Alta = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.FechaAlta = new System.Windows.Forms.TextBox();
            this.Activo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Alta
            // 
            this.Alta.Location = new System.Drawing.Point(63, 143);
            this.Alta.Name = "Alta";
            this.Alta.Size = new System.Drawing.Size(75, 23);
            this.Alta.TabIndex = 0;
            this.Alta.Text = "Alta";
            this.Alta.UseVisualStyleBackColor = true;
            this.Alta.Click += new System.EventHandler(this.Alta_Click);
            // 
            // Id
            // 
            this.Id.Enabled = false;
            this.Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Id.ForeColor = System.Drawing.Color.Red;
            this.Id.Location = new System.Drawing.Point(38, 42);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(100, 23);
            this.Id.TabIndex = 1;
            this.Id.Text = "1";
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(38, 68);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(100, 20);
            this.Nombre.TabIndex = 2;
            this.Nombre.Text = "Gerardo Tordoya";
            // 
            // FechaAlta
            // 
            this.FechaAlta.Location = new System.Drawing.Point(38, 94);
            this.FechaAlta.Name = "FechaAlta";
            this.FechaAlta.Size = new System.Drawing.Size(100, 20);
            this.FechaAlta.TabIndex = 3;
            this.FechaAlta.Text = "2023-03-06";
            // 
            // Activo
            // 
            this.Activo.AutoSize = true;
            this.Activo.Checked = true;
            this.Activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Activo.Location = new System.Drawing.Point(82, 120);
            this.Activo.Name = "Activo";
            this.Activo.Size = new System.Drawing.Size(56, 17);
            this.Activo.TabIndex = 5;
            this.Activo.Text = "Activo";
            this.Activo.UseVisualStyleBackColor = true;
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 190);
            this.Controls.Add(this.Activo);
            this.Controls.Add(this.FechaAlta);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.Alta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Alta;
        private System.Windows.Forms.TextBox Id;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.TextBox FechaAlta;
        private System.Windows.Forms.CheckBox Activo;
    }
}

