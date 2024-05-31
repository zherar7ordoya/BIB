namespace WinFormUI
{
    partial class Dashboard
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.ClienteLabel = new System.Windows.Forms.Label();
            this.CreditoLabel = new System.Windows.Forms.Label();
            this.checkingBalanceLabel = new System.Windows.Forms.Label();
            this.EfectivoLabel = new System.Windows.Forms.Label();
            this.savingsBalanceLabel = new System.Windows.Forms.Label();
            this.CreditoListbox = new System.Windows.Forms.ListBox();
            this.EfectivoListbox = new System.Windows.Forms.ListBox();
            this.checkingTransactionsLabel = new System.Windows.Forms.Label();
            this.savingsTransactionsLabel = new System.Windows.Forms.Label();
            this.OperarButton = new System.Windows.Forms.Button();
            this.AdvertenciaLabel = new System.Windows.Forms.Label();
            this.DenegarCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(52, 54);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(263, 42);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Banking Demo";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.Location = new System.Drawing.Point(75, 162);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(125, 29);
            this.customerLabel.TabIndex = 1;
            this.customerLabel.Text = "Customer";
            // 
            // ClienteLabel
            // 
            this.ClienteLabel.AutoSize = true;
            this.ClienteLabel.Location = new System.Drawing.Point(304, 162);
            this.ClienteLabel.Name = "ClienteLabel";
            this.ClienteLabel.Size = new System.Drawing.Size(95, 29);
            this.ClienteLabel.TabIndex = 2;
            this.ClienteLabel.Text = "<none>";
            // 
            // CreditoLabel
            // 
            this.CreditoLabel.AutoSize = true;
            this.CreditoLabel.Location = new System.Drawing.Point(304, 230);
            this.CreditoLabel.Name = "CreditoLabel";
            this.CreditoLabel.Size = new System.Drawing.Size(71, 29);
            this.CreditoLabel.TabIndex = 4;
            this.CreditoLabel.Text = "$0.00";
            // 
            // checkingBalanceLabel
            // 
            this.checkingBalanceLabel.AutoSize = true;
            this.checkingBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkingBalanceLabel.Location = new System.Drawing.Point(75, 230);
            this.checkingBalanceLabel.Name = "checkingBalanceLabel";
            this.checkingBalanceLabel.Size = new System.Drawing.Size(223, 29);
            this.checkingBalanceLabel.TabIndex = 3;
            this.checkingBalanceLabel.Text = "Checking Balance";
            // 
            // EfectivoLabel
            // 
            this.EfectivoLabel.AutoSize = true;
            this.EfectivoLabel.Location = new System.Drawing.Point(304, 303);
            this.EfectivoLabel.Name = "EfectivoLabel";
            this.EfectivoLabel.Size = new System.Drawing.Size(71, 29);
            this.EfectivoLabel.TabIndex = 6;
            this.EfectivoLabel.Text = "$0.00";
            // 
            // savingsBalanceLabel
            // 
            this.savingsBalanceLabel.AutoSize = true;
            this.savingsBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingsBalanceLabel.Location = new System.Drawing.Point(75, 303);
            this.savingsBalanceLabel.Name = "savingsBalanceLabel";
            this.savingsBalanceLabel.Size = new System.Drawing.Size(206, 29);
            this.savingsBalanceLabel.TabIndex = 5;
            this.savingsBalanceLabel.Text = "Savings Balance";
            // 
            // CreditoListbox
            // 
            this.CreditoListbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditoListbox.FormattingEnabled = true;
            this.CreditoListbox.ItemHeight = 20;
            this.CreditoListbox.Location = new System.Drawing.Point(454, 162);
            this.CreditoListbox.Name = "CreditoListbox";
            this.CreditoListbox.Size = new System.Drawing.Size(312, 344);
            this.CreditoListbox.TabIndex = 7;
            // 
            // EfectivoListbox
            // 
            this.EfectivoListbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EfectivoListbox.FormattingEnabled = true;
            this.EfectivoListbox.ItemHeight = 20;
            this.EfectivoListbox.Location = new System.Drawing.Point(793, 162);
            this.EfectivoListbox.Name = "EfectivoListbox";
            this.EfectivoListbox.Size = new System.Drawing.Size(312, 344);
            this.EfectivoListbox.TabIndex = 8;
            // 
            // checkingTransactionsLabel
            // 
            this.checkingTransactionsLabel.AutoSize = true;
            this.checkingTransactionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkingTransactionsLabel.Location = new System.Drawing.Point(448, 126);
            this.checkingTransactionsLabel.Name = "checkingTransactionsLabel";
            this.checkingTransactionsLabel.Size = new System.Drawing.Size(279, 29);
            this.checkingTransactionsLabel.TabIndex = 9;
            this.checkingTransactionsLabel.Text = "Checking Transactions";
            // 
            // savingsTransactionsLabel
            // 
            this.savingsTransactionsLabel.AutoSize = true;
            this.savingsTransactionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingsTransactionsLabel.Location = new System.Drawing.Point(787, 126);
            this.savingsTransactionsLabel.Name = "savingsTransactionsLabel";
            this.savingsTransactionsLabel.Size = new System.Drawing.Size(262, 29);
            this.savingsTransactionsLabel.TabIndex = 10;
            this.savingsTransactionsLabel.Text = "Savings Transactions";
            // 
            // OperarButton
            // 
            this.OperarButton.Location = new System.Drawing.Point(113, 418);
            this.OperarButton.Name = "OperarButton";
            this.OperarButton.Size = new System.Drawing.Size(198, 100);
            this.OperarButton.TabIndex = 11;
            this.OperarButton.Text = "Record Transactions";
            this.OperarButton.UseVisualStyleBackColor = true;
            this.OperarButton.Click += new System.EventHandler(this.recordTransactionsButton_Click);
            // 
            // AdvertenciaLabel
            // 
            this.AdvertenciaLabel.AutoSize = true;
            this.AdvertenciaLabel.ForeColor = System.Drawing.Color.Red;
            this.AdvertenciaLabel.Location = new System.Drawing.Point(448, 68);
            this.AdvertenciaLabel.Name = "AdvertenciaLabel";
            this.AdvertenciaLabel.Size = new System.Drawing.Size(523, 29);
            this.AdvertenciaLabel.TabIndex = 12;
            this.AdvertenciaLabel.Text = "You had an overdraft protection transfer of $0.00";
            this.AdvertenciaLabel.Visible = false;
            this.AdvertenciaLabel.Click += new System.EventHandler(this.errorMessage_Click);
            // 
            // DenegarCheckbox
            // 
            this.DenegarCheckbox.AutoSize = true;
            this.DenegarCheckbox.Location = new System.Drawing.Point(113, 362);
            this.DenegarCheckbox.Name = "DenegarCheckbox";
            this.DenegarCheckbox.Size = new System.Drawing.Size(199, 33);
            this.DenegarCheckbox.TabIndex = 13;
            this.DenegarCheckbox.Text = "Stop Overdrafts";
            this.DenegarCheckbox.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 555);
            this.Controls.Add(this.DenegarCheckbox);
            this.Controls.Add(this.AdvertenciaLabel);
            this.Controls.Add(this.OperarButton);
            this.Controls.Add(this.savingsTransactionsLabel);
            this.Controls.Add(this.checkingTransactionsLabel);
            this.Controls.Add(this.EfectivoListbox);
            this.Controls.Add(this.CreditoListbox);
            this.Controls.Add(this.EfectivoLabel);
            this.Controls.Add(this.savingsBalanceLabel);
            this.Controls.Add(this.CreditoLabel);
            this.Controls.Add(this.checkingBalanceLabel);
            this.Controls.Add(this.ClienteLabel);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banking Dashboard - A C# Events Demo by Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label ClienteLabel;
        private System.Windows.Forms.Label CreditoLabel;
        private System.Windows.Forms.Label checkingBalanceLabel;
        private System.Windows.Forms.Label EfectivoLabel;
        private System.Windows.Forms.Label savingsBalanceLabel;
        private System.Windows.Forms.ListBox CreditoListbox;
        private System.Windows.Forms.ListBox EfectivoListbox;
        private System.Windows.Forms.Label checkingTransactionsLabel;
        private System.Windows.Forms.Label savingsTransactionsLabel;
        private System.Windows.Forms.Button OperarButton;
        private System.Windows.Forms.Label AdvertenciaLabel;
        private System.Windows.Forms.CheckBox DenegarCheckbox;
    }
}

