using System;

namespace QDivision.Utility.Collections
{
	public class OnChangeEventArgs<T> : EventArgs
	{
		public T Changed { get; private set; }
		public ChangeEventType Type { get; private set; }

		public OnChangeEventArgs(T changed, ChangeEventType type)
		{
			Changed = changed;
			Type = type;
		}
	}
}
