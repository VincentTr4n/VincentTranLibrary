using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Utilities.Matrix;
using System;

namespace VincentTran.Utilities.Tests
{
	[TestClass()]
	public class MatrixUtilsTests
	{
		[TestMethod()]
		public void ComputeDeterminantMustWork()
		{
			var rnd = new Random();
			for (int times = 0; times < 10000; ++times)
			{
				int n = rnd.Next(10) + 1;
				var a = new double[n, n];
				for (int i = 0; i < n; ++i)
					for (int j = 0; j < n; ++j)
						a[i, j] = rnd.Next(100);


				var byGauss = ((double[,])a.Clone()).ComputeDeterminant(n);
				var byNoDivisions = ((double[,])a.Clone()).ComputeDeterminantNoDivisions(n);

				long test = 10000000;
				Assert.AreEqual((int)byGauss / test, (int)byNoDivisions / test);
			}

			for (int times = 0; times < 1000; ++times)
			{
				int n = rnd.Next(20) + 1;
				var a = new double[n, n];
				for (int i = 0; i < n; ++i)
					for (int j = 0; j < n; ++j)
						a[i, j] = rnd.Next(10000) - 5000;

				double byGauss = ((double[,])a.Clone()).ComputeDeterminant(n);
				double byNoDivisions = ((double[,])a.Clone()).ComputeDeterminantNoDivisions(n);

				if (Math.Abs(byGauss - byNoDivisions) / Math.Abs(byGauss) > 1e-6)
				{
					Assert.IsTrue(Math.Abs(byGauss - byNoDivisions) < 1e-9);
				}

			}
		}

	}
}