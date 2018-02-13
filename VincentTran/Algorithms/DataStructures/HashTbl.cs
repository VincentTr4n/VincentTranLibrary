using System;
using VincentTran.Helpers;

namespace VincentTran.Algorithms.DataStructures
{
	public class HashTbl<K,T> where K : IComparable<K>
	{
		private int _capacity;
		private SLinkedListWithKey<K,T>[] table;

		public HashTbl(int capacity)
		{
			_capacity = capacity;
			table = new SLinkedListWithKey<K, T>[capacity];
			table.Fill(new SLinkedListWithKey<K, T>());
		}
		public int Size => _capacity;
	
		public void Add(K key,T item)
		{
			int h = hash(key);
			table[h].Push(key, item);
		}

		public T this[K key]
		{
			get { return GetItem(key); }
			set { Add(key, value); }
		}

		public bool ContainsKey(K key)
		{
			int h = hash(key);
			var subTB = table[h];
			return subTB.GetNode(key)==null?false:true;
		}

		public T GetItem(K key)
		{
			int h = hash(key);
			var node = table[h].GetNode(key);
			if (node == null) return default(T);
			return node.Value;
		}

		public void Remove(K key)
		{
			int h = hash(key);
			table[h].Remove(key);
		}
		
		public void Replace(K key,T item)
		{
			int h = hash(key);
			table[h].Replace(key, item);
		}
		private int hash(K key)
		{
			return Math.Abs(key.GetHashCode()) % _capacity;
		}
	}
}
