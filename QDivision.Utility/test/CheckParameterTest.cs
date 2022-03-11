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
			var message = Helper.BuildExceptionMessage("An obj is required", "obj");

			Assert.That(() => CheckParameter.ObjectParameter("obj", null),
				Throws.ArgumentNullException.With.Message.EqualTo(message));
		}

		/// <summary>
		/// Checks a null Object with a name starting with a consonant
		/// </summary>
		[Test]
		public void CheckObjectParameterNullConsonant()
		{
			var message = Helper.BuildExceptionMessage("A someobj is required", "someobj");

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
			var message = Helper.BuildExceptionMessage("An astring is required", "astring");

			Assert.That(() => CheckParameter.StringParameter("astring", null),
				Throws.ArgumentNullException.With.Message.EqualTo(message));
		}

		/// <summary>
		/// Checks an empty string with a name starting with a vowel
		/// </summary>
		[Test]
		public void CheckStringParameterEmptyVowel()
		{
			var message = Helper.BuildExceptionMessage("An astring is required (is empty)", "astring");

			Assert.That(() => CheckParameter.StringParameter("astring", ""),
				Throws.ArgumentException.With.Message.EqualTo(message));
		}


		/// <summary>
		/// Checks a null string with a name starting with a consonant
		/// </summary>
		[Test]
		public void CheckStringParameterNullConsonant()
		{
			var message = Helper.BuildExceptionMessage("A str is required", "str");

			Assert.That(() => CheckParameter.StringParameter("str", null),
				Throws.ArgumentNullException.With.Message.EqualTo(message));
		}

		/// <summary>
		/// Checks an empty string with a name starting with a consonant
		/// </summary>
		[Test]
		public void CheckStringParameterEmptyConsonant()
		{
			var message = Helper.BuildExceptionMessage("A str is required (is empty)", "str");

			Assert.That(() => CheckParameter.StringParameter("str", ""),
				Throws.ArgumentException.With.Message.EqualTo(message));
		}
		#endregion
	}
}
