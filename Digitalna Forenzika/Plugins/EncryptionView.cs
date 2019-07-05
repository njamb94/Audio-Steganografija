using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digitalna_Forenzika.Processor;
using Digitalna_Forenzika.Interfaces;
using Digitalna_Forenzika.Views;

namespace Digitalna_Forenzika.Plugins
{
	public partial class EncryptionView : UserControl
	{
		EncryptionViewLayer viewLayer;

		public EncryptionView()
		{
			InitializeComponent();

			viewLayer = new EncryptionViewLayer();
			viewLayer.PopulateControls(this.cbByteUnit, this.cbBitsToUse);
		}

		private void LoadAudioBtn_Click(object sender, EventArgs e)
		{
			viewLayer.BtnLoadAudioFile(
				this.FileNameLabel, 
				this.cbBitsToUse,
				this.FreeSpaceLabel, 
				this.cbByteUnit
			);
		}

		private void LoadFileBtn_Click(object sender, EventArgs e)
		{ 
			viewLayer.BtnLoadFiles(
				this.radGridView1, 
				this.cbByteUnit,
				this.cbBitsToUse,
				this.FreeSpaceLabel,
				this.EmbedBtn
			);

			viewLayer.BitsToUseChanged(
				this.cbBitsToUse,
				this.cbByteUnit,
				this.FreeSpaceLabel
			);
		}

		private void cbByteUnit_SelectedIndexChanged(object sender, EventArgs e)
		{
			viewLayer.PopulateGrid(
				this.radGridView1, 
				this.EmbedBtn,
				this.cbByteUnit,
				this.FreeSpaceLabel,
				this.cbBitsToUse
			);
		}

		private void cbBitsToUse_SelectedIndexChanged(object sender, EventArgs e)
		{
			viewLayer.BitsToUseChanged(
				this.cbBitsToUse, 
				this.cbByteUnit, 
				this.FreeSpaceLabel
			);
		}

		private void EmbedBtn_Click(object sender, EventArgs e)
		{
			viewLayer.BtnEmbedFiles();
		}
	}
}
