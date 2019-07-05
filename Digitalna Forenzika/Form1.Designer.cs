namespace Digitalna_Forenzika
{
    partial class Form1
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
			this.cryptoPanel = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.magicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.encryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.decryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cryptoPanel
			// 
			this.cryptoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cryptoPanel.Location = new System.Drawing.Point(0, 24);
			this.cryptoPanel.Name = "cryptoPanel";
			this.cryptoPanel.Size = new System.Drawing.Size(579, 462);
			this.cryptoPanel.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.CadetBlue;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.magicToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(579, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// magicToolStripMenuItem
			// 
			this.magicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encryptionToolStripMenuItem,
            this.decryptionToolStripMenuItem});
			this.magicToolStripMenuItem.Name = "magicToolStripMenuItem";
			this.magicToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.magicToolStripMenuItem.Text = "Magic";
			// 
			// encryptionToolStripMenuItem
			// 
			this.encryptionToolStripMenuItem.Name = "encryptionToolStripMenuItem";
			this.encryptionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.encryptionToolStripMenuItem.Text = "Encryption";
			this.encryptionToolStripMenuItem.Click += new System.EventHandler(this.encryptionToolStripMenuItem_Click);
			// 
			// decryptionToolStripMenuItem
			// 
			this.decryptionToolStripMenuItem.Name = "decryptionToolStripMenuItem";
			this.decryptionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.decryptionToolStripMenuItem.Text = "Decryption";
			this.decryptionToolStripMenuItem.Click += new System.EventHandler(this.decryptionToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(579, 486);
			this.Controls.Add(this.cryptoPanel);
			this.Controls.Add(this.menuStrip1);
			this.MinimumSize = new System.Drawing.Size(595, 525);
			this.Name = "Form1";
			this.Text = "LSB Coding";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Panel cryptoPanel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem magicToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem encryptionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem decryptionToolStripMenuItem;
	}
}

