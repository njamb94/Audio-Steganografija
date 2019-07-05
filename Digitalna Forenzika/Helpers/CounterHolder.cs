using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalna_Forenzika.Helpers
{
	public class CounterHolder
	{
		private double bitCounter;
		private int sampleByteCounter;
		private int bitByteCounter;
		private int sampleCounter;

		public CounterHolder()
		{
			bitCounter = 0;
			sampleCounter = 0;
			bitByteCounter = 0;
			sampleCounter = 0;
		}

		/// <summary>
		/// Number of bits traversed through OuterMsg.
		/// </summary>
		public double BitCounter { get => bitCounter; set => bitCounter = value; }
		/// <summary>
		/// Order of bytes in the sample. (Which byte of BlockAlign)
		/// </summary>
		public int SampleByteCounter
		{
			get => sampleByteCounter;
			set => sampleByteCounter = value;
		}
		/// <summary>
		/// Which bit of targeted byte we're changing.
		/// </summary>
		public int BitByteCounter
		{
			get => bitByteCounter;
			set => bitByteCounter = value;
		}
		/// <summary>
		/// Which sample we're using.
		/// </summary>
		public int SampleCounter
		{
			get => sampleCounter;
			set => sampleCounter = value;
		}
	}
}
