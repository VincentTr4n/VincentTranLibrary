using System;

namespace VincentTran.Geometry
{
	public struct PointInt2D : IEquatable<PointInt2D>, IComparable<PointInt2D>
	{
		public readonly long X;
		public readonly long Y;

		public PointInt2D(long x, long y) { X = x; Y = y; }

		public static PointInt2D operator +(PointInt2D a, PointInt2D b)  => new PointInt2D(a.X + b.X, a.Y + b.Y); 
		public static PointInt2D operator -(PointInt2D a, PointInt2D b)  => new PointInt2D(a.X - b.X, a.Y - b.Y); 
		public static long operator *(PointInt2D a, PointInt2D b) => a.X * b.Y - a.Y * b.X; 
		public static PointInt2D operator *(PointInt2D a, long k) => new PointInt2D(a.X * k, a.Y * k); 
		public long DistSq() => X * X + Y * Y;
		public long DistDQ(PointInt2D other) => (other.X - X) * (other.X - X) + (other.Y - Y) * (other.Y - Y);

		public bool Equals(PointInt2D other) => X == other.X && Y == other.Y;

		public int CompareTo(PointInt2D other) => (X != other.X) ? X.CompareTo(other.X) : Y.CompareTo(other.Y);

		public override string ToString() => string.Format("{0}, {1}", X, Y);

		public override int GetHashCode() => (int)(1997 * X + 1000000009 * Y);

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (obj is PointInt2D)
			{
				var other = (PointInt2D)obj;
				return X == other.X && Y == other.Y;
			}
			return false;
		}
	}
}
