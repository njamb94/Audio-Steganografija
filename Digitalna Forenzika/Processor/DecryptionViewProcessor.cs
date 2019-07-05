using Digitalna_Forenzika.Interfaces;
using Digitalna_Forenzika.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Digitalna_Forenzika.Processor
{
	public class DecryptionViewProcessor : IViewProcessor
	{
		#region private members
		int bitsToUse;
		FilesProcessor filesProcessor;
		LSBAlgorithm algorithm;
		#endregion private members

		#region constructor
		public DecryptionViewProcessor()
		{
			filesProcessor = new FilesProcessor();
			algorithm = new LSBAlgorithm(Enums.ECrypto.Decryption);
			bitsToUse = 0;
		}
		#endregion constructor

		#region helper methods

		private int GetRemainingSpaceInBytes()
		{
			int remainingSpace =
				(bitsToUse * filesProcessor.AudioFile.HostFile.NumOfSamples)
				/
				8 - filesProcessor.Files.Sum(x => x.FileBinary.Length) - algorithm.GetMsgToEmbedSize();

			if (remainingSpace < 0)
				return 0;
			else
				return remainingSpace;
		}

		private void SelectBitsToUseInitial(ComboBox cb, string val)
		{
			cb.SelectedItem = Int32.Parse(val);
		}

		public void UpdatedExportPath(TextBox tbExportLocation, 
			Button btnExport)
		{
			// Dialog Window -> choose folder
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult result = fbd.ShowDialog();

			if (result == DialogResult.OK)
			{
				string path = fbd.SelectedPath;

				if (path != string.Empty)
				{
					tbExportLocation.Text = path;

					btnExport.Enabled = true;
				}
				else if (tbExportLocation.Text == string.Empty)
				{
					btnExport.Enabled = false;
				}
			}

			// If returned value NOT string.Empty, enable btnExport
		}
		#endregion helper methods

		#region interface methods

		public void BitsToUseChanged(ComboBox cbBitsToUse, ComboBox cbUnit, 
			Label lblFreeSpace)
		{
			if (cbBitsToUse.SelectedItem == null)
				SelectBitsToUseInitial(cbBitsToUse, "1");

			UpdateBitsToUse(cbBitsToUse.SelectedItem.ToString());
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

		public bool OpenFiles(RadGridView rgv, ComboBox cbUnit, 
			Button btnEnable, Label remainingSpace)
		{
			return true;
		}

		public void PopulateAudioFile(bool openDialog = true)
		{
			filesProcessor.PopulateAudioFile(openDialog);

			algorithm.SetParameters(bitsToUse, filesProcessor.AudioFile, filesProcessor.Files);
		}

		public void PopulateControls(ComboBox cbUnit, ComboBox cbBitsToUse)
		{
			for (int i = 1; i < 17; i++)
				cbBitsToUse.Items.Add(i);

			cbUnit.Items.Add("B");
			cbUnit.Items.Add("KB");
			cbUnit.Items.Add("MB");

			cbUnit.SelectedItem = "B";
			cbBitsToUse.SelectedItem = 1;
		}

		public void PopulateGrid(RadGridView rgv, Button btnEnable, 
			ComboBox cbUnit, Label remainingSpace, TextBox tbExportPath)
		{
			rgv.Rows.Clear();

			List<Tuple<string, int>> hiddenFiles = 
				algorithm.LookForHiddenFiles();

			foreach (Tuple<string, int> file in hiddenFiles)
			{
				rgv.Rows.Add(file.Item1, ConvertSizeToUnit(file.Item2, 
					cbUnit.SelectedItem.ToString()));
			}

			if (rgv.RowCount > 0 && tbExportPath.Text != string.Empty)
				btnEnable.Enabled = true;
			else
				btnEnable.Enabled = false;

			return;

			/////////////////////////////////////////////////
			List<Tuple<string, int>> fileNamesWithByteSize
				= filesProcessor.GetFileNamesWithByteSize();

			GridViewDataRowInfo[] rows =
				new GridViewDataRowInfo[fileNamesWithByteSize.Count];

			for (int i = 0; i < rows.Length; i++)
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
		}

		public void UpdateAudioFileLabel(Label lbl)
		{
			lbl.Text = filesProcessor.GetAudioFileName();
		}

		public void UpdateBitsToUse(string numOfBits)
		{
			if (numOfBits == string.Empty)
				numOfBits = "0";

			bitsToUse
				= Int32.Parse(numOfBits);
		}

		public void WorkYourMagic(string path = "")
		{
			Dictionary<string, List<byte>> filesWithDataDict =
					new Dictionary<string, List<byte>>();

			List<Tuple<string, int>> fileNamesWithSize = 
				algorithm.LookForHiddenFiles();

			if (!System.IO.Directory.Exists(Environment.GetFolderPath(
					Environment.SpecialFolder.Desktop) +
					"\\Digitalna Forenzika"))
			{
				System.IO.Directory.CreateDirectory(Environment
					.GetFolderPath(Environment.SpecialFolder.Desktop) +
					"\\Digitalna Forenzika");
			}

			algorithm.ExportDecryptedFiles(path);
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
