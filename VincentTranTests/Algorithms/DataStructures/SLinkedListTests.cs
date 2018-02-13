using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentTran.Algorithms.DataStructures.Tests
{
	[TestClass()]
	public class SLinkedListTests
	{
		[TestMethod()]
		public void SLinkedListMustWork()
		{
			int n = 1000;
			Random rnd = new Random();
			SLinkedList<int> mlist = new SLinkedList<int>();
			int[] test1 = new int[n];
			for (int i = 0; i < n; i++)
			{
				mlist.PushBack(rnd.Next(-20,20));
				test1[i] = mlist.Trailer.Value;
			}

			Assert.AreEqual(mlist.Size, n);
			Assert.AreEqual(test1[0], mlist.Header.Value);
			Assert.AreEqual(test1[n - 1], mlist.Trailer.Value);

			var test2 = mlist.ToList();
			for (int i = 0; i < n; i++)
			{
				Assert.AreEqual(test1[i], test2[i]);
			}
		}
	}
}