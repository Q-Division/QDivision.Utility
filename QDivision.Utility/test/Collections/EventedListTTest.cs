using System;
using System.Collections.Specialized;
using NUnit.Framework;
using QDivision.Utility.Collections;

namespace QDivision.Utility.UnitTests.Collections
{
	[TestFixture]
	public class EventedListTTest
	{
		private bool mOnAddEventTriggered;
		private bool mCollectionChangedEventTriggered;
		private NotifyCollectionChangedAction mCollectionChangedEventAction;

		//Test with OnAdd Not Registered For
		[Test]
		public void AddWithoutEvent()
		{
			//Setup Test
			string element = "HelloWorld";

			EventedList<string> list = new EventedList<string>();

			//Run Test
			list.Add(element);

			//Check Results
			Assert.That(list.Count, Is.EqualTo(1), "Contains Element");
			Assert.That(list.Contains(element), "Contains Element");
		}

		//Test with OnAdd Registered For
		[Test]
		public void AddWithEvent()
		{
			//Setup Test
			string element = "HelloWorld";
			mOnAddEventTriggered = false;

			EventedList<string> list = new EventedList<string>();
			list.OnAdd += new EventedList<string>.OnAddEventHandler(list_OnAdd);

			//Run Test
			list.Add(element);

			//Check Results
			Assert.That(list.Contains(element), "Contains Element");
			Assert.That(mOnAddEventTriggered, Is.True, "Event Triggered");
		}

		//Test with CollectionChanged Registered For
		[Test]
		public void AddWithCollectionChanged()
		{
			//Setup Test
			string element = "HelloWorld";
			mCollectionChangedEventTriggered = false;

			EventedList<string> list = new EventedList<string>();
			list.CollectionChanged += List_CollectionChanged;

			//Run Test
			list.Add(element);

			//Check Results
			Assert.That(list.Contains(element), "Contains Element");
			Assert.That(mCollectionChangedEventTriggered, Is.True, "Event Triggered");
			Assert.That(mCollectionChangedEventAction, Is.EqualTo(NotifyCollectionChangedAction.Add), "Event Action");
		}

		[Test]
		public void IsReadOnly()
		{
			//Setup
			EventedList<string> list = new EventedList<string>();

			//Run / Check
			Assert.That(list.IsReadOnly, Is.False);
		}

		[Test]
		public void IndexOfSecondItem()
		{
			//Setup Test
			EventedList<int> list = new EventedList<int> {1, 2};

			//Run Test
			var index = list.IndexOf(2);

			//Check Results
			Assert.That(index, Is.EqualTo(1));
		}

		[Test]
		public void GetEnumerator()
		{
			//Setup Test
			EventedList<int> list = new EventedList<int>();

			//Run Test
			var enumerator = list.GetEnumerator();

			//Check Results
			Assert.That(enumerator, Is.Not.Null);
		}

		[Test]
		public void GetSecondItem()
		{
			//Setup Test
			EventedList<int> list = new EventedList<int> {1, 2};

			//Run Test
			var index = list[1];

			//Check Results
			Assert.That(index, Is.EqualTo(2));
		}

		[Test]
		public void SetSecondItem()
		{
			//Setup Test
			EventedList<int> list = new EventedList<int> {1, 2};

			//Run Test
			list[1] = 3;

			//Check Results
			Assert.That(list[1], Is.EqualTo(3));
		}

		[Test]
		public void Remove3()
		{
			//Setup Test
			EventedList<int> list = new EventedList<int>
			{
				1,
				2,
				3,
				4,
				5
			};

			//Run Test
			list.Remove(3);

			//Check Results
			Assert.That(list.Count, Is.EqualTo(4), "Count");
			Assert.That(list.Contains(3), Is.False, "Does Not Contain Element");
		}

		[Test]
		public void RemoveAt2()
		{
			//Setup Test
			EventedList<char> list = new EventedList<char>
			{
				'a',
				'b',
				'c',
				'd',
				'e'
			};

			//Run Test
			list.RemoveAt(2);

			//Check Results
			Assert.That(list.Count, Is.EqualTo(4), "Count");
			Assert.That(list.Contains('c'), Is.False, "Does Not Contain Element");
		}

		[Test]
		public void Insert2()
		{
			//Setup Test
			EventedList<char> list = new EventedList<char> {'a', 'b', 'c', 'd'};

			//Run Test
			list.Insert(2, 'e');

			//Check Results
			Assert.That(list.Count, Is.EqualTo(5), "Count");
			Assert.That(list[2], Is.EqualTo('e'), "Inserted value check");
		}

		[Test]
		public void Clear()
		{
			//Setup Test
			EventedList<char> list = new EventedList<char> {'a', 'b'};

			//Run Test
			list.Clear();

			//Check Results
			Assert.That(list.Count, Is.Zero);
		}

		[Test]
		public void Sort()
		{
			//Setup Test
			EventedList<string> list = new EventedList<string> {"world", "hello"};

			//Run Test
			list.Sort(StringComparer.InvariantCulture);

			//Check Results
			Assert.That(list[0], Is.EqualTo("hello"));
			Assert.That(list[1], Is.EqualTo("world"));
		}

		[Test]
		public void CopyTo()
		{
			//Setup Test
			EventedList<char> list = new EventedList<char> {'a', 'b'};
			var array = new char[4];

			//Run Test
			list.CopyTo(array, 1);

			//Check Results
			Assert.That(array[1], Is.EqualTo(list[0]));
			Assert.That(array[2], Is.EqualTo(list[1]));
		}

		[Test]
		public void Find()
		{
			//Setup Test
			EventedList<string> list = new EventedList<string>
			{
				"hello",
				"world"
			};

			//Run Test
			var match = list.Find(s => s.Contains("d"));

			//Check 
			Assert.That(match, Is.EqualTo(list[1]));
		}

		#region Events
		//On Add Event for AddWithEvent() Test
		private void list_OnAdd(object sender, OnAddEventArgs<string> args)
		{
			mOnAddEventTriggered = true;
		}

		private void List_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			mCollectionChangedEventTriggered = true;
			mCollectionChangedEventAction = args.Action;
		}
		#endregion
	}
}
