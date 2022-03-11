using System;
using System.Collections.Generic;
using System.Text;

namespace QDivision.Utility.Testing
{
	/// <summary>
	/// Builds exception messages for testing purposes
	/// </summary>
	public static class ExceptionMessageBuilder
	{
		/// <summary>
		/// Build ArgumentException message based on DotNetCore 3.1+ or otherwise
		/// </summary>
		/// <param name="suppliedmessage">Message supplied to exception</param>
		/// <param name="paramname">Name of parameter that triggered exception</param>
		/// <returns>Message that comes out of exception</returns>
		public static string BuildArgumentExceptionMessage(string suppliedmessage, string paramname)
		{
			return BuildArgumentExceptionMessageInternal(suppliedmessage, paramname);
		}

		/// <summary>
		/// Build ArgumentNullException message based on DotNetCore 3.1+ or otherwise
		/// </summary>
		/// <param name="suppliedmessage">Message supplied to exception</param>
		/// <param name="paramname">Name of parameter that triggered exception</param>
		/// <returns>Message that comes out of exception</returns>
		public static string BuildArgumentNullExceptionMessage(string suppliedmessage, string paramname)
		{
			return BuildArgumentExceptionMessageInternal(suppliedmessage, paramname);
		}

		#region Internal Methods
		private static string BuildArgumentExceptionMessageInternal(string suppliedmessage, string paramname)
		{
			#if NETCOREAPP
				var message = $"{suppliedmessage} (Parameter '{paramname}')";
			#else
				var message = $"{suppliedmessage}{Environment.NewLine}Parameter name: {paramname}";
			#endif

			return message;

		}
		#endregion
	}
}
