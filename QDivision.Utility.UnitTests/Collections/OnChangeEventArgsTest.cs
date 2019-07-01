using NUnit.Framework;
using QDivision.Utility.Collections;

namespace QDivision.Utility.UnitTests.Collections
{
	[TestFixture]
	public class OnChangeEventArgsTest
	{
		[Test]
		public void CreateOnChangeEventArgs()
		{
			string expectedarg = "HelloWorld";

			//Run Test
			OnChangeEventArgs<string> result = new OnChangeEventArgs<string>(expectedarg, ChangeEventType.Enqueue);

			//Check Results
			Assert.That(result.Changed, Is.EqualTo(expectedarg), "Changed");
			Assert.That(result.Type, Is.EqualTo(ChangeEventType.Enqueue));
		}
	}
}
