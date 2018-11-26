using System;
using System.Collections.Generic;
using System.Text;

namespace QDivision.Utility.Extensions
{
	/// <summary>
	/// CharIsAVowelExtension
	/// Allows checking if a character is a vowel.
	/// </summary>
	public static class CharIsAVowelExtension
	{
		/// <summary>
		/// Checks if the character is a vowel.
		/// </summary>
		/// <param name="c">Character to check.</param>
		/// <returns>True is a vowel, False otherwise.</returns>
		public static bool IsAVowel(this char c)
		{
			if (Char.ToLower(c) == 'a')
			{
				return true;
			}
			if (Char.ToLower(c) == 'e')
			{
				return true;
			}
			if (Char.ToLower(c) == 'i')
			{
				return true;
			}
			if (Char.ToLower(c) == 'o')
			{
				return true;
			}
			if (Char.ToLower(c) == 'u')
			{
				return true;
			}

			return false;
		}
	}
}
