using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using QDivision.Utility.Compression;

namespace QDivision.Utility.UnitTests.Compression
{
	[TestFixture]
	public class DeflateStringCompressionServiceTest
	{
		private readonly IStringCompressionService mCompressor;

		public DeflateStringCompressionServiceTest()
		{
			mCompressor = new DeflateStringCompressionService();
		}

		[Test]
		public void Compress()
		{
			//Setup
			var str = "Something to compress";
			var expecteddata1 = new byte[] { 10, 206, 207, 77, 45, 201, 200, 204, 75, 87, 40, 201, 87, 72, 206, 207, 45, 40, 74, 45, 46, 6, 0, 0, 0, 255, 255, 3, 0 };
			var expecteddata2 = new byte[]
				{11, 206, 207, 77, 45, 201, 200, 204, 75, 87, 40, 201, 87, 72, 206, 207, 45, 40, 74, 45, 46, 6, 0};

			//Run
			var data = mCompressor.Compress(str);

			//Check
			if (data[0] == 11)
			{
				//NET Framework 4.5
				Assert.That(data, Is.EqualTo(expecteddata2));
			}
			else
			{
				//NET Standard 2.0
				Assert.That(data, Is.EqualTo(expecteddata1));
			}
		}

		/// <summary>
		/// Variant 1 (NET Standard 2.0 Compression)
		/// </summary>
		[Test]
		public void Decompress_Variant1()
		{
			//Setup
			var data = new byte[] { 10, 206, 207, 77, 45, 201, 200, 204, 75, 87, 40, 201, 87, 72, 206, 207, 45, 40, 74, 45, 46, 6, 0, 0, 0, 255, 255, 3, 0 };
			var expectedstr = "Something to compress";

			//Run
			var str = mCompressor.Decompress(data);

			//Check
			Assert.That(str, Is.EqualTo(expectedstr));
		}

		/// <summary>
		/// Variant 2 (NET Framework 4.5 Compression)
		/// </summary>
		[Test]
		public void Decompress_Variant2()
		{
			//Setup
			var data = new byte[] { 11, 206, 207, 77, 45, 201, 200, 204, 75, 87, 40, 201, 87, 72, 206, 207, 45, 40, 74, 45, 46, 6, 0 };
			var expectedstr = "Something to compress";

			//Run
			var str = mCompressor.Decompress(data);

			//Check
			Assert.That(str, Is.EqualTo(expectedstr));
		}
	}
}
