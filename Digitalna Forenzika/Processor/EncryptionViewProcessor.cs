using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Digitalna_Forenzika.Interfaces;

namespace Digitalna_Forenzika.Processor
{
	public class EncryptionViewProcessor : IViewProcessor
	{
		#region private members
		int bitsToUse;
		FilesProcessor filesProcessor;
		LSBAlgorithm algorithm;
		#endregion private members

		#region properties
		#endregion properties

		#region constructor
		public EncryptionViewProcessor()
		{
			filesProcessor = new FilesProcessor();
			algorithm = new LSBAlgorithm(Enums.ECrypto.Encryption);
			bitsToUse = 0;
		}
		#endregion constructor

		#region helper methods
		
		private int GetRemainingSpaceInBytes()
		{		
			int remainingSpace = 
				(bitsToUse * filesProcessor.AudioFile.HostFile.NumOfSamples * filesProcessor.AudioFile.HostFile.BlockAlign) 
				/  
				8 /*- filesProcessor.Files.Sum(x => x.FileBinary.Length) */- algorithm.GetMsgToEmbedSize();

			if (remainingSpace < 0)
				return 0;
			else
				return remainingSpace;
		}

		private void SelectBitsToUseInitial(ComboBox cb, string val)
		{
			cb.SelectedItem = Int32.Parse(val);
		}

		#endregion helper methods

		#region interface methods
		//
		public void WorkYourMagic(string path = "")
		{
			if (GetRemainingSpaceInBytes() == 0)
			{
				MessageBox.Show("You're trying to encrypt more content than " +
					"available space. Your host file will be corrupted. " +
					 "Try updating bits used for encryption.",
					 "Not enough space",
					 MessageBoxButtons.OK,
					 MessageBoxIcon.Warning);

			}
			else
			{
				// TODO: Embed files:
				algorithm.CreateStegoFile();
			}
		}
		//
		public bool OpenFiles(RadGridView rgv, ComboBox cbUnit, 
			Button btnEnable, Label remainingSpace)
		{ 
			List<string> paths = filesProcessor.OpenAndAddFiles();
			PopulateGrid(rgv, btnEnable, cbUnit, remainingSpace, null);

			algorithm.AddFilesToEmbed(paths);

			return true;
		}
		//
		public void PopulateAudioFile(bool openDialog = true)
		{
			filesProcessor.PopulateAudioFile(openDialog);

			algorithm.SetParameters(bitsToUse, filesProcessor.AudioFile, filesProcessor.Files);
		}
		//
		public void UpdateAudioFileLabel(Label lbl)
		{
			lbl.Text = filesProcessor.GetAudioFileName();
		}
		//
		public void PopulateControls(ComboBox cbUnit, ComboBox cbBitsToUse)
		{
			for (int i = 1; i < 9; i++)
				cbBitsToUse.Items.Add(i);

			cbUnit.Items.Add("B");
			cbUnit.Items.Add("KB");
			cbUnit.Items.Add("MB");
			
			cbUnit.SelectedItem = "B";
			cbBitsToUse.SelectedItem = 1;
		}
		//
		public void BitsToUseChanged(ComboBox cbBitsToUse, ComboBox cbUnit,
			Label lblFreeSpace)
		{
			if (cbBitsToUse.SelectedItem == null)
				SelectBitsToUseInitial(cbBitsToUse, "1");

			UpdateBitsToUse(cbBitsToUse.SelectedItem.ToString());

			int size = GetRemainingSpaceInBytes();

			lblFreeSpace.Text = ConvertSizeToUnit(
				size,
				cbUnit.SelectedItem.ToString()
			).ToString();
		}
		//
		public void PopulateGrid(RadGridView rgv, Button btnEnable, 
			ComboBox cbUnit, Label remainingSpace, TextBox tbExportPath)
		{
			rgv.Rows.Clear();

			List<Tuple<string, int>> fileNamesWithByteSize
				= filesProcessor.GetFileNamesWithByteSize();

			GridViewDataRowInfo[] rows = 
				new GridViewDataRowInfo[fileNamesWithByteSize.Count];

			for(int i = 0; i < rows.Length; i++)
			{
				Tuple<string, int> file = fileNamesWithByteSize[i];

				rows[i] = new GridViewDataRowInfo(rgv.MasterView);

				rows[i].Cells[0].Value = file.Item1;
				rows[i].Cells[1].Value = 
					ConvertSizeToUnit(file.Item2, 
						cbUnit.SelectedItem.ToString()
					) + " " + 
					cbUnit.SelectedItem.ToString();
			}

			rgv.Rows.AddRange(rows);

			if (rgv.RowCount > 0)
				btnEnable.Enabled = true;
			else
				btnEnable.Enabled = false;
		}

		public void UpdateBitsToUse(string numOfBits)
		{
			if (numOfBits == string.Empty)
				numOfBits = "0";

			bitsToUse
				= Int32.Parse(numOfBits);

			algorithm.SetParameters(bitsToUse, filesProcessor.AudioFile, filesProcessor.Files);
		}

		public int ConvertSizeToUnit(int size, string unit)
		{
			switch (unit)
			{
				case "B":
					return size;
				case "KB":
					return (size / 1024);
				case "MB":
					return (size / 1024 / 1024);
				default:
					return 0;
			}
		}

		public void UpdatedExportPath(TextBox tbExportPath, Button btnExport)
		{
			return;
		}

		public void EnableButton(Button btn, RadGridView gridView)
		{
			if (gridView.RowCount > 0)
				btn.Enabled = true;
			else
				btn.Enabled = false;
		}
		#endregion interface methods
	}
}
