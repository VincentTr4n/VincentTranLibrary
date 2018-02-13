using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentTran.Algorithms.Tests
{
	[TestClass()]
	public class HammingEncodingTests
	{
		[TestMethod()]
		public void GetHammingEndcodeTest()
		{
			string B = "01000010";
			Assert.AreEqual(B.GetHammingEndcode(), "010110010010");
		}

		[TestMethod()]
		public void DectectAndFixTest()
		{
			string B = "010110010110";
			Assert.AreEqual(HammingEncoding.DectectAndFix(B), "01000010|error:10");
		}
	}
}