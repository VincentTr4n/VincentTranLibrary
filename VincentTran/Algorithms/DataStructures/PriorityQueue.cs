using System;

namespace VincentTran.Algorithms.DataStructures
{
	public class PriorityQueue<T> where T : IComparable<T>
	{
		private readonly T[] _data;
		public int Count { get; private set; }

		public PriorityQueue(int capacity)
		{
			_data = new T[capacity + 1];
		}

		public PriorityQueue(System.Collections.Generic.ICollection<T> data)
		{
			_data = new T[data.Count + 1];
			foreach (var item in data) Push(item);
		}

		public void Push(T elem)
		{
			if (Count + 1 == _data.Length) throw new InvalidOperationException("Queue overflow");
			_data[++Count] = elem;
			Up(Count);
		}

		/// <summary>
		/// Remove and Return the smallest element
		/// </summary>
		public T PopMin()
		{
			if (Count == 0) throw new InvalidOperationException("Queue underflow");
			T res = _data[1];
			_data[1] = _data[Count--];
			Down(1);
			return res;
		}

		public T PeekMin()
		{
			if (Count == 0) throw new InvalidOperationException("Queue underflow");
			return _data[1];
		}

		private void Down(int u)
		{
			int l = 2 * u, r = l + 1, m = u;
			if (l <= Count && _data[m].CompareTo(_data[l]) > 0) m = l;
			if (r <= Count && _data[m].CompareTo(_data[r]) > 0) m = r;
			if (m != u)
			{
				T temp = _data[u];
				_data[u] = _data[m];
				_data[m] = temp;
				Down(m);
			}
		}

		private void Up(int u)
		{
			if (u > 1)
			{
				int p = u / 2;
				if (_data[p].CompareTo(_data[u]) > 0)
				{
					T temp = _data[u];
					_data[u] = _data[p];
					_data[p] = temp;
					Up(p);
				}
			}
		}
	}
}
