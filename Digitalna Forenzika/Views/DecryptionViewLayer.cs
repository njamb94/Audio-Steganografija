using Digitalna_Forenzika.Interfaces;
using Digitalna_Forenzika.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Digitalna_Forenzika.Views
{
	public class DecryptionViewLayer
	{
		IViewProcessor viewProcessor;

		public DecryptionViewLayer()
		{
			viewProcessor = new DecryptionViewProcessor();
		}

		public void LoadAudioButton(Label lblAudioName, Button btnSelectAudio,
			RadGridView gridView, ComboBox cbBitsToUse, ComboBox cbUnit, Button btnExport, TextBox tbExportPath)
		{
			viewProcessor.PopulateAudioFile();
			viewProcessor.BitsToUseChanged(cbBitsToUse,
				   cbUnit, null);
			viewProcessor.UpdateAudioFileLabel(lblAudioName);
			
			viewProcessor.PopulateGrid(gridView, btnExport, cbUnit, null, tbExportPath);
		}

		public void BitsToUseChanged(ComboBox cbBitsToUse, ComboBox cbUnit,
			RadGridView gridView, Button btnExport, TextBox tbExportPath)
		{
			viewProcessor.BitsToUseChanged(cbBitsToUse, cbUnit, null);
			viewProcessor.PopulateAudioFile(false);
			viewProcessor.PopulateGrid(gridView, btnExport, cbUnit, null, tbExportPath);
		}

		public void ExportPathChanged(TextBox tbExportLocation, 
			Button btnExport)
		{
			viewProcessor.UpdatedExportPath(
				tbExportLocation, 
				btnExport
			);
		}

		public void ExportButtonClicked(Button btnExport, 
			TextBox tbExportLocation)
		{
			viewProcessor.WorkYourMagic(tbExportLocation.Text);
		}

		public void PopulateControls(ComboBox cbUnit, ComboBox cbBitsToUse)
		{
			viewProcessor.PopulateControls(cbUnit, cbBitsToUse);
		}

		public void UnitChanged(ComboBox cbBitsToUse, ComboBox cbUnit, 
			RadGridView rgv, Button btnExport, TextBox tbExportPath)
		{
			viewProcessor.PopulateGrid(rgv, btnExport, cbUnit, null, 
				tbExportPath);
		}
	}
}
