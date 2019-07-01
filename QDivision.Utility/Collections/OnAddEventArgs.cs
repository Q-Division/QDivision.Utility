using System;

namespace QDivision.Utility.Collections
{
	public class OnAddEventArgs<T> : EventArgs
	{
		public T Added { get; private set; }

		public OnAddEventArgs(T added)
		{
			Added = added;
		}
	}
}
