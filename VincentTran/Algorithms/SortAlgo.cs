using System;

namespace VincentTran.Algorithms
{
	public class SortAlgo<T> where T : IComparable<T>
	{
		/// <summary>
		/// Insertion Sort with Time complexity : O(N^2)
		/// </summary>
		public static void InsertionSort(T[] arr) => InsertionSort(arr, 0, arr.Length - 1, (a, b) => a.CompareTo(b));
		public static void InsertionSort(T[] arr, int L, int R, Func<T, T, int> compare)
		{
			for (int i = L + 1; i <= R; i++)
			{
				int j = i;
				while (j > L && compare(arr[j], arr[j - 1])<0)
				{
					swap(ref arr[j], ref arr[j - 1]);
					j--;
				}
			}
		}

		/// <summary>
		/// Selection Sort with Time complexity : O(N^2)
		/// </summary>
		public static void SelectionSort(T[] arr) => SelectionSort(arr, (a, b) => a.CompareTo(b) < 0);
		public static void SelectionSort(T[] arr, Func<T, T, bool> compare)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				int IndexOfMin = i;
				for (int j = i + 1; j < arr.Length; j++)
				{
					if (compare(arr[j], arr[IndexOfMin])) IndexOfMin = j;
				}
				swap(ref arr[i], ref arr[IndexOfMin]);
			}
		}

		/// <summary>
		/// Merge Sort with Time complexity : O(N*LogN)
		/// </summary>
		public static void MergeSort(T[] arr, Func<T, T, int> compare) => MergeSort(arr,0,arr.Length-1,compare);
		public static void MergeSort(T[] arr) => MergeSort(arr, 0, arr.Length - 1,(a,b)=>a.CompareTo(b));
		public static void MergeSort(T[] arr, int L, int R, Func<T, T, int> compare)
		{
			if (L < R)
			{
				int M = (L + R) / 2;
				MergeSort(arr, L, M,compare);
				MergeSort(arr, M + 1, R,compare);
				Merge(arr, L, M, R,compare);
			}
		}

		static void Merge(T[] arr, int L, int M, int R, Func<T, T, int> compare)
		{
			int i = 0, j = 0, k = L;
			int n1 = M - L + 1;
			int n2 = R - M;

			T[] arr1 = new T[n1];
			T[] arr2 = new T[n2];

			Array.Copy(arr, L, arr1, 0, n1);
			Array.Copy(arr, M + 1, arr2, 0, n2);

			while (i < n1 && j < n2)
			{
				if (compare(arr1[i],arr2[j]) <= 0) arr[k++] = arr1[i++];
				else arr[k++] = arr2[j++];
			}
			while (i < n1) arr[k++] = arr1[i++];
			while (j < n2) arr[k++] = arr2[j++];
		}

		/// <summary>
		/// Quick Sort with Time complexity : O(N*LogN)
		/// </summary>
		public static void QuickSort(T[] arr, Func<T, T, int> compare) => QuickSort(arr, 0, arr.Length - 1,compare);
		public static void QuickSort(T[] arr) => QuickSort(arr, 0, arr.Length - 1, (a, b) => a.CompareTo(b));
		public static void QuickSort(T[] arr, int L, int R, Func<T, T, int> compare)
		{
			int i = L, j = R;
			T M = arr[(i + j) / 2];
			while (i <= j)
			{
				while (compare(arr[i], M) < 0) i++;
				while (compare(arr[j], M) > 0) j--;
				if (i <= j) swap(ref arr[i++], ref arr[j--]);
			}
			if (L < j) QuickSort(arr, L, j, compare);
			if (R > i) QuickSort(arr, i, R, compare);
		}

		/// <summary>
		/// Heap Sort with Time complexity : O(N*LogN)
		/// </summary>
		public static void HeapSort(T[] arr) => HeapSort(arr, (a, b) => a.CompareTo(b));
		public static void HeapSort(T[] arr, Func<T, T, int> compare)
		{
			int N = arr.Length - 1;
			for (int i = N / 2; i >= 0; i--) heapify(arr, i, N,compare);
			for (int i = N; i >= 2; i--)
			{
				swap(ref arr[0], ref arr[i]);
				heapify(arr, 0, i - 1,compare);
			}
		}
		static void heapify(T[] arr, int i, int n, Func<T, T, int> compare)
		{
			int k = i, largest = -1;
			while (k <= n / 2)
			{
				if (2 * k == n) largest = 2 * k;
				else
				{
					if (compare(arr[2 * k],arr[2 * k + 1]) <= 0) largest = 2 * k + 1;
					else largest = 2 * k;
				}

				if (compare(arr[k],arr[largest]) < 0)
				{
					swap(ref arr[k], ref arr[largest]);
					k = largest;
				}
				else break;
			}
		}

		/// <summary>
		/// Tim Sort with Time complexity : O(N*LogN)
		/// It based on Insertion Sort and Merge Sort
		/// Note : MIN_RUN depends on the length of Array input and values accept : 32, 64, 128, 256 .... 
		/// </summary>
		public static void TimSort(T[] arr, int MIN_RUN = 32) => TimSort(arr, (a, b) => a.CompareTo(b),MIN_RUN);
		public static void TimSort(T[] arr, Func<T, T, int> compare, int MIN_RUN = 32)
		{
			int N = arr.Length, SIZE = GetSize(N + 1, MIN_RUN);
			for (int i = 0; i < N; i += SIZE)
				InsertionSort(arr, i, Math.Min(i + SIZE - 1, N - 1), compare);
			for (int i = SIZE; i < N; i <<= 1)
			{
				for (int L = 0; L < N; L += i * 2)
				{
					int M = L + i - 1;
					int R = Math.Min(M + i, N - 1);
					Merge(arr, L, M, R,compare);
				}
			}
		}
		public static int GetSize(int n, int MIN_RUN)
		{
			int r = 0;
			while (n >= MIN_RUN)
			{
				r |= n & 1;
				n >>= 1;
			}
			return n + r;
		}

		/// <summary>
		/// Swap two object
		/// </summary>
		static void swap(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}
	}
	public class SortAlgo : SortAlgo<int> { }
}
