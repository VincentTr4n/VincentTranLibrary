
namespace VincentTran.Algorithms.DataStructures
{
	public class DisjointSetUnionNaive
	{
		private readonly int _n;
		private int[] p;

		public DisjointSetUnionNaive(int n)
		{
			_n = n;
			p = new int[n];
			for (int i = 0; i < n; i++)
			{
				p[i] = i;
			}
		}

		public bool InOneSet(int a, int b)
		{
			return p[a] == p[b];
		}

		public bool Join(int a, int b)
		{
			if (InOneSet(a, b))
				return false;

			int oldSet = p[a];
			int newSet = p[b];
			for (int i = 0; i < _n; i++)
			{
				if (p[i] == oldSet)
					p[i] = newSet;
			}

			return true;
		}
	}
}
