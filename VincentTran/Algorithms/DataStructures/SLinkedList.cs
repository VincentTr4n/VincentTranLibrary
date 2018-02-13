using System;
using System.Collections.Generic;

namespace VincentTran.Algorithms.DataStructures
{
	public class SLinkedList<T> where T : IComparable<T>
	{
		private int _size;
		private SlinkedNode<T> _header;
		private SlinkedNode<T> _trailer;

		public SLinkedList()
		{
			_size = 0;
			_header = _trailer = null;
		}

		public int Size => _size;
							
		public SlinkedNode<T> Header => _header;

		public SlinkedNode<T> Trailer => _trailer;

		public bool IsEmpty() => _size == 0;
		public void PushFont(T item)
		{
			SlinkedNode<T> node = new SlinkedNode<T>(item);
			if (_size == 0)
			{
				_header = node;
				_trailer = node;
			}
			else
			{
				node.Next = _header;
				_header = node;
			}
			_size++;
		}

		public void PushBack(T item)
		{
			SlinkedNode<T> node = new SlinkedNode<T>(item);
			if (_size == 0)
			{
				_header = node;
				_trailer = node;
			}
			else
			{
				_trailer.Next = node;
				_trailer = node;
			}
			_size++;
		}

		public void Insert(int index,T item)
		{
			if(index < 0 || index >=_size) throw new IndexOutOfRangeException();
			if (index == 0)
			{
				PushFont(item);
				return;
			}
			var curr = _header;
			SlinkedNode<T> pre = null;
			for (int i = 0; i < index && curr!=null; i++)
			{
				pre = curr;
				curr = curr.Next;
			}

			SlinkedNode<T> node = new SlinkedNode<T>(item);
			node.Next = curr;
			pre.Next = node;
			_size++;
		}

		public int Contains(T item)
		{
			for (int i = 0; i < _size; i++)
			{
				if (GetNode(i).Value.CompareTo(item) == 0) return i;
			}
			return -1;
		}

		public void RemoveAt(int index)
		{
			if (IsEmpty()) throw new NullReferenceException();

			var cur = _header;
			SlinkedNode<T> pre = null;
			for (int i = 0; i < index && cur != null; i++)
			{
				pre = cur;
				cur = cur.Next;
			}
			if (pre == null) _header = cur.Next;
			else
			{
				pre.Next = cur.Next;
				if (index == _size - 1) _trailer = pre;
			}
			cur = null;
			_size--;
		}

		//public T ValueAt(int index)
		//{
		//	var cur = _header;
		//	for (int i = 0; i < index && cur != null; i++)
		//	{
		//		cur = cur.Next;
		//	}
		//	if (cur == null) throw new IndexOutOfRangeException("index");
		//	return cur.Value;
		//}

		public T this[int index]
		{
			get { return GetNode(index).Value; }
		}

		private SlinkedNode<T> GetNode(int index)
		{
			var cur = _header;
			for (int i = 0; i < index && cur != null; i++)
			{
				cur = cur.Next;
			}
			if (cur == null) throw new IndexOutOfRangeException();
			return cur;
		}

		public List<T> ToList()
		{
			List<T> res = new List<T>();
			var cur = _header;
			for (int i = 0; i < _size; i++)
			{
				res.Add(cur.Value);
				cur = cur.Next;
			}
			return res;
		}
	}
	public class SlinkedNode<T> where T : IComparable<T>
	{
		private T _value;
		private SlinkedNode<T> _next;

		public SlinkedNode() { }
		public SlinkedNode(T value) { _value = value; }

		public T Value
		{
			get { return _value; }
			set { _value = value; }
		}
		public SlinkedNode<T> Next
		{
			get { return _next; }
			set { _next = value; }
		}

	}
}
