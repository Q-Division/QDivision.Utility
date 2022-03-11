using NUnit.Framework;
using QDivision.Utility.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDivision.Utility.UnitTests.Testing
{
	[TestFixture]
	public class ExceptionMessageBuilderTest
	{
		[Test]
		public void BuildArgumentExceptionMessage()
		{
			//Setup
			var message = "Some exception message";
			var paramname = "someparam";

			#if NETCOREAPP
				var expectedmessage = $"{message} (Parameter '{paramname}')";
			#else
				var expectedmessage = $"{message}{Environment.NewLine}Parameter name: {paramname}";
			#endif

			//Run
			var builtmessage = ExceptionMessageBuilder.BuildArgumentExceptionMessage(message, paramname);

			//Check
			Assert.That(builtmessage, Is.EqualTo(expectedmessage));
		}
	}
}
