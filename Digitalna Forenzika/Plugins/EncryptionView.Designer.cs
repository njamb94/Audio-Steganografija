namespace Digitalna_Forenzika.Plugins
{
	partial class EncryptionView
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
			this.gbEncryption = new System.Windows.Forms.GroupBox();
			this.LoadAudioBtn = new System.Windows.Forms.Button();
			this.cbBitsToUse = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
			this.cbByteUnit = new System.Windows.Forms.ComboBox();
			this.FileNameLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.EmbedBtn = new System.Windows.Forms.Button();
			this.LoadFileBtn = new System.Windows.Forms.Button();
			this.FreeSpaceLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.gbEncryption.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
			this.SuspendLayout();
			// 
			// gbEncryption
			// 
			this.gbEncryption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbEncryption.Controls.Add(this.cbBitsToUse);
			this.gbEncryption.Controls.Add(this.LoadAudioBtn);
			this.gbEncryption.Controls.Add(this.LoadFileBtn);
			this.gbEncryption.Controls.Add(this.cbByteUnit);
			this.gbEncryption.Location = new System.Drawing.Point(3, 3);
			this.gbEncryption.Name = "gbEncryption";
			this.gbEncryption.Size = new System.Drawing.Size(571, 455);
			this.gbEncryption.TabIndex = 0;
			this.gbEncryption.TabStop = false;
			this.gbEncryption.Text = "Encryption";
			// 
			// LoadAudioBtn
			// 
			this.LoadAudioBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadAudioBtn.Location = new System.Drawing.Point(488, 18);
			this.LoadAudioBtn.Name = "LoadAudioBtn";
			this.LoadAudioBtn.Size = new System.Drawing.Size(75, 23);
			this.LoadAudioBtn.TabIndex = 28;
			this.LoadAudioBtn.Text = "Open";
			this.LoadAudioBtn.UseVisualStyleBackColor = true;
			this.LoadAudioBtn.Click += new System.EventHandler(this.LoadAudioBtn_Click);
			// 
			// cbBitsToUse
			// 
			this.cbBitsToUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbBitsToUse.FormattingEnabled = true;
			this.cbBitsToUse.Location = new System.Drawing.Point(489, 93);
			this.cbBitsToUse.Margin = new System.Windows.Forms.Padding(2);
			this.cbBitsToUse.Name = "cbBitsToUse";
			this.cbBitsToUse.Size = new System.Drawing.Size(76, 21);
			this.cbBitsToUse.TabIndex = 36;
			this.cbBitsToUse.SelectedIndexChanged += new System.EventHandler(this.cbBitsToUse_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 97);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(249, 13);
			this.label4.TabIndex = 35;
			this.label4.Text = "Select the number of bits to be used in LSB coding:";
			// 
			// radGridView1
			// 
			this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.radGridView1.Location = new System.Drawing.Point(11, 127);
			this.radGridView1.Margin = new System.Windows.Forms.Padding(2);
			// 
			// 
			// 
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
			gridViewTextBoxColumn1.HeaderText = "File Name";
			gridViewTextBoxColumn1.MinWidth = 300;
			gridViewTextBoxColumn1.Name = "fileNameColumn";
			gridViewTextBoxColumn1.Width = 402;
			gridViewTextBoxColumn2.HeaderText = "File Size";
			gridViewTextBoxColumn2.MinWidth = 98;
			gridViewTextBoxColumn2.Name = "fileSizeColumn";
			gridViewTextBoxColumn2.Width = 131;
			this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
			this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.ReadOnly = true;
			this.radGridView1.Size = new System.Drawing.Size(555, 262);
			this.radGridView1.TabIndex = 34;
			// 
			// cbByteUnit
			// 
			this.cbByteUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbByteUnit.FormattingEnabled = true;
			this.cbByteUnit.Location = new System.Drawing.Point(489, 65);
			this.cbByteUnit.Name = "cbByteUnit";
			this.cbByteUnit.Size = new System.Drawing.Size(76, 21);
			this.cbByteUnit.TabIndex = 33;
			this.cbByteUnit.SelectedIndexChanged += new System.EventHandler(this.cbByteUnit_SelectedIndexChanged);
			// 
			// FileNameLabel
			// 
			this.FileNameLabel.AutoSize = true;
			this.FileNameLabel.Location = new System.Drawing.Point(68, 46);
			this.FileNameLabel.Name = "FileNameLabel";
			this.FileNameLabel.Size = new System.Drawing.Size(0, 13);
			this.FileNameLabel.TabIndex = 32;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 31;
			this.label3.Text = "Audio file:";
			// 
			// EmbedBtn
			// 
			this.EmbedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.EmbedBtn.Location = new System.Drawing.Point(492, 428);
			this.EmbedBtn.Name = "EmbedBtn";
			this.EmbedBtn.Size = new System.Drawing.Size(75, 23);
			this.EmbedBtn.TabIndex = 30;
			this.EmbedBtn.Text = "Embed";
			this.EmbedBtn.UseVisualStyleBackColor = true;
			this.EmbedBtn.Click += new System.EventHandler(this.EmbedBtn_Click);
			// 
			// LoadFileBtn
			// 
			this.LoadFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadFileBtn.Location = new System.Drawing.Point(489, 396);
			this.LoadFileBtn.Name = "LoadFileBtn";
			this.LoadFileBtn.Size = new System.Drawing.Size(75, 23);
			this.LoadFileBtn.TabIndex = 29;
			this.LoadFileBtn.Text = "Open";
			this.LoadFileBtn.UseVisualStyleBackColor = true;
			this.LoadFileBtn.Click += new System.EventHandler(this.LoadFileBtn_Click);
			// 
			// FreeSpaceLabel
			// 
			this.FreeSpaceLabel.AutoSize = true;
			this.FreeSpaceLabel.Location = new System.Drawing.Point(177, 72);
			this.FreeSpaceLabel.Name = "FreeSpaceLabel";
			this.FreeSpaceLabel.Size = new System.Drawing.Size(23, 13);
			this.FreeSpaceLabel.TabIndex = 27;
			this.FreeSpaceLabel.Text = "0 B";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(162, 13);
			this.label2.TabIndex = 26;
			this.label2.Text = "Remaining space for embedding:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Load host audio file:";
			// 
			// EncryptionView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.radGridView1);
			this.Controls.Add(this.FileNameLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.EmbedBtn);
			this.Controls.Add(this.FreeSpaceLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gbEncryption);
			this.Name = "EncryptionView";
			this.Size = new System.Drawing.Size(577, 461);
			this.gbEncryption.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbEncryption;
		private System.Windows.Forms.ComboBox cbBitsToUse;
		private System.Windows.Forms.Label label4;
		private Telerik.WinControls.UI.RadGridView radGridView1;
		private System.Windows.Forms.ComboBox cbByteUnit;
		private System.Windows.Forms.Label FileNameLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button EmbedBtn;
		private System.Windows.Forms.Button LoadFileBtn;
		private System.Windows.Forms.Button LoadAudioBtn;
		private System.Windows.Forms.Label FreeSpaceLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
