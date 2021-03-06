﻿
namespace VincentTran.Utilities
{
	public class PolynomialHash
	{
		private readonly string _s;
		private readonly long[] _pows;
		private readonly long[] _h;

		public PolynomialHash(string s, long p)
		{
			_s = s;
			_pows = new long[s.Length + 1];
			_pows[0] = 1;
			for (int i = 1; i <= s.Length; i++)
			{
				_pows[i] = _pows[i - 1] * p; // overflow is ok
			}
			_h = new long[s.Length];
			_h[0] = _s[0];
			for (int i = 1; i < s.Length; i++)
			{
				_h[i] = _s[i] + _h[i - 1] * p; // overflow is ok
			}
		}

		public long GetSubstringHash(int l, int r)
		{
			//System.Diagnostics.Debug.Assert(l >= 0 && l <= r && r < _s.Length);
			if (!(l >= 0 && l <= r && r < _s.Length)) throw new System.ArgumentOutOfRangeException("left or right");
			return _h[r] - (l == 0 ? 0 : _h[l - 1]) * _pows[r - l + 1];
		}
	}
}
