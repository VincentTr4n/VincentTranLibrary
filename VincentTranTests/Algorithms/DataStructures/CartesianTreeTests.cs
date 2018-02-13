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
	public class CartesianTreeTests
	{
		[TestMethod()]
		public void CartesianTreeMustWork()
		{
			var rnd = new Random(123);
			int[] pr = new int[1000000];
			for (int i = 0; i < 1000000; ++i)
			{
				pr[i] = i;
				int u = rnd.Next(i + 1);
				int tmp = pr[i];
				pr[i] = pr[u];
				pr[u] = tmp;
			}
			int prid = 0;

			CartesianTree tree = null;
			var list = new List<int>();
			for (int i = 0; i < 2000; ++i)
			{
				var value = rnd.Next();
				var pos = rnd.Next(list.Count + 1);

				CartesianTree.Insert(ref tree, value, pr[prid++], pos);
				list.Insert(pos, value);

				var testList = new List<int>();
				CartesianTree.Dfs(tree, t => testList.Add(t.Data));

				Assert.AreEqual(list.Count, testList.Count);
				for (int j = 0; j < list.Count; ++j)
					Assert.AreEqual(list[j], testList[j]);
			}

			for (int i = 0; i < list.Count; ++i)
			{
				Assert.AreEqual(list[i], CartesianTree.Find(tree, i).Data);
			}

			for (int i = 0; i < 2000; ++i)
			{
				var pos = rnd.Next(list.Count);

				CartesianTree.Erase(ref tree, pos);
				list.RemoveAt(pos);

				var testList = new List<int>();
				CartesianTree.Dfs(tree, t => testList.Add(t.Data));

				Assert.AreEqual(list.Count, testList.Count);
				for (int j = 0; j < list.Count; ++j)
					Assert.AreEqual(list[j], testList[j]);
			}
		}
	}
}