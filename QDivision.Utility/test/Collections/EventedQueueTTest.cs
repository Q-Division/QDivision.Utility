using NUnit.Framework;
using QDivision.Utility.Collections;

namespace QDivision.Utility.UnitTests.Collections
{
	[TestFixture]
	public class EventedQueueTTest
	{
		private bool mEventTriggered;
		private OnChangeEventArgs<string> mEventArgs;

		#region Enqueue
		/// <summary>
		/// Test Enqueue with OnChange Not Registered For
		/// </summary>
		[Test]
		public void EnqueueWithoutEvent()
		{
			//Setup Test
			string element = "HelloWorld";

			EventedQueue<string> queue = new EventedQueue<string>();

			//Run Test
			queue.Enqueue(element);

			//Check Results
			Assert.That(queue.Contains(element), "Contains Element");
		}

		/// <summary>
		/// Test Enqueue with OnChange Registered For
		/// </summary>
		[Test]
		public void EnqueueWithEvent()
		{
			//Setup Test
			string element = "HelloWorld";
			//Set Default Event Args (used to check for changes)
			mEventArgs = new OnChangeEventArgs<string>("Default", ChangeEventType.Dequeue);
			mEventTriggered = false;

			EventedQueue<string> queue = new EventedQueue<string>();
			queue.OnChange += queue_OnChange;

			//Run Test
			queue.Enqueue(element);

			//Check Results
			Assert.That(queue.Contains(element), "Contains Element");
			Assert.That(mEventTriggered, Is.True, "Event Triggered");
			Assert.That(mEventArgs.Changed, Is.EqualTo(element), "Changed Object");
			Assert.That(mEventArgs.Type, Is.EqualTo(ChangeEventType.Enqueue), "Change Event Type");
		}
		#endregion

		#region Dequeue
		/// <summary>
		/// Test Dequeue with OnChange Not Registered For
		/// </summary>
		[Test]
		public void DequeueWithoutEvent()
		{
			//Setup Test
			string element = "HelloWorld";

			EventedQueue<string> queue = new EventedQueue<string>();
			queue.Enqueue(element);

			//Run Test
			queue.Dequeue();

			//Check Results
			Assert.That(!queue.Contains(element), "Does Not Contains Element");
		}

		/// <summary>
		/// Test Dequeue with OnChange Registered For
		/// </summary>
		[Test]
		public void DequeueWithEvent()
		{
			//Setup Test
			string element = "HelloWorld";
			//Set Default Event Args (used to check for changes)
			mEventArgs = new OnChangeEventArgs<string>("Default", ChangeEventType.Enqueue);
			mEventTriggered = false;

			EventedQueue<string> queue = new EventedQueue<string>();
			queue.OnChange += queue_OnChange;
			queue.Enqueue(element);

			//Run Test
			queue.Dequeue();

			//Check Results
			Assert.That(!queue.Contains(element), "Does Not Contains Element");
			Assert.That(mEventTriggered, Is.True, "Event Triggered");
			Assert.That(mEventArgs.Changed, Is.EqualTo(element), "Changed Object");
			Assert.That(mEventArgs.Type, Is.EqualTo(ChangeEventType.Dequeue), "Change Event Type");
		}
		#endregion

		//On Change Event for WithEvent() Tests
		private void queue_OnChange(object sender, OnChangeEventArgs<string> args)
		{
			mEventTriggered = true;
			mEventArgs = args;
		}
	}
}
