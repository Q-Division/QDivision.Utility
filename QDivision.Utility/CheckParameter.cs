using System;
using System.Collections.Generic;
using System.Text;
using QDivision.Utility.Extensions;

namespace QDivision.Utility
{
	/// <summary>
	/// CheckParameter
	/// Helper class for checking "validity" of parameters.
	/// </summary>
	public static class CheckParameter
	{
		/// <summary>
		/// Method for checking if an object is not null.
		/// If null throws ArgumentNullException
		/// </summary>
		/// <param name="paramname">Name of Parameter</param>
		/// <param name="obj">Object</param>
		public static void ObjectParameter(string paramname, object obj)
		{
			if (obj == null)
			{
				string message;

				if (paramname[0].IsAVowel())
				{
					message = "An " + paramname + " is required";
				}
				else
				{
					message = "A " + paramname + " is required";
				}

				throw new ArgumentNullException(paramname, message);
			}
		}

		/// <summary>
		/// Mthod for checking a string is set and is value.
		/// Checks for Null or Empty, if found throws ArgumentException
		/// </summary>
		/// <param name="paramname">Name of Parameter</param>
		/// <param name="value">Value</param>
		public static void StringParameter(string paramname, string value)
		{
			ObjectParameter(paramname, value);

			if (String.IsNullOrEmpty(value))
			{
				string message;

				if (paramname[0].IsAVowel())
				{
					message = "An " + paramname + " is required (is empty)";
				}
				else
				{
					message = "A " + paramname + " is required (is empty)";
				}

				throw new ArgumentException(message, paramname);
			}
		}
	}
}
