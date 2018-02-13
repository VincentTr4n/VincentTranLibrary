
using System;
using System.Collections.Generic;
using System.Linq;

namespace VincentTran.Helpers
{
	public static class CollectionHelpers
	{
		public static void Fill<T>(this T[] a, T value)
		{
			for (int i = 0; i < a.Length; ++i) a[i] = value;
		}
		public static void Fill2<T>(this T[,] a, T value)
		{
			for (int i = 0; i < a.GetLength(0); ++i)
				for (int j = 0; j < a.GetLength(1); ++j) a[i, j] = value;
			int[] temp = new int[10];
		}

		public static void Fill3<T>(this T[,,] a, T value)
		{
			for (int i = 0; i < a.GetLength(0); ++i)
				for (int j = 0; j < a.GetLength(1); ++j)
					for (int k = 0; k < a.GetLength(2); ++k) a[i, j, k] = value;
		}

		public static void Fill4<T>(this T[,,,] a, T value)
		{
			for (int i = 0; i < a.GetLength(0); ++i)
				for (int j = 0; j < a.GetLength(1); ++j)
					for (int k = 0; k < a.GetLength(2); ++k)
						for (int t = 0; t < a.GetLength(3); ++t) a[i, j, k, t] = value;
		}

		public static bool Remove<T>(this ICollection<T> list,Func<T,bool> selector)
		{
			var items = list.Where(selector).ToList();
			if (items.Count() == 0) return false;
			foreach (var item in items) list.Remove(item);
			return true;
		}
	}
}
