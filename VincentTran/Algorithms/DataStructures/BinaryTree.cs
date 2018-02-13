using System;

namespace VincentTran.Algorithms.DataStructures
{
	public class BinaryTree<K, T> where K : IComparable<K>
	{
		private BNode<K, T> _root;
		private int _count;

		public BNode<K, T> Root => _root;
		public int Count => _count;

		public void Add(K key, T value)
		{
			BNode<K, T> node = new BNode<K, T>(key, value);
			if (_root == null)
			{
				_root = node;
				_count++;
				return;
			}
			var cur = _root;
			while (cur != null)
			{
				if (key.CompareTo(cur.Key) == 0) throw new ArgumentException("An item with the same key has already been added");
				if (key.CompareTo(cur.Key) < 0)
				{
					if (cur.Left == null)
					{
						node.Parent = cur;
						cur.Left = node;
						_count++;
						return;
					}
					else cur = cur.Left;
				}
				else
				{
					if (cur.Right == null)
					{
						node.Parent = cur;
						cur.Right = node;
						_count++;
						return;
					}
					else cur = cur.Right;
				}
			}
		}

		public T GetValue(K key)
		{
			var node = GetBNode(key);
			if (node != null) return node.Value;
			return default(T);
		}

		public bool ContrainsKey(K key) => GetBNode(key) != null;

		//public void Remove(K key)
		//{
		//	var node = GetBNode(key);
		//	if (node == null) return;
		//	var parent = node.Parent;

		//	if (!node.HasLeft && !node.HasRight)
		//	{
		//		if (parent != null)
		//		{
		//			if (parent.Left.Key.CompareTo(key) == 0) parent.Left = null;
		//			if (parent.Right.Key.CompareTo(key) == 0) parent.Right = null;
		//		}
		//		else
		//		{
		//			_root = null;
		//		}
		//		_count--;
		//		return;
		//	}
		//	if (node.HasLeft && node.HasRight)
		//	{
		//		if (parent != null)
		//		{
		//			SetNode(parent, node.Right, key);
		//			node = null;
		//		}
		//		else
		//		{
		//			_root = node.Right;
		//			_root.Left = node.Left;
		//			_root.Parent = null;
		//		}
		//		_count--;
		//		return;
		//	}
		//	if (node.HasLeft && !node.HasRight)
		//	{
		//		if (parent != null) SetNode(parent, node.Left, key);
		//		else _root = node.Left;
		//		_count--;
		//		return;
		//	}
		//	if (!node.HasLeft && node.HasRight)
		//	{
		//		if (parent != null) SetNode(parent, node.Right, key);
		//		else _root = node.Right;
		//		_count--;
		//		return;
		//	}
		//}

		private void SetNode(BNode<K, T> parent, BNode<K, T> node, K key)
		{
			if (parent.Left != null && parent.Left.Key.CompareTo(key) == 0) parent.Left = node;
			if (parent.Right != null && parent.Right.Key.CompareTo(key) == 0) parent.Right = node;
			node.Parent = parent;
		}
		private BNode<K, T> GetBNode(K key)
		{
			var cur = _root;
			while (cur != null)
			{
				if (key.CompareTo(cur.Key) == 0) return cur;
				if (key.CompareTo(cur.Key) < 0) cur = cur.Left;
				else cur = cur.Right;
			}
			return null;
		}
	}
	public class BNode<K, T> where K : IComparable<K>
	{
		private K _key;
		private T _value;
		BNode<K, T> _parent;
		BNode<K, T> _left;
		BNode<K, T> _right;

		public BNode() { }
		public BNode(K key, T value)
		{
			_key = key;
			_value = value;
		}

		public T Value
		{
			get { return _value; }
			set { _value = value; }
		}
		public K Key
		{
			get { return _key; }
			set { _key = value; }
		}
		public BNode<K, T> Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}
		public BNode<K, T> Left
		{
			get { return _left; }
			set { _left = value; }
		}
		public BNode<K, T> Right
		{
			get { return _right; }
			set { _right = value; }
		}

		public bool HasLeft => _left != null;
		public bool HasRight => _right != null;
	}
}
