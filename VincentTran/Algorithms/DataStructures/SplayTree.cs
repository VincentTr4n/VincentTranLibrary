using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentTran.Algorithms.DataStructures
{
	public class SplayTree<K, T> where K : IComparable<K>
	{
		private SplayNode root;
		private int _count = 0;
		public int Count => _count;
		public bool contains(K key) => this[key] != null;
		public T this[K key]
		{
			get
			{
				try
				{
					root = splay(root, key);
					return key.CompareTo(root.Key) == 0 ? root.Value : default(T);
				}
				catch { return default(T); }
			}
			set
			{
				root = splay(root, key);
				if (key.CompareTo(key) == 0) root.Value = value;
				else Add(key, value);
			}
		}
		public void Add(K key,T value)
		{
			if (root == null)
			{
				root = new SplayNode(key, value);
				_count++;
				return;
			}
			root = splay(root, key);

			int compare = key.CompareTo(root.Key);
			if (compare < 0)
			{
				SplayNode node = new SplayNode(key, value);
				node.Left = root.Left;
				node.Right = root;
				root.Left = null;
				root = node;
			}
			else if (compare > 0)
			{
				SplayNode node = new SplayNode(key, value);
				node.Right = root.Right;
				node.Left = root;
				root.Right = null;
				root.Right = node;
			}
			else
			{
				root.Value = value;
				_count--;
			}
			_count++;
		}

		public void Remove(K key)
		{
			if (root == null) return;
			root = splay(root, key);
			int compare = key.CompareTo(root.Key);
			if (compare == 0)
			{
				if (root.Left == null) root = root.Right;
				else
				{
					SplayNode node = root.Right;
					root = root.Left;
					splay(node, key);
					root.Right = node;
				}
				_count--;
			}
		}

		private SplayNode splay(SplayNode node, K key)
		{
			if (node == null) return null;
			int compare1 = key.CompareTo(node.Key);
			if (compare1 < 0)
			{
				if (node.Left == null) return node;
				int compare2 = key.CompareTo(node.Left.Key);
				if (compare2 < 0)
				{
					node.Left.Left = splay(node.Left.Left, key);
					node = rotateRight(node);
				}
				else if (compare2 > 0)
				{
					node.Left.Right = splay(node.Left.Right, key);
					if (node.Left.Right != null) node.Left = rotateLeft(node.Left);
				}

				if (node.Left == null) return node;
				else return rotateRight(node);
			}
			else if (compare1 > 0)
			{
				if (node.Right == null) return node;
				int compare2 = key.CompareTo(node.Right.Key);
				if (compare2 < 0)
				{
					node.Right.Left = splay(node.Right.Left, key);
					if (node.Right.Left != null) node.Right = rotateLeft(node.Right);
				}
				else if (compare2 > 0)
				{
					node.Right.Right = splay(node.Right.Right, key);
					node = rotateLeft(node);
				}

				if (node.Right == null) return node;
				else return rotateLeft(node);
			}
			else return node;
		}
		public int Height => height(root);
		private int height(SplayNode x)
		{
			if (x == null) return -1;
			return 1 + Math.Max(height(x.Left), height(x.Right));
		}
		private SplayNode rotateRight(SplayNode node)
		{
			SplayNode res = node.Left;
			node.Left = res.Right;
			res.Right = node;
			return res;
		}
		private SplayNode rotateLeft(SplayNode node)
		{
			SplayNode res = node.Right;
			node.Right = res.Left;
			res.Left = node;
			return res;
		}
		class SplayNode
		{
			public K Key { get; set; }
			public T Value { get; set; }
			public SplayNode Left { get; set; }
			public SplayNode Right { get; set; }
			public SplayNode(K key, T value)
			{
				Key = key;
				Value = value;
			}
		}
	}
	public class SplayTree : SplayTree<string, string> { }
}
