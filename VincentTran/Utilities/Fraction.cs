
using System;
using System.Collections.Generic;

namespace VincentTran.Utilities
{
	/// <summary>
	/// Fraction p/q of 64-bit numbers
	/// </summary>
	public struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
	{
		#region Attributes
		private long _p;
		private long _q;

		public long P
		{
			get { return _p; }
		}

		public long Q
		{
			get { return _q; }
		} 
		#endregion

		#region Constructors
		public Fraction(long x)
		{
			_p = x;
			_q = 1;
		}

		public Fraction(long p, long q)
		{
			_p = p;
			_q = q;
			Normalize();
		} 
		#endregion

		#region Operators
		public static Fraction operator +(Fraction a, Fraction b)
		{
			var res = (a._q == b._q) ? new Fraction(a._p + b._p, a._q) : new Fraction(a._p * b._q + b._p * a._q, a._q * b._q);
			res.Normalize();
			return res;
		}

		public static Fraction operator -(Fraction a, Fraction b)
		{
			var res = (a._q == b._q) ? new Fraction(a._p - b._p, a._q) : new Fraction(a._p * b._q - b._p * a._q, a._q * b._q);
			res.Normalize();
			return res;
		}

		public static Fraction operator -(Fraction o)
		{
			return new Fraction(-o._p, o._q);
		}

		public static Fraction operator *(Fraction a, Fraction b)
		{
			var res = new Fraction(a._p * b._p, a._q * b._q);
			res.Normalize();
			return res;
		}

		public static Fraction operator /(Fraction a, Fraction b)
		{
			var res = new Fraction(a._p * b._q, a._q * b._p);
			res.Normalize();
			return res;
		}

		public static bool operator <(Fraction a, Fraction b) => a.CompareTo(b) < 0;

		public static bool operator >(Fraction a, Fraction b) => a.CompareTo(b) > 0;

		public static bool operator ==(Fraction a, Fraction b) => a.CompareTo(b) == 0;

		public static bool operator !=(Fraction a, Fraction b) => a.CompareTo(b) != 0;

		public static implicit operator Fraction(long num) => new Fraction(num, 1);

		public static implicit operator Fraction(int num) => new Fraction(num, 1);

		public static implicit operator Fraction(string num) => new Fraction(long.Parse(num), 1);

		public static explicit operator int(Fraction num) => (int)(num._p / num._q);

		public static explicit operator long(Fraction num) => (long)(num._p / num._q); 
		#endregion

		#region Other Methods
		private void Normalize()
		{
			if (_q == 0)
				throw new DivideByZeroException();

			if (_q < 0)
			{
				_p = -_p;
				_q = -_q;
			}
			var g = NumTheoryUtils.Gcd(_p, _q);
			if (g != 1)
			{
				_p /= g;
				_q /= g;
			}
		}

		public override bool Equals(object obj)
		{
			var other = obj as Fraction?;
			if (!other.HasValue) return false;
			return _p == other.Value._p && _q == other.Value._q;
		}

		public override int GetHashCode() => (int)(_p * 1997 + _q * 1000000007);

		public int CompareTo(Fraction other) => (_p * other._q < _q * other._p) ? -1 : (_p * other._q == _q * other._p) ? 0 : 1;

		public bool Equals(Fraction other) => _p == other._p && _q == other._q;

		/// <summary>
		/// Gets decimal presentation of fraction.
		/// For example:
		/// 1) 1/2 = 0.5
		/// 2) 1/9 = 0.(1)
		/// </summary>
		/// <returns></returns>
		public string ToDecimalString()
		{
			if (_q == 1)
				return _p.ToString();
			var builder = new System.Text.StringBuilder();
			var a = Math.Abs(_p);
			if (_p < 0) builder.Append("-");
			builder.Append(a / _q);
			builder.Append(".");
			a %= _q;
			var builder2 = new System.Text.StringBuilder();
			var was = new Dictionary<long, int>();
			for (int i = 0; a != 0; i++)
			{
				if (was.ContainsKey(a))
				{
					var start = was[a];
					var len = i - start;
					var s = builder2.ToString();
					if (start > 0)
						builder.Append(s.Substring(0, start));
					builder.Append("(");
					builder.Append(s.Substring(start, len));
					builder.Append(")");
					return builder.ToString();
				}
				else
				{
					was.Add(a, i);
					a *= 10;
					builder2.Append(a / _q);
					a %= _q;
				}
			}
			return builder.ToString() + builder2;
		}

		public override string ToString() => _q == 1 ? _p.ToString() : _p + "/" + _q; 
		#endregion
	}
}
