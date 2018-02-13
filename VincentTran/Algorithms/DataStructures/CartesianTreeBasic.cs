
namespace VincentTran.Algorithms.DataStructures
{
	/// <summary>
	/// Cartesian tree
	/// </summary>
	public class CartesianTreeBasic
	{
		private int _key, _priority;
		private CartesianTreeBasic _left, _right;

		public int Priortity{ get { return _priority; } }
		public int Key { get { return _key; } }

		/// <summary>
		/// Splits the tree into two trees.
		/// The left tree contains all nodes with keys less that <param name="key"></param>
		/// </summary>
		public static void Split(CartesianTreeBasic tree, int key, out CartesianTreeBasic left, out CartesianTreeBasic right)
		{
			left = null;
			right = null;
			if (tree == null) return;
			if (tree._key < key)
			{
				Split(tree._right, key, out tree._right, out right);
				left = tree;
			}
			else
			{
				Split(tree._left, key, out left, out tree._left);
				right = tree;
			}
			RefreshAdditionalData(tree);
		}

		/// <summary>
		/// Inserts the node in tree
		/// </summary>
		public static void Insert(ref CartesianTreeBasic tree, int key, int priority)
		{
			if (tree == null)
			{
				tree = new CartesianTreeBasic { _key = key, _priority = priority };
			}
			else
			{
				if (tree._priority > priority)
				{
					if (tree._key < key) Insert(ref tree._right, key, priority);
					else Insert(ref tree._left, key, priority);
				}
				else
				{
					CartesianTreeBasic tL, tR;
					Split(tree, key, out tL, out tR);
					tree = new CartesianTreeBasic { _key = key, _priority = priority, _left = tL, _right = tR };
				}
			}
			RefreshAdditionalData(tree);
		}

		/// <summary>
		/// Finds the node by key
		/// </summary>
		public static CartesianTreeBasic Find(CartesianTreeBasic tree, int key)
		{
			if (tree == null) return null;
			if (tree._key == key) return tree;
			if (tree._key < key) return Find(tree._right, key);
			return Find(tree._left, key);
		}

		/// <summary>
		/// Merges two trees into one
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static CartesianTreeBasic Merge(CartesianTreeBasic left, CartesianTreeBasic right)
		{
			if (left == null)
				return right;
			if (right == null)
				return left;
			if (left._priority > right._priority)
			{
				left._right = Merge(left._right, right);
				RefreshAdditionalData(left);
				return left;
			}
			else
			{
				right._left = Merge(left, right._left);
				RefreshAdditionalData(right);
				return right;
			}
		}

		private static void RefreshAdditionalData(CartesianTreeBasic tree)
		{
			if (tree == null)
				return;

		}
	}
}
