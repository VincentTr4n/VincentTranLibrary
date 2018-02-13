using System;

namespace VincentTran.Algorithms
{
	public class SearchAlgo<T> where T : IComparable<T>
	{
		/// <summary>
		/// Binary Search on sorted array with Time complexity : O(LogN)
		/// Return index of value (if not found return -1)
		/// </summary>
		public static int BinarySearch(T[] arr, T value) => BinarySearch(arr, 0, arr.Length - 1, value);
		public static int BinarySearch(T[] arr, int Left, int Right, T value)
		{
			int i = Left, j = Right;
			while (i <= j)
			{
				int M = (i + j) / 2;
				int compare = arr[M].CompareTo(value);
				if (compare == 0) return M;
				else if (compare > 0) j = M - 1;
				else i = M + 1;
			}
			return -1;
		}

		/// <summary>
		/// Jump Search on sorted array with Time complexity : O(sqrt(N))
		/// </summary>
		public static int JumpSearch(T[] arr, T value)
		{
			int N = arr.Length, jump = (int)Math.Sqrt(N);
			int index = 0;
			while (arr[Math.Min(jump, N) - 1].CompareTo(value) < 0)
			{
				index = jump;
				jump += (int)Math.Sqrt(N);
				if (index >= N) return -1;
			}
			while (arr[index].CompareTo(value) < 0)
			{
				index++;
				if (index == Math.Min(jump, N)) return -1;
			}
			if (arr[index].CompareTo(value) == 0) return index;
			return -1;
		}

		/// <summary>
		/// Ternary Search on sorted array with Time complexity : O(Log3(N)))
		/// </summary>
		public static int TernarySearch(T[] arr, T value) => TernarySearch(arr, 0, arr.Length - 1, value);
		public static int TernarySearch(T[] arr, int Left, int Right, T value)
		{
			if (Left > Right) return -1;
			int M1 = Left + (Right - Left) / 3;
			int M2 = Left + 2 * (Right - Left) / 3;
			if (arr[M1].CompareTo(value) == 0) return M1;
			else if (arr[M2].CompareTo(value) == 0) return M2;
			else if (arr[M1].CompareTo(value) > 0) return TernarySearch(arr, Left, M1 - 1, value);
			else if (arr[M2].CompareTo(value) < 0) return TernarySearch(arr, M2 + 1, Right, value);
			else return TernarySearch(arr, M1, M2, value);
		}
	}
	public class SearchAlgo : SearchAlgo<int> { }
}
