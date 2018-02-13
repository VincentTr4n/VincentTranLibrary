using System;

namespace VincentTran.Algorithms.DataStructures
{
	public class SLinkedListWithKey<K, T> where K : IComparable<K>
	{
		private int _size;
		NodeWithKey<K, T> _header;
		NodeWithKey<K, T> _trailer;

		public int Size => _size;
		public NodeWithKey<K, T> Header => _header;
		public NodeWithKey<K, T> Trailer => _trailer;
		public bool IsEmpty() => _size == 0;

		public void Push(K key, T item)
		{
			var cur = _header;
			for (int i = 0; i < _size; i++)
			{
				if (cur.Key.CompareTo(key) == 0) throw new ArgumentException("An item with the same key has already been added");
				cur = cur.Next;
			}
			NodeWithKey<K, T> node = new NodeWithKey<K, T>(key, item);
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
		public NodeWithKey<K, T> GetNode(K key)
		{
			var cur = _header;
			for (int i = 0; i < _size; i++)
			{
				if (cur.Key.CompareTo(key) == 0)
				{
					return cur;
				}
				cur = cur.Next;
			}
			return null;
		}
		public void Remove(K key)
		{
			if (_size == 0) return;
			if (key.CompareTo(_header.Key) == 0)
			{
				_header = _header.Next;
				_size--;
				return;
			}
			bool check = false;
			var cur = _header;
			NodeWithKey<K, T> pre = null;
			for (int i = 0; i < _size; i++)
			{
				pre = cur;
				cur = cur.Next;
				if (cur.Key.CompareTo(key) == 0)
				{
					check = true;
					break;
				}
			}
			if (check)
			{
				pre.Next = cur.Next;
				if (key.CompareTo(_trailer.Key) == 0) _trailer = pre;
				cur = null;
				_size--;
			}
		}
		public void Replace(K key,T item)
		{
			var cur = _header;
			for (int i = 0; i < _size; i++)
			{
				if (cur.Key.CompareTo(key) == 0)
				{
					cur.Value = item;
					return;
				}
				cur = cur.Next;
			}
		}
	}
	public class NodeWithKey<K, T> where K : IComparable<K> 
	{
		private K _key;
		private T _value;
		private NodeWithKey<K, T> _next;

		public NodeWithKey() { }
		public NodeWithKey(K key, T value) { _key = key; _value = value; }

		public K Key
		{
			get { return _key; }
			set { _key = value; }
		}
		public T Value
		{
			get { return _value; }
			set { _value = value; }
		}
		public NodeWithKey<K, T> Next
		{
			get { return _next; }
			set { _next = value; }
		}
	}
}
