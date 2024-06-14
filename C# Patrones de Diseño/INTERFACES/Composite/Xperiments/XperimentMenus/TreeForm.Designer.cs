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
            this.RolesTreeview = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.PermisoTXT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RolTXT = new System.Windows.Forms.TextBox();
            this.RolAgregarBTN = new System.Windows.Forms.Button();
            this.RolQuitarBTN = new System.Windows.Forms.Button();
            this.PermisoQuitarBTN = new System.Windows.Forms.Button();
            this.PermisoAgregarBTN = new System.Windows.Forms.Button();
            this.GrabarBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RolesTreeview
            // 
            this.RolesTreeview.Location = new System.Drawing.Point(16, 16);
            this.RolesTreeview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RolesTreeview.Name = "RolesTreeview";
            this.RolesTreeview.Size = new System.Drawing.Size(328, 382);
            this.RolesTreeview.TabIndex = 0;
            this.RolesTreeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RolesTreeview_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rol";
            // 
            // PermisoTXT
            // 
            this.PermisoTXT.Location = new System.Drawing.Point(351, 156);
            this.PermisoTXT.Name = "PermisoTXT";
            this.PermisoTXT.Size = new System.Drawing.Size(187, 31);
            this.PermisoTXT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Permiso";
            // 
            // RolTXT
            // 
            this.RolTXT.Location = new System.Drawing.Point(351, 39);
            this.RolTXT.Name = "RolTXT";
            this.RolTXT.Size = new System.Drawing.Size(187, 31);
            this.RolTXT.TabIndex = 5;
            // 
            // RolAgregarBTN
            // 
            this.RolAgregarBTN.AutoSize = true;
            this.RolAgregarBTN.Location = new System.Drawing.Point(351, 68);
            this.RolAgregarBTN.Name = "RolAgregarBTN";
            this.RolAgregarBTN.Size = new System.Drawing.Size(106, 37);
            this.RolAgregarBTN.TabIndex = 6;
            this.RolAgregarBTN.Text = "Agregar";
            this.RolAgregarBTN.UseVisualStyleBackColor = true;
            this.RolAgregarBTN.Click += new System.EventHandler(this.RolAgregarBTN_Click);
            // 
            // RolQuitarBTN
            // 
            this.RolQuitarBTN.AutoSize = true;
            this.RolQuitarBTN.Location = new System.Drawing.Point(432, 68);
            this.RolQuitarBTN.Name = "RolQuitarBTN";
            this.RolQuitarBTN.Size = new System.Drawing.Size(106, 37);
            this.RolQuitarBTN.TabIndex = 7;
            this.RolQuitarBTN.Text = "Quitar";
            this.RolQuitarBTN.UseVisualStyleBackColor = true;
            this.RolQuitarBTN.Click += new System.EventHandler(this.RolQuitarBTN_Click);
            // 
            // PermisoQuitarBTN
            // 
            this.PermisoQuitarBTN.AutoSize = true;
            this.PermisoQuitarBTN.Location = new System.Drawing.Point(432, 185);
            this.PermisoQuitarBTN.Name = "PermisoQuitarBTN";
            this.PermisoQuitarBTN.Size = new System.Drawing.Size(106, 37);
            this.PermisoQuitarBTN.TabIndex = 9;
            this.PermisoQuitarBTN.Text = "Quitar";
            this.PermisoQuitarBTN.UseVisualStyleBackColor = true;
            this.PermisoQuitarBTN.Click += new System.EventHandler(this.PermisoQuitarBTN_Click);
            // 
            // PermisoAgregarBTN
            // 
            this.PermisoAgregarBTN.AutoSize = true;
            this.PermisoAgregarBTN.Location = new System.Drawing.Point(351, 185);
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
            this.GrabarBTN.Location = new System.Drawing.Point(432, 370);
            this.GrabarBTN.Name = "GrabarBTN";
            this.GrabarBTN.Size = new System.Drawing.Size(106, 37);
            this.GrabarBTN.TabIndex = 10;
            this.GrabarBTN.Text = "Grabar";
            this.GrabarBTN.UseVisualStyleBackColor = true;
            this.GrabarBTN.Click += new System.EventHandler(this.GrabarBTN_Click);
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 410);
            this.Controls.Add(this.GrabarBTN);
            this.Controls.Add(this.PermisoQuitarBTN);
            this.Controls.Add(this.PermisoAgregarBTN);
            this.Controls.Add(this.RolQuitarBTN);
            this.Controls.Add(this.RolAgregarBTN);
            this.Controls.Add(this.RolTXT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PermisoTXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RolesTreeview);
            this.Font = new System.Drawing.Font("Cascadia Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TreeForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TreeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView RolesTreeview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PermisoTXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RolTXT;
        private System.Windows.Forms.Button RolAgregarBTN;
        private System.Windows.Forms.Button RolQuitarBTN;
        private System.Windows.Forms.Button PermisoQuitarBTN;
        private System.Windows.Forms.Button PermisoAgregarBTN;
        private System.Windows.Forms.Button GrabarBTN;
    }
}

