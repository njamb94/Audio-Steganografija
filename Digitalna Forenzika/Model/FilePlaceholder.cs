using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalna_Forenzika.Model
{
	public class FilePlaceholder
	{
		string fileName;
		string fullFilePath;
		byte[] fileBinary;
		WaveFormat hostFile;

		public FilePlaceholder()
		{
			fileName = string.Empty;
			fullFilePath = string.Empty;
			fileBinary = new byte[0];
			hostFile = new WaveFormat();
		}

		public FilePlaceholder(string name, string path, byte[] binary, WaveFormat host)
		{
			fileName = name;
			fullFilePath = path;
			fileBinary = binary;
			hostFile = host;
		}

		public string FileName
		{
			get => fileName;
			set => fileName = value;
		}

		public string FullFilePath
		{
			get => fullFilePath;
			set => fullFilePath = value;
		}

		public byte[] FileBinary
		{
			get => fileBinary;
			set => fileBinary = value;
		}

		public WaveFormat HostFile
		{
			get => hostFile;
			set => hostFile = value;
		}
	}
}
