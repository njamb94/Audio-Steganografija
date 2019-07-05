using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Digitalna_Forenzika.Model;
using Digitalna_Forenzika.Helpers;
using Digitalna_Forenzika.Interfaces;
using Digitalna_Forenzika.Enums;
using Digitalna_Forenzika.Algorithm;

namespace Digitalna_Forenzika.Processor
{
	public class LSBAlgorithm
	{
		ICrypto crypto;
		int bitsToUse;

		public LSBAlgorithm(ECrypto cryptoType)
		{
			if (cryptoType == ECrypto.Encryption)
				crypto = new Encryption();
			else
				crypto = new Decryption();
		}

		public void SetParameters(int bitsToUse, FilePlaceholder audioFile, List<FilePlaceholder> files)
		{
			crypto.SetParameters(audioFile, bitsToUse, 
				files.Select(x => x.FullFilePath).ToList());
		}
		
		public void CreateStegoFile()
		{
			crypto.Encrypt();
		}

		public int GetMsgToEmbedSize()
		{
			return crypto.GetEncryptedContentSize();
		}

		public List<Tuple<string, int>> LookForHiddenFiles()
		{
			return crypto.Decrypt();
		}

		public void AddFilesToEmbed(List<string> filePaths)
		{
			crypto.AddFilesToEmbed(filePaths);
		}

		public void ExportDecryptedFiles(string path)
		{
			List<FilePlaceholder> decryptedFiles = crypto.GetDecryptedFiles();

			if (!System.IO.Directory.Exists(path))
			{
				System.IO.Directory.CreateDirectory(path);
			}

			foreach (FilePlaceholder fp in decryptedFiles)
			{
				FileStream fs = File.OpenWrite(path +
					"\\" + fp.FileName);
				fs.Write(fp.FileBinary, 0, fp.FileBinary.Length);
				fs.Close();
				fs.Dispose();
			}

			// In decryption, Encrypt() method exports file to the system:
			//crypto.Encrypt();
		}
	}
}

