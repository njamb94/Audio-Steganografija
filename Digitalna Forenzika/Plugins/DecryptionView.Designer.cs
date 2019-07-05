namespace Digitalna_Forenzika.Plugins
{
	partial class DecryptionView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
			this.lblAudioFile = new System.Windows.Forms.Label();
			this.lblBitsToUse = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.gbDecryption = new System.Windows.Forms.GroupBox();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnExportLocation = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
			this.cbBitsToUse = new System.Windows.Forms.ComboBox();
			this.btnAudioFile = new System.Windows.Forms.Button();
			this.lblUnit = new System.Windows.Forms.Label();
			this.cbUnit = new System.Windows.Forms.ComboBox();
			this.gbDecryption.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
			this.SuspendLayout();
			// 
			// lblAudioFile
			// 
			this.lblAudioFile.AutoSize = true;
			this.lblAudioFile.Location = new System.Drawing.Point(6, 24);
			this.lblAudioFile.Name = "lblAudioFile";
			this.lblAudioFile.Size = new System.Drawing.Size(56, 13);
			this.lblAudioFile.TabIndex = 0;
			this.lblAudioFile.Text = "Audio File:";
			// 
			// lblBitsToUse
			// 
			this.lblBitsToUse.AutoSize = true;
			this.lblBitsToUse.Location = new System.Drawing.Point(5, 51);
			this.lblBitsToUse.Name = "lblBitsToUse";
			this.lblBitsToUse.Size = new System.Drawing.Size(184, 13);
			this.lblBitsToUse.TabIndex = 1;
			this.lblBitsToUse.Text = "Bits to use while decoding using LSB:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 384);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Export location:";
			// 
			// gbDecryption
			// 
			this.gbDecryption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbDecryption.Controls.Add(this.cbUnit);
			this.gbDecryption.Controls.Add(this.lblUnit);
			this.gbDecryption.Controls.Add(this.btnExport);
			this.gbDecryption.Controls.Add(this.btnExportLocation);
			this.gbDecryption.Controls.Add(this.textBox1);
			this.gbDecryption.Controls.Add(this.radGridView1);
			this.gbDecryption.Controls.Add(this.cbBitsToUse);
			this.gbDecryption.Controls.Add(this.btnAudioFile);
			this.gbDecryption.Controls.Add(this.lblAudioFile);
			this.gbDecryption.Controls.Add(this.label3);
			this.gbDecryption.Controls.Add(this.lblBitsToUse);
			this.gbDecryption.Location = new System.Drawing.Point(3, 3);
			this.gbDecryption.Name = "gbDecryption";
			this.gbDecryption.Size = new System.Drawing.Size(571, 455);
			this.gbDecryption.TabIndex = 3;
			this.gbDecryption.TabStop = false;
			this.gbDecryption.Text = "Decryption";
			// 
			// btnExport
			// 
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExport.Location = new System.Drawing.Point(490, 426);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 8;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnExportLocation
			// 
			this.btnExportLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExportLocation.Location = new System.Drawing.Point(490, 397);
			this.btnExportLocation.Name = "btnExportLocation";
			this.btnExportLocation.Size = new System.Drawing.Size(75, 23);
			this.btnExportLocation.TabIndex = 7;
			this.btnExportLocation.Text = "Select";
			this.btnExportLocation.UseVisualStyleBackColor = true;
			this.btnExportLocation.Click += new System.EventHandler(this.btnExportLocation_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(8, 400);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(476, 20);
			this.textBox1.TabIndex = 6;
			// 
			// radGridView1
			// 
			this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.radGridView1.Location = new System.Drawing.Point(9, 102);
			// 
			// 
			// 
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
			gridViewTextBoxColumn1.HeaderText = "File Name";
			gridViewTextBoxColumn1.Name = "colFileName";
			gridViewTextBoxColumn1.Width = 267;
			gridViewTextBoxColumn2.HeaderText = "File Size";
			gridViewTextBoxColumn2.Name = "colFileSize";
			gridViewTextBoxColumn2.Width = 267;
			this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
			this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.ReadOnly = true;
			this.radGridView1.Size = new System.Drawing.Size(556, 279);
			this.radGridView1.TabIndex = 5;
			// 
			// cbBitsToUse
			// 
			this.cbBitsToUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbBitsToUse.FormattingEnabled = true;
			this.cbBitsToUse.Location = new System.Drawing.Point(491, 48);
			this.cbBitsToUse.Name = "cbBitsToUse";
			this.cbBitsToUse.Size = new System.Drawing.Size(74, 21);
			this.cbBitsToUse.TabIndex = 4;
			this.cbBitsToUse.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// btnAudioFile
			// 
			this.btnAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAudioFile.Location = new System.Drawing.Point(490, 19);
			this.btnAudioFile.Name = "btnAudioFile";
			this.btnAudioFile.Size = new System.Drawing.Size(75, 23);
			this.btnAudioFile.TabIndex = 3;
			this.btnAudioFile.Text = "Select";
			this.btnAudioFile.UseVisualStyleBackColor = true;
			this.btnAudioFile.Click += new System.EventHandler(this.btnAudioFile_Click);
			// 
			// lblUnit
			// 
			this.lblUnit.AutoSize = true;
			this.lblUnit.Location = new System.Drawing.Point(6, 78);
			this.lblUnit.Name = "lblUnit";
			this.lblUnit.Size = new System.Drawing.Size(29, 13);
			this.lblUnit.TabIndex = 9;
			this.lblUnit.Text = "Unit:";
			// 
			// cbUnit
			// 
			this.cbUnit.FormattingEnabled = true;
			this.cbUnit.Location = new System.Drawing.Point(490, 75);
			this.cbUnit.Name = "cbUnit";
			this.cbUnit.Size = new System.Drawing.Size(75, 21);
			this.cbUnit.TabIndex = 10;
			this.cbUnit.SelectedIndexChanged += new System.EventHandler(this.cbUnit_SelectedIndexChanged);
			// 
			// DecryptionView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbDecryption);
			this.Name = "DecryptionView";
			this.Size = new System.Drawing.Size(577, 461);
			this.gbDecryption.ResumeLayout(false);
			this.gbDecryption.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblAudioFile;
		private System.Windows.Forms.Label lblBitsToUse;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox gbDecryption;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnExportLocation;
		private System.Windows.Forms.TextBox textBox1;
		private Telerik.WinControls.UI.RadGridView radGridView1;
		private System.Windows.Forms.ComboBox cbBitsToUse;
		private System.Windows.Forms.Button btnAudioFile;
		private System.Windows.Forms.Label lblUnit;
		private System.Windows.Forms.ComboBox cbUnit;
	}
}
