using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Algorithms.DataStructures;
using System;
using VincentTran.Helpers.Strings;
using System.Collections.Generic;

namespace VincentTran.Algorithms.DataStructures.Tests
{
	[TestClass()]
	public class HashTblTests
	{
		[TestMethod()]
		public void HashTblMustWork()
		{
			int n = 1000;
			RandomStringGenerator rnd = new RandomStringGenerator(true, true, true, false);

			HashTbl<int, string> table = new HashTbl<int, string>(n);
			Dictionary<int, string> dic = new Dictionary<int, string>();

			for (int i = 0; i < n; i++)
			{
				int key = i;
				string item = rnd.Generate(10);
				table.Add(key, item);
				dic.Add(key, item);
			}


			Assert.AreEqual(table.GetItem(100), dic[100]);
		}
	}
}