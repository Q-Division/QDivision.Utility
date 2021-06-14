using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace QDivision.Utility.Collections
{
	public class EventedList<T> : IList<T>, INotifyCollectionChanged
	{
		protected List<T> mList; 

		#region Event Handlers
		public delegate void OnAddEventHandler(object sender, OnAddEventArgs<T> args);
		#endregion

		#region Events
		public event OnAddEventHandler OnAdd;
		public event NotifyCollectionChangedEventHandler CollectionChanged;
		#endregion

		public EventedList()
		{
			mList = new List<T>();
		}

		public virtual void Add(T item)
		{
			mList.Add(item);

			if (OnAdd != null)
			{
				OnAdd(this, new OnAddEventArgs<T>(item));
			}

			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
		}

		public int IndexOf(T item)
		{
			return mList.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			mList.Insert(index, item);
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
		}

		public void RemoveAt(int index)
		{
			var item = mList[index];
			mList.RemoveAt(index);
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
		}

		public T this[int index]
		{
			get { return mList[index]; }
			set { mList[index] = value; }
		}

		public void Clear()
		{
			mList.Clear();
		}

		public bool Contains(T item)
		{
			return mList.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			mList.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return mList.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(T item)
		{
			var removed = mList.Remove(item);

			if (removed)
			{
				CollectionChanged?.Invoke(this,
					new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
			}

			return removed;
		}

		public List<T>.Enumerator GetEnumerator()
		{
			return mList.GetEnumerator();
		}

		public T Find(Predicate<T> match)
		{
			return mList.Find(match);
		}

		public void Sort(IComparer<T> comparer)
		{
			mList.Sort(comparer);
		}


		#region IEnumerable / IEnumerable<T> Methods	
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return mList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return mList.GetEnumerator();
		}
		#endregion
	}
}
