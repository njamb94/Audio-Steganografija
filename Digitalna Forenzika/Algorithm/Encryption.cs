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
	public class Encryption : ICrypto
	{
		#region private members;
		FilePlaceholder audioFile;
		int bitsToUse;
		List<string> filesToEmbed;
		#endregion private members;

		#region properties;
		public int BitsToUse
		{
			get => bitsToUse;
			set => bitsToUse = value;
		}
		public List<string> FilesToEmbed
		{
			get => filesToEmbed;
			set => filesToEmbed = value;
		}
		#endregion properties;

		#region constructor;
		public Encryption()
		{
			audioFile = new FilePlaceholder();
			bitsToUse = 0;
			filesToEmbed = new List<string>();
		}
		#endregion constructor;

		#region Interface Methods
		public void Encrypt()
		{
			// Placeholders for the inner part of the message (formatted) 
			// and outer part (with headers):
			List<byte> innerMsg;

			// Create the inner part of the message:
			innerMsg = CreateMsgToEmbed();

			EmbedMsg(innerMsg);

			ExportStegoFile();
		}

		List<Tuple<string, int>> ICrypto.Decrypt()
		{
			return new List<Tuple<string, int>>();
		}

		public void SetParameters(FilePlaceholder audioFile, int bitsToUse, 
			List<string> filesToEmbed)
		{
			this.audioFile = audioFile;
			this.bitsToUse = bitsToUse;
			this.filesToEmbed = filesToEmbed;
		}

		public FilePlaceholder GetHostFile<FilePlaceholder>() where FilePlaceholder : class
		{
			return this.audioFile as FilePlaceholder;
		}

		public int GetEncryptedContentSize()
		{
			int size = CreateMsgToEmbed().Count;

			// Additional 4B goes for InnerMsgLength to read for decryption:
			return size + 4;
		}

		public void AddFilesToEmbed(List<string> filePaths)
		{
			this.filesToEmbed = filePaths;
		}

		public List<FilePlaceholder> GetDecryptedFiles()
		{
			return new List<FilePlaceholder>();
		}
		#endregion Interface Methods

		#region methods;

		private byte[] RecreateFile()
		{
			List<byte> fileBinary = new List<byte>();

			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.ChunkID));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.ChunkSize));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.Format));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.SubchunkID));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.SubchunkSize));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.AudioFormat));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.NumOfChannels));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.SampleRate));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.ByteRate));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.BlockAlign));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.BitsPerSample));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.Subchunk2ID));
			fileBinary.AddRange(BitConverter.GetBytes(audioFile.HostFile.NumOfBytesInTheDataPart));
			fileBinary.AddRange(audioFile.HostFile.FileData);

			//int offset = 44;
			//byte[] dataPart = 
			//	new byte[audioFile.HostFile.HostFileInBytes.Length - offset];

			//for (int i = 0; offset < audioFile.HostFile.HostFileInBytes.Length; 
			//	offset++, i++)
			//{
			//	dataPart[i] = audioFile.HostFile.HostFileInBytes[offset];
			//}

			////audioFile.HostFile.HostFileInBytes.CopyTo(dataPart, offset);

			//fileBinary.AddRange(dataPart);

			return fileBinary.ToArray();

			// Vrati original:
			//return audioFile.HostFile.HostFileInBytes;
		}

		/// <summary>
		/// Creates an inner message to be sent as list of bytes. 
		/// * Message format:
		/// ** First 4B are number of files in the message.
		/// ** Second 4B are first file's name length (N).
		/// ** Third N bytes for first file's name.
		/// ** Fourth 4B are file's data size.
		/// ** Second file goes now.
		/// ** Then goes the data for first file.
		/// ** After that goes the data for the second file.
		/// ** Repeat for each file.
		/// </summary>
		/// <param name="files">Files with paths to embed.</param>
		/// <returns></returns>
		private List<byte> CreateMsgToEmbed()
		{
			int numOfFiles = filesToEmbed.Count;
			string fileName = string.Empty;
			List<byte> msg = new List<byte>();

			byte[] numOfFilesInBytes = BitConverter.GetBytes(numOfFiles);

			msg.AddRange(numOfFilesInBytes);

			// Our model for creating msg:
			List<FileMsgModel> fileMsgModels = new List<FileMsgModel>();

			fileMsgModels = 
				FileMsgModel.CreateAndPopulateFileMsgModels(filesToEmbed);

			foreach (FileMsgModel fileModel in fileMsgModels)
			{
				// Append file name's length in bytes:
				msg.AddRange(fileModel.FileNameLengthInBytes);

				// Append file name (it's binary representation):
				msg.AddRange(Encoding.ASCII.GetBytes(fileModel.FileName));

				// Append file content's size:
				msg.AddRange(BitConverter.GetBytes(
					fileModel.FileContent.Length));
			}

			// For each file append it's content (binary) to our msg:
			foreach (FileMsgModel fileModel in fileMsgModels)
			{
				msg.AddRange(fileModel.FileContent);
			}

			return msg;
		}

		/// <summary>
		/// Takes the message that needs to be embeded, adds header to it
		/// and embeds bytes in their corresponding places in the samples in 
		/// the host file's data part.
		/// 
		/// Embedded message format:
		/// 
		/// Header:
		/// //First BYTE is used for storing bit count used in encryption.
		/// First 4B are used to store message byte count 
		/// (how many bytes we need to read).
		/// 
		/// Body:
		/// Third comes the message.
		/// </summary>
		/// <param name="msg">List of bytes representing the message that 
		/// needs to be embedded in the host file's data part.</param>
		private void EmbedMsg(List<byte> msg)
		{
			//byte[] byteMsg = msg.ToArray();
			byte[] sample = null;
			int numberOfBytesInMsg = msg.Count;
			int k = 0;
			byte[] fileData = audioFile.HostFile.FileData;

			// List of samples extracted from the data:
			List<byte[]> samples = new List<byte[]>();

			// Placeholder for our outer msg which will be embedded in the 
			// audio (host) file:
			List<byte> outerMsg = new List<byte>();

			byte[] msgSize = BitConverter.GetBytes(msg.Count);
			int p = 0;

			// 1. Add number of bits to use per sample: (1B)
			//outerMsg.Add(BitConverter.GetBytes(NumberOfBitsToUsePerSample)[0]);

			// 2. Add number of bytes to read for the inner msg: (4B)
			outerMsg.AddRange(BitConverter.GetBytes(msg.Count));

			// 3. Add msg: (nB):
			outerMsg.AddRange(msg);
			//0b0110;

			// Get samples from the data:
			for (int i = 0; i < audioFile.HostFile.NumOfBytesInTheDataPart; i++, k++)
			{
				sample = new byte[audioFile.HostFile.BlockAlign];

				for (k = 0; k < audioFile.HostFile.BlockAlign; k++, i++, p++)
				{
					// This is needed for msgSize's second (4B):
					//sample[k] = 0;

					//if (p == 0)
					//{
					//	// We only need the first byte, because number of 
					//	// bits to use per sample's each byte is [1-4] bits
					//	// which are stored in only 1 byte.
					//	sample[k] = BitConverter.GetBytes(bitsToUse)[0];
					//}
					// Add msgSize as integer (4B):
					///*else */if (p < 4)
					//{
					//	sample[k] = msgSize[p];
					//}
					//// Add file data:
					//else
					//{
						sample[k] = fileData[i];
					//}
				}

				if (k == audioFile.HostFile.BlockAlign)
					i--;

				samples.Add(sample);
			}

			//////////////
			// solution //
			//////////////

			/// Flag if the current bit in the current byte 
			/// of the outerMsg has been set.
			bool isBitSet = false;
			/// Byte used for testing if the current bit in the current byte
			/// of the outerMsg has been set.
			byte shifter = 0b00000001;

			CounterHolder counterHolder = new CounterHolder();

			// Embed outerMsg in samples:
			foreach (byte _byte in outerMsg)
			{
				for (int i = 0; i < 8; i++)
				{
					if (shifter == (byte)(_byte & shifter))
					{
						isBitSet = true;
					}
					else
					{
						isBitSet = false;
					}

					// Embed bit from the outerMsg:
					EmbedBitInHostsFileSamples(isBitSet, samples, counterHolder);

					// Shift our shifter by 1 position to the left:
					shifter = (byte)(shifter << 1);
					// Reset shifter if we've ran out of positions to shift:
					if (shifter == 0)
					{
						shifter = 0b00000001;
					}
				}
			}

			List<byte> newDataPart = new List<byte>();
			foreach (byte[] smpl in samples)
			{
				newDataPart.AddRange(smpl);
			}

			//audioFile.HostFile.FileData = newDataPart.ToArray();

			// izdvoji header bez data dela,
			List<byte> newHostFile = new List<byte>();

			for (int i = 0; i < audioFile.HostFile.HostFileInBytes.Length -
				newDataPart.Count; i++)
			{
				newHostFile.Add(audioFile.HostFile.HostFileInBytes[i]);
			}

			// uzmi header i spoji sa novim data delom

			audioFile.HostFile.FileData = newDataPart.ToArray();// newHostFile.ToArray();



			//newHostFile.AddRange(audioFile.HostFile.FileData);

			//audioFile.HostFile.HostFileInBytes = newHostFile.ToArray();
			//
		}

		private void EmbedBitInHostsFileSamples(bool bitToSet,
			List<byte[]> samples, CounterHolder counterHolder)
		{
			// Get next sample's byte:
			byte sampleByte = samples[counterHolder.SampleCounter]
				[counterHolder.SampleByteCounter];
			byte bitTester;

			// Set bit tester appropriately:
			bitTester = (byte)(0b00000001 << (counterHolder.BitByteCounter));

			// If both bitTester's and sampleByte's bit have been set:
			if (bitTester == (byte)(sampleByte & bitTester))
			{
				// Only if the bit needs to be 0, set it: 
				if (!bitToSet)
				{
					sampleByte = (byte)(sampleByte & ~bitTester);
				}
			}
			// If both bitTester's and sampleByte's bit have not been set:
			else
			{
				// Only if the bit needs to be 1, set it:
				if (bitToSet)
				{
					sampleByte = (byte)(sampleByte | bitTester);
				}
			}

			// Switch our sample with the embedded sample:
			samples[counterHolder.SampleCounter]
				[counterHolder.SampleByteCounter] = sampleByte;

			IncreaseAndCheckCounters(counterHolder);
		}

		private void IncreaseAndCheckCounters(CounterHolder counterHolder, 
			bool isDecription = false)
		{
			if (counterHolder.BitCounter == 
				audioFile.HostFile.FileData.Length * 8)
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
			///////////////////////////////////////////

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
			///////////////////////////////////////////
			//if (counterHolder.SampleCounter == audioFile.HostFile.NumOfSamples - 1
			//&&
			//counterHolder.SampleByteCounter == audioFile.HostFile.BlockAlign - 1)
			//{
			//	counterHolder.BitByteCounter++;
			//	counterHolder.SampleCounter = 0;
			//	counterHolder.SampleByteCounter = 0;
			//}
			//else if (counterHolder.SampleCounter == audioFile.HostFile.NumOfSamples - 1)
			//{

			//	counterHolder.SampleCounter = 0;
			//	counterHolder.SampleByteCounter++;
			//}
			//else
			//{
			//	counterHolder.SampleCounter++;

			//	if (counterHolder.BitByteCounter == bitsToUse)
			//	{
			//		counterHolder.BitByteCounter = 0;
			//	}
			//}

			// OVO RADI NAJBOLJE
			//if (counterHolder.SampleCounter == audioFile.HostFile.NumOfSamples - 1
			//	&&
			//	counterHolder.SampleByteCounter == audioFile.HostFile.BlockAlign - 1)
			//{
			//	counterHolder.BitByteCounter++;
			//	counterHolder.SampleCounter = 0;
			//	counterHolder.SampleByteCounter = 0;
			//}
			//else if (counterHolder.SampleCounter == audioFile.HostFile.NumOfSamples - 1)
			//{
			//	counterHolder.SampleCounter = 0;
			//	counterHolder.SampleByteCounter++;
			//}
			//else
			//{
			//	counterHolder.SampleCounter++;

			//	if (counterHolder.BitByteCounter == bitsToUse)
			//	{
			//		counterHolder.BitByteCounter = 0;
			//	}
			//}
		}

		private void ExportStegoFile()
		{
			byte[] stegoFileBinaries = RecreateFile();

			FileStream fs = File.Create(Environment.GetFolderPath(
						Environment.SpecialFolder.Desktop) +
						"\\Digitalna Forenzika\\" + "stego_" + audioFile.FileName);
			fs.Write(stegoFileBinaries, 0, stegoFileBinaries.Length);
			fs.Close();
			fs.Dispose();
		}
		#endregion methods;
	}
}
