using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalna_Forenzika.Model
{
	public class WaveFormat
	{
		/// <summary>
		/// Pos: [0-4):4B
		/// </summary>
		int _chunkID;
		/// <summary>
		/// Pos: [4-8):4B
		/// </summary>
		int _chunkSize;
		/// <summary>
		/// Pos: [8-12):4B
		/// </summary>
		int _format;
		/// <summary>
		/// Pos: [12-16):4B
		/// </summary>
		int _subchunkID;
		/// <summary>
		/// Pos: [16-20):4B
		/// </summary>
		int _subchunkSize;
		/// <summary>
		/// Pos: [20-22):2B
		/// </summary>
		short _audioFormat;
		/// <summary>
		/// Pos: [22-24):2B
		/// </summary>
		short _numOfChannels;
		/// <summary>
		/// Pos: [24-28):4B
		/// </summary>
		int _sampleRate;
		/// <summary>
		/// Pos: [28-32):4B
		/// </summary>
		int _byteRate;
		/// <summary>
		/// Pos: [32-34):2B
		/// </summary>
		short _blockAlign; // number of bytes per sample (/w channels)
		/// <summary>
		/// Pos: [34-36):2B
		/// </summary>
		short _bitsPerSample;
		/// <summary>
		/// Pos: [36-40):4B
		/// </summary>
		int _subchunk2ID;
		/// <summary>
		/// Pos: [40-44):4B
		/// </summary>
		int _numOfBytesInTheDataPart;
		int _numOfSamples;
		byte[] _hostFileInBytes;
		byte[] _fileData;
		int _songLengthInSeconds;

		public WaveFormat()
		{
			_chunkID = -1;
			_chunkSize = -1;
			_format = -1;
			_subchunkID = -1;
			_subchunkSize = -1;
			_audioFormat = -1;
			_numOfChannels = -1;
			_numOfBytesInTheDataPart = -1;
			_numOfSamples = -1;
			_bitsPerSample = -1;
			_subchunk2ID = -1;
			_hostFileInBytes = null;
			_fileData = null;
			_songLengthInSeconds = -1;
		}

		/// <summary>
		/// Pos: [0-4):4B
		/// </summary>
		public int ChunkID
		{
			get => _chunkID;
			set => _chunkID = value;
		}
		/// <summary>
		/// Pos: [4-8):4B
		/// </summary>
		public int ChunkSize
		{
			get => _chunkSize;
			set => _chunkSize = value;
		}
		/// <summary>
		/// Pos: [8-12):4B
		/// </summary>
		public int Format
		{
			get => _format;
			set => _format = value;
		}
		/// <summary>
		/// Pos: [12-16):4B
		/// </summary>
		public int SubchunkID
		{
			get => _subchunkID;
			set => _subchunkID = value;
		}
		/// <summary>
		/// Pos: [16-20):4B
		/// </summary>
		public int SubchunkSize
		{
			get => _subchunkSize;
			set => _subchunkSize = value;
		}
		/// <summary>
		/// Pos: [20-22):2B
		/// </summary>
		public short AudioFormat
		{
			get => _audioFormat;
			set => _audioFormat = value;
		}
		/// <summary>
		/// Pos: [22-24):2B
		/// </summary>
		public short NumOfChannels
		{
			get => _numOfChannels;
			set => _numOfChannels = value;
		}
		/// <summary>
		/// Pos: [24-28):4B
		/// </summary>
		public int SampleRate { get => _sampleRate; set => _sampleRate = value; }
		/// <summary>
		/// Pos: [28-32):4B
		/// </summary>
		public int ByteRate { get => _byteRate; set => _byteRate = value; }
		/// <summary>
		/// Pos: [32-34):2B
		/// </summary>
		public short BlockAlign { get => _blockAlign; set => _blockAlign = value; }
		/// <summary>
		/// Pos: [34-36):2B
		/// </summary>
		public short BitsPerSample
		{
			get => _bitsPerSample;
			set => _bitsPerSample = value;
		}
		/// <summary>
		/// Pos: [36-40): 4B
		/// </summary>
		public int Subchunk2ID
		{
			get => _subchunk2ID;
			set => _subchunk2ID = value;
		}
		/// <summary>
		/// Pos: [40-44):4B
		/// </summary>
		public int NumOfBytesInTheDataPart
		{
			get => _numOfBytesInTheDataPart;
			set => _numOfBytesInTheDataPart = value;
		}
		public byte[] HostFileInBytes
		{
			get => _hostFileInBytes;
			set => _hostFileInBytes = value;
		}
		public byte[] FileData { get => _fileData; set => _fileData = value; }
		public int NumOfSamples
		{
			get => _numOfSamples;
			set => _numOfSamples = value;
		}
		public int SongLengthInSeconds
		{
			get => _songLengthInSeconds;
			set => _songLengthInSeconds = value;
		}

		/// <summary>
		/// Gets the wave data, number of bytes in the data and number of bytes
		/// per sample.
		/// </summary>
		public void PopulateWaveFileModel()
		{
			int offset = 0;
			this.ChunkID =
				BitConverter.ToInt32(this.HostFileInBytes, offset);

			offset = 4;
			this.ChunkSize =
				BitConverter.ToInt32(this.HostFileInBytes, offset);

			offset = 8;
			this.Format =
				BitConverter.ToInt32(this.HostFileInBytes, offset);

			offset = 12;
			this.SubchunkID =
				BitConverter.ToInt32(this.HostFileInBytes, offset);

			offset = 16;
			this.SubchunkSize =
				BitConverter.ToInt32(this.HostFileInBytes, offset);

			offset = 20;
			this.AudioFormat =
				BitConverter.ToInt16(this.HostFileInBytes, offset);

			// 1. Get number of channels:
			offset = 22;
			this.NumOfChannels =
				BitConverter.ToInt16(this.HostFileInBytes, offset);

			// 2. Get sample rate:
			offset = 24;
			this.SampleRate =
				BitConverter.ToInt32(this.HostFileInBytes, offset);

			// 3. Get byte rate:
			offset = 28;
			this.ByteRate =
				BitConverter.ToInt32(this.HostFileInBytes, offset);

			// 4. Get number of bytes per sample:
			offset = 32;
			this.BlockAlign =
				BitConverter.ToInt16(this.HostFileInBytes, offset);

			// 5. Get bit per sample:
			offset = 34;
			this.BitsPerSample =
				BitConverter.ToInt16(this.HostFileInBytes, offset);

			// 6. Get subchunk 2 id:
			offset = 36;
			this.Subchunk2ID =
				BitConverter.ToInt32(this.HostFileInBytes, offset);

			// 7. Get number of bytes in the fileData:
			offset = 44;
			this.NumOfBytesInTheDataPart = this.HostFileInBytes.Length - offset; // TODO: Proveri ovo!
				//BitConverter.ToInt32(this.HostFileInBytes, offset);

			// 8. Get the fileData:
			this.FileData = new byte[this.HostFileInBytes.Length - offset];
			for (int i = offset, k = 0; k < this.HostFileInBytes.Length - offset;
				i++, k++)
			{
				this.FileData[k] = this.HostFileInBytes[i];
			}

			// 9. Get total number of samples:
			this.NumOfSamples =
				this.NumOfBytesInTheDataPart / this.BlockAlign;

			// 10. Get song length in seconds:
			this.SongLengthInSeconds = this.NumOfSamples /
				this.SampleRate;
		}
	}
}
