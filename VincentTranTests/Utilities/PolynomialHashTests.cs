using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentTran.Utilities.Tests
{
	[TestClass()]
	public class PolynomialHashTests
	{
		[TestMethod()]
		public void StringHashMustWork()
		{
			var rnd = new Random();
			for (int times = 0; times < 1000; times++)
			{
				var len = rnd.Next(20) + 1;
				var s = "";
				for (int i = 0; i < len; i++)
				{
					s += (char)('a' + rnd.Next(3));
				}
				long p = 1997;
				var h = new PolynomialHash(s, p);
				for (int i = 0; i < len; i++)
				{
					for (int j = 0; j < i + 1; j++)
					{
						long brute = 0;
						for (int k = j; k <= i; k++)
						{
							brute = brute * p + s[k];
						}
						Assert.AreEqual(brute, h.GetSubstringHash(j, i));
					}
				}
			}
		}
	}
}