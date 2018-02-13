using System;

namespace VincentTran.Utilities.Matrix
{
	public class MatrixInt
	{
		public static int MOD = 1000000007;

		public readonly int Rows, Cols;
		private int[,] _Data { get; set; }

		public MatrixInt(int rows, int cols)
		{
			if (rows <= 0) throw new ArgumentOutOfRangeException("rows");
			if (cols <= 0) throw new ArgumentOutOfRangeException("cols");
			Rows = rows; Cols = cols;
			_Data = new int[rows, cols];
		}

		public int[,] Data
		{
			get { return _Data; }
			set
			{
				if (value.Length / Cols != Rows) throw new ArgumentOutOfRangeException("size");
				_Data = value;
			}
		}

		public static MatrixInt operator *(MatrixInt a, MatrixInt b)
		{
			if (a == null) throw new ArgumentNullException("a");
			if (b == null) throw new ArgumentNullException("b");
			if (a.Cols != b.Rows) throw new ArgumentException("Invalid matrix dimensions");
			MatrixInt c = new MatrixInt(a.Rows, b.Cols);
			for (int i = 0; i < a.Rows; i++)
				for (int j = 0; j < b.Cols; ++j)
					for (int k = 0; k < a.Cols; ++k)
					{
						c._Data[i, j] += (int)(((long)a._Data[i, k] * b._Data[k, j]) % MOD);
						if (c._Data[i, j] >= MOD) c._Data[i, j] -= MOD;
					}
			return c;
		}

		public static MatrixInt operator ^(MatrixInt a, long b)
		{
			if (a == null) throw new ArgumentNullException("a");
			if (a.Rows != a.Cols) throw new ArgumentException("Can't power non-square matrix");
			if (b < 0) throw new ArgumentException("Power can't be negative");
			MatrixInt res = new MatrixInt(a.Rows, a.Cols);
			if (b == 0)
			{
				for (int i = 0; i < res.Rows; ++i) res._Data[i, i] = 1;
			}
			else
			{
				res = a ^ (b >> 1);
				res *= res;
				if ((b & 1) != 0) res *= a;
			}
			return res;
		}
	}
}
