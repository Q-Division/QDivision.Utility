using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace QDivision.Utility.UnitTests
{
	[TestFixture]
	public class CheckParameterTest
	{
		#region ObjectParameter Tests
		/// <summary>
		/// Checks a Valid Object
		/// Simple check that it does not throw an exception
		/// </summary>
		[Test]
		public void CheckObjectParameterValid()
		{
			//Execute
			CheckParameter.ObjectParameter("objname", new Object());
		}

		/// <summary>
		/// Checks a null Object with a name starting with a vowel
		/// </summary>
		[Test]
		public void CheckObjectParameterNullVowel()
		{
			var message = "An obj is required"
			              + Environment.NewLine + "Parameter name: obj";

			Assert.That(() => CheckParameter.ObjectParameter("obj", null),
				Throws.ArgumentNullException.With.Message.EqualTo(message));
		}

		/// <summary>
		/// Checks a null Object with a name starting with a consonant
		/// </summary>
		[Test]
		public void CheckObjectParameterNullConsonant()
		{
			var message = "A someobj is required"
			              + Environment.NewLine + "Parameter name: someobj";

			Assert.That(() => CheckParameter.ObjectParameter("someobj", null),
				Throws.ArgumentNullException.With.Message.EqualTo(message));
		}
		#endregion

		#region StringParameter Tests
		/// <summary>
		/// Checks a Valid string
		/// Simple check that it does not throw an exception
		/// </summary>
		[Test]
		public void CheckStringParameterValid()
		{
			//Execute
			CheckParameter.StringParameter("str", "somestring");
		}

		/// <summary>
		/// Checks a null string with a name starting with a vowel
		/// </summary>
		[Test]
		public void CheckStringParameterNullVowel()
		{
			var message = "An astring is required"
			              + Environment.NewLine + "Parameter name: astring";

			Assert.That(() => CheckParameter.StringParameter("astring", null),
				Throws.ArgumentNullException.With.Message.EqualTo(message));
		}

		/// <summary>
		/// Checks an empty string with a name starting with a vowel
		/// </summary>
		[Test]
		public void CheckStringParameterEmptyVowel()
		{
			var message = "An astring is required (is empty)"
			              + Environment.NewLine + "Parameter name: astring";

			Assert.That(() => CheckParameter.StringParameter("astring", ""),
				Throws.ArgumentException.With.Message.EqualTo(message));
		}


		/// <summary>
		/// Checks a null string with a name starting with a consonant
		/// </summary>
		[Test]
		public void CheckStringParameterNullConsonant()
		{
			var message = "A str is required"
			              + Environment.NewLine + "Parameter name: str";

			Assert.That(() => CheckParameter.StringParameter("str", null),
				Throws.ArgumentNullException.With.Message.EqualTo(message));
		}

		/// <summary>
		/// Checks an empty string with a name starting with a consonant
		/// </summary>
		[Test]
		public void CheckStringParameterEmptyConsonant()
		{
			var message = "A str is required (is empty)"
			              + Environment.NewLine + "Parameter name: str";

			Assert.That(() => CheckParameter.StringParameter("str", ""),
				Throws.ArgumentException.With.Message.EqualTo(message));
		}
		#endregion
	}
}
