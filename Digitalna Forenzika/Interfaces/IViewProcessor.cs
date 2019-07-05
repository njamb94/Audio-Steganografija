using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Digitalna_Forenzika.Interfaces
{
	public interface IViewProcessor
	{
		void UpdateBitsToUse(string numOfBits);
		void PopulateAudioFile(bool openDialog = true);
		void UpdateAudioFileLabel(Label lbl);
		void EnableButton(Button btnToEnable, RadGridView gridView);
		bool OpenFiles(RadGridView rgv, ComboBox cbUnit, Button btnEnable,
			Label remainingSpace);
		int ConvertSizeToUnit(int size, string unit);
		void PopulateControls(ComboBox cbUnit, ComboBox cbBitsToUse);
		void BitsToUseChanged(ComboBox cbBitsToUse, ComboBox cbUnit,
			Label lblFreeSpace);
		void PopulateGrid(RadGridView rgv, Button btnEnable, ComboBox cbUnit,
			Label remainingSpace, TextBox tbExportPath);
		void UpdatedExportPath(TextBox tbExportPath, Button btnExport);
		void WorkYourMagic(string path = "");
	}

	
}
