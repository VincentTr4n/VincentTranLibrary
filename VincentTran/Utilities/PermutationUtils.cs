using System;
using System.Collections.Generic;

namespace VincentTran.Utilities
{
	public static class PermutationUtils
	{
		/// <summary>
		/// Gets first in lexicographical order permutation
		/// </summary>
		public static int[] First(this int n)
		{
			int[] res = new int[n];
			for (int i = 0; i < n; ++i) res[i] = i;
			return res;
		}

		public static int[] GeneratingPermutation(this int n)
		{
			Random random = new Random();
			var res = PermutationUtils.First(n);
			for (int i = 0; i < n; i++)
			{
				int j = i + random.Next(n - i);
				int t = res[j];
				res[j] = res[i];
				res[i] = t;
			}
			return res;
		}

		/// <summary>
		/// Gets next in lexicographical order permutation
		/// </summary>
		public static bool Next(this int[] p)
		{
			if (p.Length == 1) return false;
			int i = p.Length - 1;

			for (;;)
			{
				int ii = i;
				--i;
				if (p[i].CompareTo(p[ii]) < 0)
				{
					int j = p.Length - 1;
					while (p[i].CompareTo(p[j]) >= 0) j--;
					int tmp = p[i];
					p[i] = p[j];
					p[j] = tmp;
					int l = ii, r = p.Length - 1;
					while (l < r)
					{
						tmp = p[l];
						p[l] = p[r];
						p[r] = tmp;
						++l;
						--r;
					}
					return true;
				}
				if (i == 0)
				{
					int l = 0, r = p.Length - 1;
					while (l < r)
					{
						int tmp = p[l];
						p[l] = p[r];
						p[r] = tmp;
						++l;
						--r;
					}
					return false;
				}
			}
		}

		/// <summary>
		/// Gets next in lexicographical order permutation
		/// </summary>
		public static bool NextExt<T>(IList<T> c, int first, int last) where T : IComparable<T>
		{
			if (first == last) return false;
			int i = first + 1;
			if (i == last) return false;
			i = last - 1;

			for (;;)
			{
				int ii = i;
				--i;
				if (c[i].CompareTo(c[ii]) < 0)
				{
					int j = last - 1;
					while (c[i].CompareTo(c[j]) >= 0) j--;

					T tmp = c[i];
					c[i] = c[j];
					c[j] = tmp;
					int l = ii, r = last - 1;

					while (l < r)
					{
						tmp = c[l];
						c[l] = c[r];
						c[r] = tmp;
						++l;
						--r;
					}
					return true;
				}
				if (i == first)
				{
					int l = first, r = last - 1;
					while (l < r)
					{
						T tmp = c[l];
						c[l] = c[r];
						c[r] = tmp;
						++l;
						--r;
					}
					return false;
				}
			}
		}

		/// <summary>
		/// Counts the number of invertions. I.e. such pairs of indices (i,j) that i &lt; j and items[i] &gt; items[j]
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static long CountInvertions<T>(IList<T> items) where T : IComparable<T>
		{
			var a = new T[items.Count];
			for (int i = 0; i < items.Count; ++i)
			{
				a[i] = items[i];
			}
			return MergeSort(a, 0, a.Length - 1, new T[items.Count]);
		}

		private static long MergeSort<T>(IList<T> items, int l, int r, T[] tmp) where T : IComparable<T>
		{
			if (l >= r)
				return 0;
			int m = (l + r) / 2;
			var result = MergeSort(items, l, m, tmp) + MergeSort(items, m + 1, r, tmp);

			int i = l, j = m + 1, k = l;
			while (i <= m && j <= r)
			{
				var cmp = items[i].CompareTo(items[j]);
				if (cmp <= 0)
				{
					result += j - m - 1;
					tmp[k++] = items[i++];
				}
				else
				{
					tmp[k++] = items[j++];
				}
			}

			while (i <= m)
			{
				result += r - m;
				tmp[k++] = items[i++];
			}

			while (j <= r)
			{
				tmp[k++] = items[j++];
			}

			for (i = l; i <= r; ++i) items[i] = tmp[i];

			return result;
		}

		/// <summary>
		/// Gets inverse permutation of a given one
		/// </summary>
		public static int[] GetInversePermutation(this int[] p)
		{
			int n = p.Length;
			var res = new int[n];
			for (int i = 0; i < n; ++i)
				res[p[i]] = i;
			return res;
		}
	}
}
