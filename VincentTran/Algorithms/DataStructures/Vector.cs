using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VincentTran.Algorithms.DataStructures
{
	public class Vector<T> : ICollection<T>,IComparable<Vector<T>> where T : IComparable<T>
	{
		private int _capacity;
		private int _count;
		private T[] _data;

		public Vector() : this(0) { }
		public Vector(int size) : this(new T[size]) { }
		public Vector(ICollection<T> collection)
		{
			int capactity = 1;
			while (capactity < collection.Count) capactity *= 2;
			_count = collection.Count;
			_capacity = capactity;
			_data = new T[_capacity];
			int index = 0;
			foreach (var item in collection)
			{
				_data[index++] = item;
			}
		}

		public int Count => _count;
		public bool IsReadOnly => _data.IsReadOnly;
		public int Capactity { get { return _capacity; } set { _capacity = value; } }

		public void Add(T item)
		{
			if (++_count >= _capacity)
			{
				_capacity *= 2;
				var temp = _data;
				_data = new T[_capacity];
				Array.Copy(temp, _data, temp.Length);
			}
			_data[_count - 1] = item;
		}
		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
				return _data[index];
			}
			set
			{
				if (index < 0) throw new IndexOutOfRangeException();
				if (index < _capacity)
				{
					_data[index] = value;
					_count = index < _count ? _count : _count + 1;
					return;
				}
				while (index >= _capacity) _capacity *= 2;
				var temp = _data;
				_data = new T[_capacity];
				Array.Copy(temp, _data, temp.Length);
				_data[index] = value;
				_count = index + 1;
			}
		}
		public void Clear()
		{
			_capacity = 1;
			_data = new T[1];
			_count = 0;
		}

		public void Sort() => SortAlgo<T>.MergeSort(_data, 0, _count - 1, (a, b) => a.CompareTo(b));
		public int BinarySearch(T item) => _binarySearch(_data, item);

		public bool Contains(T item) => _binarySearch(_data, item) >= 0;

		public void CopyTo(T[] array, int arrayIndex)
		{
			array = new T[arrayIndex + _count];
			for (int i = 0; i < array.Length; i++)
			{
				array[arrayIndex + i] = _data[i];
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			T[] res = new T[_count];
			Array.Copy(_data, res, _count);
			return res.AsEnumerable().GetEnumerator();
		}

		public bool Remove(T item)
		{
			int index = _binarySearch(_data, item);
			if (index < 0) return false;
			for (int i = index; i < _count - 1; i++)
			{
				_data[i] = _data[i + 1];
			}
			_count--;
			if (_capacity / 2 > _count) _capacity = _capacity / 2 == 0 ? 1 : _capacity / 2;
			return true;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		int _binarySearch(T[] array, T item)
		{
			int i = 0, j = _count - 1;
			List<P> mlist = new List<P>();
			for (int ii = 0; ii < _count; ii++)
			{
				P p = new P() { Value = _data[ii], Index = ii };
				mlist.Add(p);
			}

			var temp = mlist.ToArray();
			SortAlgo<P>.QuickSort(temp);
			P value = new P() { Value = item, Index = -1 };

			while (i <= j)
			{
				int M = (i + j) / 2;
				int compare = temp[M].CompareTo(value);
				if (compare == 0) return temp[M].Index;
				else if (compare > 0) j = M - 1;
				else i = M + 1;
			}
			return -1;
		}

		public int CompareTo(Vector<T> other) => _count.CompareTo(other._count);

		class P : IComparable<P>
		{
			public T Value { get; set; }
			public int Index { get; set; }
			public int CompareTo(P other) => Value.CompareTo(other.Value);
		}
	}
}
