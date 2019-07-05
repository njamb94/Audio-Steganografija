using Digitalna_Forenzika.Interfaces;
using Digitalna_Forenzika.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalna_Forenzika.Processor
{
	public class FilesProcessor : ILoadFile
	{
		#region constants
		const string WAV = "wav";
		#endregion constants

		#region variables
		FilePlaceholder audioFile;
		List<FilePlaceholder> files;
		#endregion variables

		#region properties
		public FilePlaceholder AudioFile
		{
			get => audioFile;
		}

		public List<FilePlaceholder> Files
		{
			get => files;
		}
		#endregion properties

		public FilesProcessor()
		{
			audioFile = new FilePlaceholder();
			files = new List<FilePlaceholder>();
		}

		#region IUI interface
		public IList<string> LoadFiles()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.DefaultExt = "All";
			ofd.Filter = "All (*.*)|*.*";
			ofd.Multiselect = true;

			List<string> filePaths = new List<string>();

			DialogResult result = ofd.ShowDialog();

			if (result == DialogResult.OK)
			{
				filePaths = ofd.FileNames.ToList();
			}

			return filePaths;
		}

		public string LoadFile()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.DefaultExt = WAV;
			ofd.Filter = WAV + " (*." + WAV + ")|*." + WAV;
			ofd.Multiselect = false;

			string filePath = null;

			DialogResult result = ofd.ShowDialog();

			if (result == DialogResult.OK)
			{
				filePath = ofd.FileName;
			}

			return filePath;
		}
		#endregion IUI interface

		public void PopulateAudioFile(bool openDialog = true)
		{
			string path;
			if (openDialog)
				path = LoadFile();
			else
				path = audioFile.FullFilePath;

			if (path != string.Empty)
			{
				audioFile = new FilePlaceholder();
				audioFile = GetPopulatedAudioPlaceHolder(path);
				audioFile.HostFile.PopulateWaveFileModel();

				// asssssss
				Console.WriteLine("Audio File Name: " + audioFile.FileName);
			}
		}

		public List<string> OpenAndAddFiles()
		{
			List<string> paths = LoadFiles().ToList();

			if (paths.Count == 0)
				return paths;

			foreach (string path in paths)
			{
				FilePlaceholder fp = GetPopulatedPlaceholder(path);

				if (files.Exists(x => x.FullFilePath == fp.FullFilePath))
				{
					break;
				}
				else
				{
					files.Add(fp);
				}
			}

			return paths;
		}

		public FilePlaceholder GetPopulatedAudioPlaceHolder(string path)
		{
			FilePlaceholder fp = GetPopulatedPlaceholder(path);
			fp.HostFile.HostFileInBytes = fp.FileBinary;
			return fp;
		}

		public FilePlaceholder GetPopulatedPlaceholder(string path)
		{
			FilePlaceholder fp = new FilePlaceholder();
			
			fp.FullFilePath = path;
			fp.FileName = GetFileNameFromPath(path);
			fp.FileBinary = File.ReadAllBytes(path);

			return fp;
		}

		private string GetFileNameFromPath(string path)
		{
			if (path == string.Empty)
				return string.Empty;

			return path.Substring(path.LastIndexOf('\\') + 1);
		}

		public List<Tuple<string, int>> GetFileNamesWithByteSize()
		{
			List<Tuple<string, int>> retList 
				= new List<Tuple<string, int>>();

			foreach (FilePlaceholder fp in files)
			{
				Tuple<string, int> fileWithByteSize 
					= new Tuple<string, int>(
						fp.FileName, fp.FileBinary.Length);

				retList.Add(fileWithByteSize);
			}

			return retList;
		}

		public string GetAudioFileName()
		{
			return audioFile.FileName;
		}
	}
}
