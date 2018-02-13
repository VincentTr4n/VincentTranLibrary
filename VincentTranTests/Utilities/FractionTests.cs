﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Utilities;

namespace VincentTranTests.Utilities
{
	[TestClass]
	public class FractionTests
	{
		[TestMethod()]
		public void FractionTestsMustWork()
		{
			Fraction a = new Fraction(10, 5);
			Fraction b = new Fraction(10, 7);
			Fraction c = new Fraction(10, 6);
			Fraction d = new Fraction(10, 3);

			Assert.AreEqual(a, 2);
			Assert.AreEqual(b.ToString(), "10/7");
			Assert.IsTrue(d > c);
			Assert.AreEqual(5, c + d);
			Assert.AreEqual(new Fraction(50, 9), d * c);


			Fraction f;
			for (int i = -1000; i < 1001; i++)
			{
				f = i;

				Assert.AreEqual(i.ToString(), f.ToString());
				Assert.AreEqual(i, f);
			}

			f = new Fraction(1, 9);
			Assert.AreEqual("0.(1)", f.ToDecimalString());
			f = new Fraction(1, 3);
			Assert.AreEqual("0.(3)", f.ToDecimalString());
			f = new Fraction(1, 2);
			Assert.AreEqual("0.5", f.ToDecimalString());

			for (int p = -20; p < 21; p++)
			{
				for (int q = 1; q < 21; q++)
				{
					for (int p2 = -20; p2 < 21; p2++)
					{
						for (int q2 = 1; q2 < 21; q2++)
						{
							var f1 = new Fraction(p, q);
							var f2 = new Fraction(p2, q2);

							Assert.AreEqual(f1 + f2, new Fraction(p * q2 + q * p2, q * q2));
							Assert.AreEqual(f1 - f2, new Fraction(p * q2 - q * p2, q * q2));
							Assert.AreEqual(f1 * f2, new Fraction(p * p2, q * q2));
							if (p2 != 0)
								Assert.AreEqual(f1 / f2, new Fraction(p * q2, q * p2));
						}
					}
				}
			}
		}
	}
}
