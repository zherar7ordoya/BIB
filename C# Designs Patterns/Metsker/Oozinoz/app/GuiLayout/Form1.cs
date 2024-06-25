using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GuiLayout
{
	/// <summary>
	/// This class only exists to produce a screen shot for the
	/// Observer chapter. The class shows the GUI layout of the 
	/// ShowBallistics application.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox6 = new System.Windows.Forms.GroupBox();
            groupBox7 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    groupBox3,
                                                                                    groupBox4});
            groupBox1.Location = new System.Drawing.Point(16, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(728, 256);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Upper Panel";
            // 
            // groupBox2
            // 
            groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    textBox2,
                                                                                    groupBox7});
            groupBox2.Location = new System.Drawing.Point(16, 288);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(728, 160);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Control Panel";
            // 
            // groupBox3
            // 
            groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    groupBox5});
            groupBox3.Location = new System.Drawing.Point(24, 40);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(344, 192);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Burn Rate Box";
            // 
            // groupBox4
            // 
            groupBox4.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    groupBox6});
            groupBox4.Location = new System.Drawing.Point(392, 40);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(312, 192);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Thrust Box";
            // 
            // groupBox5
            // 
            groupBox5.Location = new System.Drawing.Point(24, 48);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(296, 128);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Burn Rate Panel";
            // 
            // groupBox6
            // 
            groupBox6.Location = new System.Drawing.Point(24, 48);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(264, 128);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "Thrust Panel";
            // 
            // groupBox7
            // 
            groupBox7.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    textBox1,
                                                                                    label1});
            groupBox7.Location = new System.Drawing.Point(24, 40);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(296, 96);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            groupBox7.Text = "Left Control Panel";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(24, 48);
            label1.Name = "label1";
            label1.TabIndex = 0;
            label1.Text = "Label";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(152, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(120, 37);
            textBox1.TabIndex = 1;
            textBox1.Tag = "Text Box";
            textBox1.Text = "Text Box";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(336, 72);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(376, 37);
            textBox2.TabIndex = 1;
            textBox2.Text = "Track Bar";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleBaseSize = new System.Drawing.Size(12, 30);
            ClientSize = new System.Drawing.Size(760, 473);
            Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          groupBox2,
                                                                          groupBox1});
            Font = new System.Drawing.Font("Book Antiqua", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            Name = "Form1";
            Text = "GUI Layout";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
