namespace Paso5
{
    partial class TreeForm
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
            this.PermisosArbol = new System.Windows.Forms.TreeView();
            this.PermisoTXT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PermisoQuitarBTN = new System.Windows.Forms.Button();
            this.PermisoAgregarBTN = new System.Windows.Forms.Button();
            this.GrabarBTN = new System.Windows.Forms.Button();
            this.EmpleadosLista = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RolTXT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PermisosArbol
            // 
            this.PermisosArbol.Location = new System.Drawing.Point(238, 12);
            this.PermisosArbol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PermisosArbol.Name = "PermisosArbol";
            this.PermisosArbol.Size = new System.Drawing.Size(219, 329);
            this.PermisosArbol.TabIndex = 0;
            this.PermisosArbol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PermisosArbol_AfterSelect);
            // 
            // PermisoTXT
            // 
            this.PermisoTXT.Location = new System.Drawing.Point(467, 145);
            this.PermisoTXT.Name = "PermisoTXT";
            this.PermisoTXT.Size = new System.Drawing.Size(146, 31);
            this.PermisoTXT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Permiso";
            // 
            // PermisoQuitarBTN
            // 
            this.PermisoQuitarBTN.AutoSize = true;
            this.PermisoQuitarBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PermisoQuitarBTN.Location = new System.Drawing.Point(547, 174);
            this.PermisoQuitarBTN.Name = "PermisoQuitarBTN";
            this.PermisoQuitarBTN.Size = new System.Drawing.Size(94, 37);
            this.PermisoQuitarBTN.TabIndex = 9;
            this.PermisoQuitarBTN.Text = "Quitar";
            this.PermisoQuitarBTN.UseVisualStyleBackColor = true;
            this.PermisoQuitarBTN.Click += new System.EventHandler(this.PermisoQuitarBTN_Click);
            // 
            // PermisoAgregarBTN
            // 
            this.PermisoAgregarBTN.AutoSize = true;
            this.PermisoAgregarBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PermisoAgregarBTN.Location = new System.Drawing.Point(467, 174);
            this.PermisoAgregarBTN.Name = "PermisoAgregarBTN";
            this.PermisoAgregarBTN.Size = new System.Drawing.Size(106, 37);
            this.PermisoAgregarBTN.TabIndex = 8;
            this.PermisoAgregarBTN.Text = "Agregar";
            this.PermisoAgregarBTN.UseVisualStyleBackColor = true;
            this.PermisoAgregarBTN.Click += new System.EventHandler(this.PermisoAgregarBTN_Click);
            // 
            // GrabarBTN
            // 
            this.GrabarBTN.AutoSize = true;
            this.GrabarBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrabarBTN.Location = new System.Drawing.Point(547, 313);
            this.GrabarBTN.Name = "GrabarBTN";
            this.GrabarBTN.Size = new System.Drawing.Size(94, 37);
            this.GrabarBTN.TabIndex = 10;
            this.GrabarBTN.Text = "Grabar";
            this.GrabarBTN.UseVisualStyleBackColor = true;
            this.GrabarBTN.Click += new System.EventHandler(this.GrabarBTN_Click);
            // 
            // EmpleadosLista
            // 
            this.EmpleadosLista.FormattingEnabled = true;
            this.EmpleadosLista.ItemHeight = 27;
            this.EmpleadosLista.Location = new System.Drawing.Point(12, 12);
            this.EmpleadosLista.Name = "EmpleadosLista";
            this.EmpleadosLista.Size = new System.Drawing.Size(219, 301);
            this.EmpleadosLista.TabIndex = 11;
            this.EmpleadosLista.SelectedIndexChanged += new System.EventHandler(this.EmpleadosLista_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rol";
            // 
            // RolTXT
            // 
            this.RolTXT.Location = new System.Drawing.Point(467, 30);
            this.RolTXT.Name = "RolTXT";
            this.RolTXT.Size = new System.Drawing.Size(146, 31);
            this.RolTXT.TabIndex = 5;
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 357);
            this.Controls.Add(this.EmpleadosLista);
            this.Controls.Add(this.GrabarBTN);
            this.Controls.Add(this.PermisoQuitarBTN);
            this.Controls.Add(this.PermisoAgregarBTN);
            this.Controls.Add(this.RolTXT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PermisoTXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PermisosArbol);
            this.Font = new System.Drawing.Font("Cascadia Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TreeForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TreeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView PermisosArbol;
        private System.Windows.Forms.TextBox PermisoTXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PermisoQuitarBTN;
        private System.Windows.Forms.Button PermisoAgregarBTN;
        private System.Windows.Forms.Button GrabarBTN;
        private System.Windows.Forms.ListBox EmpleadosLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RolTXT;
    }
}

