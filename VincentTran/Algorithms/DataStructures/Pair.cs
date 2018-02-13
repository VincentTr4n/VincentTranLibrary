
using System;

namespace VincentTran.Algorithms.DataStructures
{
	public class Pair<T, K> : IComparable<Pair<T, K>> where T : IComparable<T> where K : IComparable<K>
	{
		public T First { get; set; }
		public K Second { get; set; }

		public Pair()
		{
			
		}
		public Pair(T first,K second){
			First = first;
			Second = second;
		}

		#region IComparable<Pair<T,K>> Members

		public int CompareTo(Pair<T, K> other)
		{
			if (First.CompareTo(other.First) != 0)
				return First.CompareTo(other.First);
			return Second.CompareTo(other.Second);
		}

		#endregion
	}
}
