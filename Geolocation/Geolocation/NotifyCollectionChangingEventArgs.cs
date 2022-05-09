using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	public class NotifyCollectionChangingEventArgs<T> : EventArgs
	{
		public NotifyCollectionChangingEventArgs(T item)
		{
			this.Item = item;
			this.Cancel = false;
		}

		public T Item { get; set; }
		public bool Cancel { get; set; }
	}
}
