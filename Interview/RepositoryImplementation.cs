using Interview.Objects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.Repositories
{
	public class RepositoryImplementation<T> : IRepository<T> where T : IStoreable
	{
		private SortedDictionary<IComparable, T> _objects = new SortedDictionary<IComparable, T>();

		public IEnumerable<T> All()
		{
			return _objects.Values.AsEnumerable();
		}

		public void Delete(IComparable id)
		{
			_objects.Remove(id);
		}

		public T FindById(IComparable id)
		{
			
			if(!_objects.ContainsKey(id))
			{
				throw new ArgumentException();
			}

			_objects.TryGetValue(id, out T newObject);

			return newObject;
		}

		public void Save(T item)
		{
			_objects.Add(item.Id, item);
		}
	}
}
