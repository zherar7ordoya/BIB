namespace Paso5
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
            this.MenuMudadora = new System.Windows.Forms.MenuStrip();
            this.Ventas = new System.Windows.Forms.ToolStripMenuItem();
            this.Captura = new System.Windows.Forms.ToolStripMenuItem();
            this.Facturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.Logistica = new System.Windows.Forms.ToolStripMenuItem();
            this.Despacho = new System.Windows.Forms.ToolStripMenuItem();
            this.Liquidacion = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMudadora.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMudadora
            // 
            this.MenuMudadora.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuMudadora.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuMudadora.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ventas,
            this.Logistica});
            this.MenuMudadora.Location = new System.Drawing.Point(0, 0);
            this.MenuMudadora.Name = "MenuMudadora";
            this.MenuMudadora.Size = new System.Drawing.Size(800, 33);
            this.MenuMudadora.TabIndex = 1;
            this.MenuMudadora.Text = "menuStrip1";
            // 
            // Ventas
            // 
            this.Ventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Captura,
            this.Facturacion});
            this.Ventas.Name = "Ventas";
            this.Ventas.Size = new System.Drawing.Size(80, 29);
            this.Ventas.Text = "Ventas";
            // 
            // Captura
            // 
            this.Captura.Name = "Captura";
            this.Captura.Size = new System.Drawing.Size(203, 34);
            this.Captura.Text = "Captura";
            // 
            // Facturacion
            // 
            this.Facturacion.Name = "Facturacion";
            this.Facturacion.Size = new System.Drawing.Size(203, 34);
            this.Facturacion.Text = "Facturacion";
            // 
            // Logistica
            // 
            this.Logistica.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Despacho,
            this.Liquidacion});
            this.Logistica.Name = "Logistica";
            this.Logistica.Size = new System.Drawing.Size(97, 29);
            this.Logistica.Text = "Logistica";
            // 
            // Despacho
            // 
            this.Despacho.Name = "Despacho";
            this.Despacho.Size = new System.Drawing.Size(204, 34);
            this.Despacho.Text = "Despacho";
            // 
            // Liquidacion
            // 
            this.Liquidacion.Name = "Liquidacion";
            this.Liquidacion.Size = new System.Drawing.Size(204, 34);
            this.Liquidacion.Text = "Liquidacion";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuMudadora);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuMudadora;
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.MenuMudadora.ResumeLayout(false);
            this.MenuMudadora.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuMudadora;
        private System.Windows.Forms.ToolStripMenuItem Ventas;
        private System.Windows.Forms.ToolStripMenuItem Captura;
        private System.Windows.Forms.ToolStripMenuItem Facturacion;
        private System.Windows.Forms.ToolStripMenuItem Logistica;
        private System.Windows.Forms.ToolStripMenuItem Despacho;
        private System.Windows.Forms.ToolStripMenuItem Liquidacion;
    }
}