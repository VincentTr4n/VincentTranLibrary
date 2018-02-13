using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace VincentTran.Helpers.Tests
{
	[TestClass()]
	public class BitHelpersTests
	{
		[TestMethod()]
		public void ToBinaryTest()
		{
			string A = "01000001";
			Assert.AreEqual(A, 65.ToBinary());
		}
		[TestMethod()]
		public void BitHelpersMustWork()
		{
			var powers = new[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };
			for (int i = -10; i <= 110; i++)
			{
				bool isPowerOfTwo = powers.Contains(i);
				Assert.AreEqual(isPowerOfTwo, i.IsPowerOfTwo());

				Assert.AreEqual(isPowerOfTwo, ((long)i).IsPowerOfTwo());
			}

			for (int i = 0; i < 63; ++i)
			{
				Assert.IsTrue((1L << i).IsPowerOfTwo());
			}
		}
	}
}