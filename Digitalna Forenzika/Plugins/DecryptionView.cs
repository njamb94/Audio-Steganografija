using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digitalna_Forenzika.Views;

namespace Digitalna_Forenzika.Plugins
{
	public partial class DecryptionView : UserControl
	{
		DecryptionViewLayer viewLayer;

		public DecryptionView()
		{
			InitializeComponent();

			viewLayer = new DecryptionViewLayer();
			viewLayer.PopulateControls(this.cbUnit, this.cbBitsToUse);
		}

		private void btnAudioFile_Click(object sender, EventArgs e)
		{
			viewLayer.LoadAudioButton(
				this.lblAudioFile,
				this.btnAudioFile,
				this.radGridView1,
				this.cbBitsToUse,
				this.cbUnit,
				this.btnExport,
				this.textBox1
			);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			viewLayer.BitsToUseChanged(
				this.cbBitsToUse,
				this.cbUnit,
				this.radGridView1,
				this.btnExport,
				this.textBox1
			);
		}

		private void btnExportLocation_Click(object sender, EventArgs e)
		{
			viewLayer.ExportPathChanged(
				this.textBox1,
				this.btnExport
			);
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			viewLayer.ExportButtonClicked(this.btnExport, this.textBox1);
		}

		private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
		{
			viewLayer.UnitChanged(this.cbBitsToUse,
				this.cbUnit,
				this.radGridView1,
				this.btnExport,
				this.textBox1);
		}
	}
}
