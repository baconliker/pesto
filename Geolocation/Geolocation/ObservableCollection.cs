using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	public class ObservableCollection<T> : System.Collections.ObjectModel.ObservableCollection<T>
	{
		public event EventHandler<NotifyCollectionChangingEventArgs<T>> CollectionChanging;

		public ObservableCollection()
			: base()
		{
		}

		public new void Add(T item)
		{
			NotifyCollectionChangingEventArgs<T> e = new NotifyCollectionChangingEventArgs<T>(item);

			OnCollectionChanging(e);

			if (!e.Cancel)
			{
				base.Add(item);
			}
		}

		protected void OnCollectionChanging(NotifyCollectionChangingEventArgs<T> e)
		{
			if (CollectionChanging != null)
			{
				CollectionChanging(this, e);
			}
		}
	}
}
