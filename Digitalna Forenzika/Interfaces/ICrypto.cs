using Digitalna_Forenzika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalna_Forenzika.Interfaces
{
	public interface ICrypto
	{
		void Encrypt();
		List<Tuple<string, int>> Decrypt();
		void SetParameters(
			FilePlaceholder audioFile, int bitsToUse, List<string> fileToEmbed);
		T GetHostFile<T>() where T : class;
		int GetEncryptedContentSize();
		void AddFilesToEmbed(List<string> filePaths);
		List<FilePlaceholder> GetDecryptedFiles();
	}
}
