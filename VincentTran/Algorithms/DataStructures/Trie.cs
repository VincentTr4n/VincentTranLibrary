using System;
using System.Collections.Generic;

namespace VincentTran.Algorithms.DataStructures
{
	public class Trie
	{
		private TrieNode root;
		public Trie() { root = new TrieNode(); }
		public void Add(string word)
		{
			TrieNode node = root;
			foreach (var item in word)
			{
				if (!node.children.ContainsKey(item)) node.children.Add(item, new TrieNode(item));
				node = node.children[item];
			}
			node.IsEnd = true;
		}
		public bool Contains(string word) => FindNode(word) != null;
		TrieNode FindNode(string s)
		{
			TrieNode node = root;
			foreach (var item in s)
				if (node.children.ContainsKey(item)) node = node.children[item];
				else return null;
			if (node == root) return null;
			return node;
		}
	}

	class TrieNode
	{
		public char Key;
		public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
		public bool IsEnd;
		public TrieNode(char c) { Key = c; }
		public TrieNode() : this(default(char)) { }
	}
}
