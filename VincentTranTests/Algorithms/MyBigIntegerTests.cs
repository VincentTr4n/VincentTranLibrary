using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Utilities;

namespace VincentTran.Algorithms.Tests
{
	[TestClass()]
	public class MyBigIntegerTests
	{
		[TestMethod()]
		public void MyBigIntegerTest()
		{
			var temp1 = (MyBigInteger)"2000000000000000000000000000000000000000000000";
			var temp2 = (MyBigInteger)"10";

			var res = temp1 * temp2;
			Assert.AreEqual(res.ToString(), "20000000000000000000000000000000000000000000000");

			var res1 = temp1 * 10;
			Assert.AreEqual(res.ToString(), "20000000000000000000000000000000000000000000000");

			var res2 = temp1 / 10;
			Assert.AreEqual(res2.ToString(), "200000000000000000000000000000000000000000000");

			var res3 = temp1 + temp2;
			Assert.AreEqual(res3.ToString(), "2000000000000000000000000000000000000000000010");

			var res4 = res3 - 10;
			Assert.AreEqual(res2.ToString(), "200000000000000000000000000000000000000000000");

			Assert.AreEqual((MyBigInteger)1, (MyBigInteger)"1");
			Assert.AreEqual((MyBigInteger)12, (MyBigInteger)"12");
			Assert.AreEqual((MyBigInteger)123, (MyBigInteger)"123");
			Assert.AreEqual((MyBigInteger)1234, (MyBigInteger)"1234");
			Assert.AreEqual((MyBigInteger)12345, (MyBigInteger)"12345");

			Assert.AreEqual((MyBigInteger)(-1), (MyBigInteger)"-1");
			Assert.AreEqual((MyBigInteger)(-12), (MyBigInteger)"-12");
			Assert.AreEqual((MyBigInteger)(-123), (MyBigInteger)"-123");
			Assert.AreEqual((MyBigInteger)(-1234), (MyBigInteger)"-1234");
			Assert.AreEqual((MyBigInteger)(-12345), (MyBigInteger)"-12345");

			Assert.AreEqual((MyBigInteger)1, new MyBigInteger(1));
			Assert.AreEqual((MyBigInteger)12, new MyBigInteger(12));
			Assert.AreEqual((MyBigInteger)123, new MyBigInteger(123));
			Assert.AreEqual((MyBigInteger)1234, new MyBigInteger(1234));
			Assert.AreEqual((MyBigInteger)12345, new MyBigInteger(12345));

			Assert.AreEqual(new MyBigInteger(-1), (MyBigInteger)"-1");
			Assert.AreEqual(new MyBigInteger(-12), (MyBigInteger)"-12");
			Assert.AreEqual(new MyBigInteger(-123), (MyBigInteger)"-123");
			Assert.AreEqual(new MyBigInteger(-1234), (MyBigInteger)"-1234");
			Assert.AreEqual(new MyBigInteger(-12345), (MyBigInteger)"-12345");
		}
		[TestMethod()]
		public void MyBigIntegerCompareTest()
		{
			var temp1 = (MyBigInteger)"2000000000000000000000000000000000000000000000";
			var temp2 = (MyBigInteger)"10";

			Assert.IsTrue(temp1 > temp2);
			Assert.IsTrue(temp1 != temp2);

			Assert.IsFalse(temp1 < temp2);
			Assert.IsFalse(temp1 == temp2);
		}
	}
}