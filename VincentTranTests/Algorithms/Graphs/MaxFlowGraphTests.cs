using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Algorithms.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentTran.Algorithms.Graphs.Tests
{
	[TestClass()]
	public class MaxFlowGraphTests
	{
		[TestMethod()]
		public void MaxFlowTest()
		{
			MaxFlowGraph G = new MaxFlowGraph(6);
			G.AddUndirectedEdge(0, 1, 10);
			G.AddUndirectedEdge(0, 2, 8);
			G.AddUndirectedEdge(1, 2, 2);
			G.AddUndirectedEdge(1, 3, 8);
			G.AddUndirectedEdge(2, 3, 6);
			G.AddUndirectedEdge(2, 4, 7);
			G.AddUndirectedEdge(3, 5, 10);
			G.AddUndirectedEdge(4, 5, 10);

			var res = G.MaxFlow(0, 5);
			Assert.AreEqual(17, res);

			G = new MaxFlowGraph(6);
			G.AddUndirectedEdge(0, 1, 10);
			G.AddUndirectedEdge(0, 2, 8);
			G.AddUndirectedEdge(1, 2, 2);
			G.AddUndirectedEdge(1, 3, 5);
			G.AddUndirectedEdge(2, 4, 10);
			G.AddUndirectedEdge(3, 5, 7);
			G.AddUndirectedEdge(4, 3, 8);
			G.AddUndirectedEdge(4, 5, 10);

			res = G.MaxFlow(0, 5);
			Assert.AreEqual(15, res);
		}
	}
}