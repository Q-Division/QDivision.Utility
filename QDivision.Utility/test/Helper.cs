using System;
using System.Collections.Generic;
using System.Text;

namespace QDivision.Utility.UnitTests
{
	public static class Helper
	{
		/// <summary>
		/// Build exception message based on DotNetCore 3.1+ or otherwise
		/// </summary>
		/// <param name="suppliedmessage">Message supplied to exception</param>
		/// <param name="paramname">Name of parameter that triggered exception</param>
		/// <returns>Message that comes out of exception</returns>
		public static string BuildExceptionMessage(string suppliedmessage, string paramname)
		{
			#if NETCOREAPP
			var message = $"{suppliedmessage} (Parameter '{paramname}')";
			#else
			var message = $"{suppliedmessage}{Environment.NewLine}Parameter name: {paramname}";
			#endif

			return message;
		}
	}
}
