using Digitalna_Forenzika.Helpers;
using Digitalna_Forenzika.Interfaces;
using Digitalna_Forenzika.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalna_Forenzika.Algorithm
{
	public class Decryption : ICrypto
	{
		FilePlaceholder audioFile;
		List<FilePlaceholder> decryptedFiles;
		int bitsToUse;
		List<string> filesToEmbed;
		List<Tuple<string, int>> _fileNamesWithSize;
		// TODO: Add List<FilePlaceholder> for decrypted files!

		public List<Tuple<string, int>> Decrypt()
		{
			try
			{
				List<byte[]> samples = GetSamplesFromData();
				List<byte> outerMsg = RecreateOuterMsgFromSamples(samples);
				List<Tuple<string, int>> fileNamesWithSize = RecreateMsg(outerMsg);

				_fileNamesWithSize = fileNamesWithSize;

				return fileNamesWithSize;
			}
			catch (Exception e)
			{
				Console.WriteLine("Probably no files were " +
					"embeded in this audio file. Exception message: " + 
					e.StackTrace);

				return new List<Tuple<string, int>>();
			}
		}

		public void Encrypt()
		{
			foreach (FilePlaceholder fp in decryptedFiles)
			{
				FileStream fs = File.OpenWrite(Environment.GetFolderPath(
					Environment.SpecialFolder.Desktop) +
					"\\Digitalna Forenzika\\" + fp.FileName);
				fs.Write(fp.FileBinary, 0, fp.FileBinary.Length);
				fs.Close();
				fs.Dispose();
			}
		}

		public void SetParameters(FilePlaceholder audioFile, int bitsToUse, List<string> fileToEmbed)
		{
			this.audioFile = audioFile;
			this.bitsToUse = bitsToUse;
			this.decryptedFiles = new List<FilePlaceholder>();
			this.filesToEmbed = filesToEmbed;
		}

		public FilePlaceholder GetHostFile<FilePlaceholder>() where FilePlaceholder : class
		{
			return this.audioFile as FilePlaceholder;
		}

		public int GetEncryptedContentSize()
		{
			return this.audioFile.FileBinary.Length;
		}

		public void AddFilesToEmbed(List<string> filePaths)
		{
			this.filesToEmbed = filePaths;
		}

		public List<FilePlaceholder> GetDecryptedFiles()
		{
			return decryptedFiles;
		}
		//////////////////////////////////////////////////////////////
		private List<byte[]> GetSamplesFromData()
		{
			List<byte[]> samples = new List<byte[]>();
			byte[] sample;
			int k = 0;

			for (int i = 0; i < audioFile.HostFile.NumOfBytesInTheDataPart; i++, k++)
			{
				sample = new byte[audioFile.HostFile.BlockAlign];

				for (k = 0; k < audioFile.HostFile.BlockAlign; k++, i++)
				{
					sample[k] = audioFile.HostFile.FileData[i];
				}

				if (k == audioFile.HostFile.BlockAlign)
					i--;

				samples.Add(sample);
			}

			return samples;
		}

		private List<byte> RecreateOuterMsgFromSamples(List<byte[]> samples)
		{
			byte msgByte = 0b00000000;
			bool msgBit;
			// First 4B represent inner msg size:
			double bitsToRead = 32;
			List<byte> outerMsg = new List<byte>();
			CounterHolder counter = new CounterHolder();

			while (counter.BitCounter < bitsToRead)
			{
				msgByte = 0b00000000;

				for (int i = 0; i < 8; i++)
				{
					msgBit = ReadBitFromSamples(samples, counter);

					if (i == 0)
					{
						if (msgBit)
							msgByte = 0b00000001;
						else
							msgByte = 0b00000000;
					}
					else
					{
						msgByte = (byte)(msgByte << 1);

						if (msgBit)
							msgByte |= 0b00000001;
					}

					IncreaseAndCheckCounters(counter);
				}

				msgByte = ReverseByte(msgByte);

				outerMsg.Add(msgByte);

				if (counter.BitCounter == bitsToRead && bitsToRead == 32)
				{
					// First 4B hold inner msg size + these traversed 4B(32b):
					bitsToRead = BitConverter.ToUInt32(outerMsg.ToArray(), 0) //+ 32;
						* 8 + 32;
				}
			}

			return outerMsg;
		}

		private void IncreaseAndCheckCounters(CounterHolder counterHolder, bool isDecription = false)
		{
			if (counterHolder.BitCounter == audioFile.HostFile.FileData.Length * 8)
			{
				counterHolder.BitCounter = 0;
				Console.WriteLine("BitCounter = " + 
					audioFile.HostFile.FileData.Length * 8);
			}
			else
			{
				if (!isDecription)
					counterHolder.BitCounter++;
			}

			// ORIDJIDJI
			//if (counterHolder.BitByteCounter == bitsToUse)
			//{
			//	counterHolder.BitByteCounter = 0;
			//}
			//else
			//{
			//	counterHolder.BitByteCounter++;
			//}

			//if (counterHolder.SampleByteCounter ==
			//	audioFile.HostFile.BlockAlign - 1)
			//{
			//	counterHolder.SampleByteCounter = 0;
			//	counterHolder.SampleCounter++;
			//}
			//else
			//{
			//	counterHolder.SampleByteCounter++;
			//}



			if (counterHolder.SampleCounter == audioFile.HostFile.NumOfSamples - 1)
			{
				if (counterHolder.SampleByteCounter != audioFile.HostFile.BlockAlign - 1)
				{
					counterHolder.SampleCounter = 0;
					counterHolder.SampleByteCounter++;
				}
				else
				{
					if (counterHolder.BitByteCounter != bitsToUse - 1)
					{
						counterHolder.BitByteCounter++;
					}
					counterHolder.SampleCounter = 0;
					counterHolder.SampleByteCounter = 0;
				}
			}
			else
			{
				counterHolder.SampleCounter++;
			}



			//
			//if (counterHolder.BitByteCounter == bitsToUse && counterHolder.SampleByteCounter == audioFile.HostFile.BlockAlign - 1)
			//{
			//	counterHolder.SampleCounter++;
			//}

			//if (counterHolder.BitByteCounter == bitsToUse)
			//{
			//	counterHolder.BitByteCounter = 0;
			//	counterHolder.SampleByteCounter++;
			//}
			//else
			//{
			//	counterHolder.BitByteCounter++;
			//}

			//if (counterHolder.SampleByteCounter == audioFile.HostFile.BlockAlign - 1)
			//{
			//	counterHolder.SampleByteCounter = 0;
			//	//counterHolder.SampleCounter++;
			//	counterHolder.BitByteCounter++;
			//}
			//else
			//{
			//	//counterHolder.SampleByteCounter++;
			//}
		}

		private bool ReadBitFromSamples(List<byte[]> samples,
			CounterHolder counter)
		{
			byte sampleByte = samples[counter.SampleCounter]
				[counter.SampleByteCounter];
			byte bitTester;

			// Set bit tester appropriately:
			bitTester = (byte)(0b00000001 << (counter.BitByteCounter));

			if (bitTester == (byte)(sampleByte & bitTester))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private byte ReverseByte(byte msgByte)
		{
			byte shifter = 0b00000001; // 1
			byte setter = 0b10000000; // 128
			byte newByte = 0;

			for (int i = 0; i < 8; i++)
			{
				if (shifter == (byte)(msgByte & shifter))
				{
					newByte |= setter;
				}

				shifter = (byte)(shifter << 1);
				setter = (byte)(setter >> 1);

				if (0b10000000 == (byte)(setter & 0b10000000))
					setter = 0b01000000;
			}

			return newByte;
		}

		//private asd(List<byte[]> samples, List<byte> outerMsg) {

		//	// Testing validity of the algorithms:

		//	List<byte> outerMsg2 = RecreateOuterMsgFromSamples(samples); // Valid!

		//	// Inner msg = OuterMsg - 4B for inner msg size:
		//	byte[] innerMsg = new byte[outerMsg2.Count - 4];

		//	for (int i = 4; i < outerMsg2.Count; i++)
		//	{
		//		innerMsg[i - 4] = outerMsg2[i];
		//	}

		//	RecreateMsg(innerMsg.ToList());

		//	bool same = true;

		//	if (outerMsg2.Count != outerMsg.Count)
		//	{
		//		Console.WriteLine("Not the same size!");
		//		return;
		//	}

		//	for (int i = 0; i < outerMsg.Count; i++)
		//	{
		//		if (outerMsg[i] != outerMsg2[i])
		//		{
		//			Console.WriteLine("Different values!");
		//			same = false;
		//			break;
		//		}
		//	}

		//	if (same)
		//		Console.WriteLine("Same!");
		//	else
		//		Console.WriteLine("NOT same!");
		//	///////////////////////////////////////////////////////////////////////////////

		//}


		/// <summary>
		/// Gets the whole message as list of bytes and recreates files 
		/// from it.
		/// </summary>
		/// <param name="msg">List of bytes representing the message 
		/// sent through audio file.</param>
		private List<Tuple<string, int>> RecreateMsg(List<byte> msg)
		{
			try
			{
				int numOfFiles;
				string fileName = string.Empty;

				int fileNameLength;
				int fileSize;
				byte[] numOfFilesInBytes = new byte[4];

				byte[] simplerMsg = msg.ToArray();
				int index = 4;

				// Get number of files:
				numOfFiles = BitConverter.ToInt32(simplerMsg, index);
				index += 4;

				List<Tuple<string, int>> fileNamesWithSize
					= new List<Tuple<string, int>>();

				for (int i = 0; i < numOfFiles; i++)
				{
					// Get file name length:
					fileNameLength = BitConverter.ToInt32(simplerMsg, index);
					index += 4;

					// Get file name:
					fileName = Encoding.ASCII.GetString(simplerMsg, index,
						fileNameLength);
					index += fileNameLength;

					// Get file size:
					fileSize = BitConverter.ToInt32(simplerMsg, index);
					index += 4;

					// Add file name and file size to the list of files:
					fileNamesWithSize.Add(
						new Tuple<string, int>(fileName, fileSize));
				}

				// Check and create necessary directory:
				if (!System.IO.Directory.Exists(Environment.GetFolderPath(
						Environment.SpecialFolder.Desktop) +
						"\\Digitalna Forenzika"))
				{
					System.IO.Directory.CreateDirectory(Environment
						.GetFolderPath(Environment.SpecialFolder.Desktop) +
						"\\Digitalna Forenzika");
				}

				List<byte> fileData = new List<byte>();
				foreach (Tuple<string, int> fileWithSize in fileNamesWithSize)
				{
					FilePlaceholder fp = new FilePlaceholder();
					fp.FileName = fileWithSize.Item1;
					fp.FullFilePath = "";

					fileData = new List<byte>();

					for (int i = 0; i < fileWithSize.Item2; i++)
					{
						fileData.Add(simplerMsg[index]);
						index++;
					}

					fp.FileBinary = fileData.ToArray();

					decryptedFiles.Add(fp);
				}

				return fileNamesWithSize;
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}

			return new List<Tuple<string, int>>();
		}

	}
}
