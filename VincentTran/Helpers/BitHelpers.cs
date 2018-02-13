using System;
using System.Collections.Generic;
using System.Text;

namespace VincentTran.Helpers
{
	public static class BitHelpers
	{
		/// <summary>
		/// Counts the number of one bits in non-negative number. 
		/// Parameters: A 32-bit signed integer.
		/// </summary>
		public static int CountBitsOne(this int x)
		{
			if (x < 0) throw new Exception("Can't count bits in negative number");
			int res = 0;
			while (x > 0)
			{
				++res;
				x &= (x - 1);
			}
			return res;
		}

		/// <summary>
		/// Counts the number of one bits in non-negative number. 
		/// Parameters: A 64-bit signed integer.
		/// </summary>
		public static int CountBitsOne(this long x)
		{
			if (x < 0) throw new Exception("Can't count bits in negative number");
			int res = 0;
			while (x > 0)
			{
				++res;
				x &= (x - 1);
			}
			return res;
		}

		/// <summary>
		/// Checks that bit is present in mask. 
		/// Parameters: A 32-bit signed integer and a number (bit)
		/// </summary>
		public static bool BitInMask(this int mask, int bit) => (mask & (1 << bit)) != 0;

		/// <summary>
		/// Checks that bit is present in mask. 
		/// Parameters: A 64-bit signed integer and a number (bit)
		/// </summary>
		public static bool BitInMask(this long mask, int bit) => (mask & (1L << bit)) != 0;

		/// <summary>
		/// Checks whether x is power of two. 
		/// Parameters: A 32-bit signed integer
		/// </summary>
		public static bool IsPowerOfTwo(this int x) => x > 0 && (x & (x - 1)) == 0;

		/// <summary>
		/// Checks whether x is power of two. 
		/// Parameters: A 64-bit signed integer
		/// </summary>
		public static bool IsPowerOfTwo(this long x) => x > 0 && (x & (x - 1)) == 0;

		/// <summary>
		/// Convert a 32-bit signed integer (Convert to a character) to Binary
		/// </summary>
		/// <returns></returns>
		public static string ToBinary(this int x)
		{
			Stack<int> st = new Stack<int>();
			StringBuilder sb = new StringBuilder();
			while (x != 0)
			{
				int t = x % 2;
				x /= 2;
				st.Push(t);
			}
			while (st.Count != 0)
			{
				int top = st.Peek(); st.Pop();
				sb.Append(top.ToString());
			}
			string s = sb.ToString();
			while (s.Length < 8) s = "0" + s;
			return s;
		}
	}
}
