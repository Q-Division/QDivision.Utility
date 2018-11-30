using System;
using System.Collections.Generic;
using System.Text;

namespace QDivision.Utility.Compression
{
	/// <summary>
	/// Compresses/Decompresses strings
	/// </summary>
	public interface IStringCompressionService
	{
		/// <summary>
		/// Compresses a string
		/// </summary>
		/// <param name="str">String to compress</param>
		/// <returns>byte[] containg compressed string</returns>
		byte[] Compress(string str);

		/// <summary>
		/// Decompresses a compressed string
		/// </summary>
		/// <param name="data">byte[] containg compressed string</param>
		/// <returns>Decompressed string</returns>
		string Decompress(byte[] data);
	}
}
