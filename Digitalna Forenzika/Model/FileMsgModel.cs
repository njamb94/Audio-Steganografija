using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalna_Forenzika.Model
{
	public class FileMsgModel
	{
		string fileName;
		byte[] fileNameLengthInBytes;
		byte[] fileContent;

		public string FileName
		{
			get => fileName;
			set => fileName = value;
		}

		public byte[] FileNameLengthInBytes
		{
			get => fileNameLengthInBytes;
			set => fileNameLengthInBytes = value;
		}

		public byte[] FileContent
		{
			get => fileContent;
			set => fileContent = value;
		}

		public FileMsgModel() {
			fileName = string.Empty;
			fileNameLengthInBytes = new byte[0];
			fileContent = new byte[0];
		}


		public static List<FileMsgModel> CreateAndPopulateFileMsgModels(List<string> files)
		{
			List<FileMsgModel> fileMsgModels = new List<FileMsgModel>();
			string fileName;

			foreach (string file in files)
			{
				FileStream fs =
					File.Open(file, FileMode.Open, FileAccess.Read);
				fileName = fs.Name.Substring(fs.Name.LastIndexOf("\\") + 1);
				fs.Close();
				fs.Dispose();

				// Instantiate our model:
				FileMsgModel fileMsgModel = new FileMsgModel();

				// Fill in the model:
				fileMsgModel.FileName =
					fs.Name.Substring(fs.Name.LastIndexOf("\\") + 1);

				fileMsgModel.FileNameLengthInBytes =
					BitConverter.GetBytes(fileMsgModel.FileName.Length);

				fileMsgModel.FileContent = File.ReadAllBytes(file);

				fileMsgModels.Add(fileMsgModel);
			}

			return fileMsgModels;
		}
	}

}
