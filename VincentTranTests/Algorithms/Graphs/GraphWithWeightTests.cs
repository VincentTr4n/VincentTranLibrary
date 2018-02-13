using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VincentTran.Algorithms.Graphs.Tests
{
	[TestClass()]
	public class GraphWithWeightTests
	{
		[TestMethod()]
		public void GraphWithWeightMustWork()
		{
			int[][] G =
			{
				new int[]{0, 8, 12, 0, 0, 0, 0, 0, 0},
				new int[]{8, 0, 13, 25, 9, 0, 0, 0, 0},
				new int[]{12, 13, 0, 14, 0, 0, 21, 0, 0},
				new int[]{0, 25, 14, 0, 20, 8, 12, 12, 16},
				new int[]{0, 9, 0, 20, 0, 19, 0, 0, 0},
				new int[]{0, 0, 0, 8, 19, 0, 0, 11, 0},
				new int[]{0, 0, 21, 12, 0, 0, 0, 0, 11},
				new int[]{0, 0, 0, 12, 0, 11, 0, 0, 9},
				new int[]{0, 0, 0, 16, 0, 0, 11, 9, 0}
			};
			GraphWithWeight graph = new GraphWithWeight(G);

			var test1 = graph.Dijkstra_PriorityQueue(4, 7);
			var test2 = graph.Dijkstra(4, 7);
			Assert.AreEqual(test1, test2);

			test1 = graph.Dijkstra_PriorityQueue(1, 6);
			test2 = graph.Dijkstra(1, 6);
			Assert.AreEqual(test1, test2);

			for (int i = 0; i < G.Length; i++)
			{
				Assert.AreEqual(graph.Prim(i), graph.Kruskal());
			}
		}
	}
}