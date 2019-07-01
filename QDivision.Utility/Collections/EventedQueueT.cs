using System.Collections.Generic;

namespace QDivision.Utility.Collections
{
	public class EventedQueue<T> : Queue<T>
	{
		#region Event Handlers
		public delegate void OnChangeEventHandler(object sender, OnChangeEventArgs<T> args);
		#endregion

		#region Events
		public event OnChangeEventHandler OnChange;
		#endregion

		public new virtual void Enqueue(T item)
		{
			base.Enqueue(item);

			if (OnChange != null)
			{
				OnChange(this, new OnChangeEventArgs<T>(item, ChangeEventType.Enqueue));
			}
		}

		public new virtual T Dequeue()
		{
			T item = base.Dequeue();
			if (OnChange != null)
			{
				OnChange(this, new OnChangeEventArgs<T>(item, ChangeEventType.Dequeue));
			}
			return item;
		}
	}
}
