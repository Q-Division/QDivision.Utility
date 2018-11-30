using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace QDivision.Utility.Compression
{
	/// <summary>
	/// Compresses/Decompresses strings using Deflate
	/// </summary>
	public class DeflateStringCompressionService : IStringCompressionService
	{
		/// <summary>
		/// Compresses a string
		/// </summary>
		/// <param name="str">String to compress</param>
		/// <returns>byte[] containg compressed string</returns>
		public byte[] Compress(string str)
		{
			MemoryStream ms = new MemoryStream();

			using (DeflateStream deflate = new DeflateStream(ms, CompressionMode.Compress))
			{
				using (StreamWriter writer = new StreamWriter(deflate))
				{
					writer.Write(str);
				}
			}

			return ms.ToArray();
		}

		/// <summary>
		/// Decompresses a compressed string
		/// </summary>
		/// <param name="data">byte[] containg compressed string</param>
		/// <returns>Decompressed string</returns>
		public string Decompress(byte[] data)
		{
			string str;

			MemoryStream ms = new MemoryStream();
			ms.Write(data, 0, data.Length);
			ms.Position = 0;

			using (DeflateStream deflate = new DeflateStream(ms, CompressionMode.Decompress))
			{
				using (StreamReader reader = new StreamReader(deflate))
				{
					str = reader.ReadToEnd();
				}
			}

			return str;
		}
	}
}
