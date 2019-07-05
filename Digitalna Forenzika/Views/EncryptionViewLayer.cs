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
	public class EncryptionViewLayer
	{
		IViewProcessor viewProcessor;

		public EncryptionViewLayer()
		{
			viewProcessor = new EncryptionViewProcessor();
		}
		
		public void BtnLoadAudioFile(Label lblAudioFile, ComboBox cbBitsToUse,
			Label lblRemainingSpace, ComboBox cbUnit)
		{
			viewProcessor.PopulateAudioFile();
			viewProcessor.UpdateAudioFileLabel(lblAudioFile);
			viewProcessor.BitsToUseChanged(cbBitsToUse, 
				cbUnit, lblRemainingSpace);
		}
		
		public void BtnLoadFiles(RadGridView rgv, ComboBox cbUnit, 
			ComboBox cbBitsToUse, Label lblRemainingSpace, Button btnEmbed)
		{
			viewProcessor.OpenFiles(rgv, cbUnit, btnEmbed, lblRemainingSpace);
			viewProcessor.BitsToUseChanged(cbBitsToUse,	cbUnit, 
				lblRemainingSpace);
		}

		public void PopulateGrid(
			RadGridView radGridView, Button btnEnable, ComboBox cbUnit, 
			Label remainingSpace, ComboBox cbBitsToUse)
		{
			viewProcessor.PopulateGrid(radGridView, btnEnable, cbUnit, 
				remainingSpace, null);
			viewProcessor.BitsToUseChanged(cbBitsToUse, cbUnit, remainingSpace);
			viewProcessor.EnableButton(btnEnable, radGridView);
		}
		
		public void BitsToUseChanged(ComboBox cbBitsToUse, ComboBox cbUnit, 
			Label lblFreeSpace)
		{
			viewProcessor.BitsToUseChanged(cbBitsToUse, cbUnit, lblFreeSpace);	
		}

		public void PopulateControls(ComboBox cbUnit, ComboBox cbBitsToUse)
		{
			viewProcessor.PopulateControls(cbUnit, cbBitsToUse);
		}

		public void BtnEmbedFiles()
		{
			viewProcessor.WorkYourMagic();
		}
	}
}
