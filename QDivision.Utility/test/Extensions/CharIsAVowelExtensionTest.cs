using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using QDivision.Utility.Extensions;

namespace QDivision.Utility.UnitTests.Extensions
{
	/// <summary>
	/// CharIsAVowelExtensionTest
	/// Tests for the CharIsAVowelExtension
	/// </summary>
	[TestFixture]
	public class CharIsAVowelExtensionTest
	{
		/// <summary>
		/// Checks all 26 characters in the alphabet in upper and lower case
		/// </summary>
		[Test]
		public void IsAVowel()
		{
			List<char> vowels = new List<char> {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
			List<char> characters = new List<char>(46);

			//Lower Case
			for (char c = 'a'; c <= 'z'; c++)
			{
				characters.Add(c);
			}

			//Lower Case
			for (char c = 'A'; c <= 'Z'; c++)
			{
				characters.Add(c);
			}

			//Check
			foreach (var c in characters)
			{
				bool result = c.IsAVowel();

				if (vowels.Contains(c))
				{
					Assert.That(result, Is.True, c.ToString);
				}
				else
				{
					Assert.That(result, Is.False, c.ToString);
				}
			}
		}
	}
}
