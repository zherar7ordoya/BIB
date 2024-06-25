namespace Observer1.UI
{
    partial class PrincipalForm
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
            this.ProductosListbox = new System.Windows.Forms.ListBox();
            this.UsuariosListbox = new System.Windows.Forms.ListBox();
            this.SuscribirButton = new System.Windows.Forms.Button();
            this.DesuscribirButton = new System.Windows.Forms.Button();
            this.NotificacionesListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ProductosListbox
            // 
            this.ProductosListbox.FormattingEnabled = true;
            this.ProductosListbox.Location = new System.Drawing.Point(22, 21);
            this.ProductosListbox.Name = "ProductosListbox";
            this.ProductosListbox.Size = new System.Drawing.Size(172, 238);
            this.ProductosListbox.TabIndex = 0;
            this.ProductosListbox.SelectedValueChanged += new System.EventHandler(this.ProductosListbox_SelectedValueChanged);
            this.ProductosListbox.DoubleClick += new System.EventHandler(this.ProductosListbox_DoubleClick);
            // 
            // UsuariosListbox
            // 
            this.UsuariosListbox.FormattingEnabled = true;
            this.UsuariosListbox.Location = new System.Drawing.Point(232, 21);
            this.UsuariosListbox.Name = "UsuariosListbox";
            this.UsuariosListbox.Size = new System.Drawing.Size(156, 238);
            this.UsuariosListbox.TabIndex = 1;
            this.UsuariosListbox.SelectedValueChanged += new System.EventHandler(this.UsuariosListbox_SelectedValueChanged);
            // 
            // SuscribirButton
            // 
            this.SuscribirButton.Location = new System.Drawing.Point(65, 285);
            this.SuscribirButton.Name = "SuscribirButton";
            this.SuscribirButton.Size = new System.Drawing.Size(129, 45);
            this.SuscribirButton.TabIndex = 3;
            this.SuscribirButton.Text = "Suscribir";
            this.SuscribirButton.UseVisualStyleBackColor = true;
            this.SuscribirButton.Click += new System.EventHandler(this.SuscribirButton_Click);
            // 
            // DesuscribirButton
            // 
            this.DesuscribirButton.Location = new System.Drawing.Point(424, 285);
            this.DesuscribirButton.Name = "DesuscribirButton";
            this.DesuscribirButton.Size = new System.Drawing.Size(129, 45);
            this.DesuscribirButton.TabIndex = 4;
            this.DesuscribirButton.Text = "Desuscribir";
            this.DesuscribirButton.UseVisualStyleBackColor = true;
            this.DesuscribirButton.Click += new System.EventHandler(this.DesuscribirButton_Click);
            // 
            // NotificacionesListbox
            // 
            this.NotificacionesListbox.FormattingEnabled = true;
            this.NotificacionesListbox.Location = new System.Drawing.Point(424, 21);
            this.NotificacionesListbox.Name = "NotificacionesListbox";
            this.NotificacionesListbox.Size = new System.Drawing.Size(411, 238);
            this.NotificacionesListbox.TabIndex = 5;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 356);
            this.Controls.Add(this.NotificacionesListbox);
            this.Controls.Add(this.DesuscribirButton);
            this.Controls.Add(this.SuscribirButton);
            this.Controls.Add(this.UsuariosListbox);
            this.Controls.Add(this.ProductosListbox);
            this.Name = "PrincipalForm";
            this.Text = "Observer (Ejemplo 1)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ProductosListbox;
        private System.Windows.Forms.ListBox UsuariosListbox;
        private System.Windows.Forms.Button SuscribirButton;
        private System.Windows.Forms.Button DesuscribirButton;
        private System.Windows.Forms.ListBox NotificacionesListbox;
    }
}

