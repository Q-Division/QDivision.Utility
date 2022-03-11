using NUnit.Framework;
using QDivision.Utility.Collections;

namespace QDivision.Utility.UnitTests.Collections
{
	[TestFixture]
	public class OnAddEventArgsTest
	{
		[Test]
		public void CreateOnAddEventArgs()
		{
			string expectedarg = "HelloWorld";

			//Run Test
			OnAddEventArgs<string> result = new OnAddEventArgs<string>(expectedarg);

			//Check Results
			Assert.That(result.Added, Is.EqualTo(expectedarg), "Added");
		}
	}
}
