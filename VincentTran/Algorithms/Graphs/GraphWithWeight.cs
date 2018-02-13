
using System;
using VincentTran.Algorithms.DataStructures;
using VincentTran.Helpers;

namespace VincentTran.Algorithms.Graphs
{
	public class GraphWithWeight
	{
		int[][] adjMatrix;
		int NumVertices = 0;
		bool[] visited;

		public int Count => NumVertices;
		public GraphWithWeight(int[][] input)
		{
			NumVertices = input.Length;
			visited = new bool[NumVertices];
			adjMatrix = new int[NumVertices][];
			for (int i = 0; i < NumVertices; i++) adjMatrix[i] = input[i];
		}

		public string Dijkstra(int start, int end)
		{
			if (start < 0 || end >= NumVertices) throw new Exception("Wrong input");
			int[] dist = new int[NumVertices];
			dist.Fill(int.MaxValue);
			dist[start] = 0;
			for (int i = 0; i < NumVertices - 1; i++)
			{
				int u = minDist(dist);
				visited[u] = true;
				for (int j = start; j < NumVertices; j++)
				{
					if (!visited[j] && adjMatrix[u][j] > 0 && dist[u] != int.MaxValue && dist[u] + adjMatrix[u][j] < dist[j]) dist[j] = dist[u] + adjMatrix[u][j];
				}
			}
			visited.Fill(false);
			string res = "";
			for (int i = start; i < end; i++) if (dist[i] != int.MaxValue) res += (i + "-" + dist[i] + "\n");
			return res += end + "-" + dist[end];
		}
		int minDist(int[] dist)
		{
			int min = int.MaxValue, index = -1;
			for (int i = 0; i < NumVertices; i++)
				if (!visited[i] && dist[i] <= min)
				{
					min = dist[i];
					index = i;
				}
			return index;
		}

		/// <summary>
		/// Dijkstra using Priority Queue
		/// </summary>
		public string Dijkstra_PriorityQueue(int start, int end)
		{
			if (start < 0 || end >= NumVertices) throw new Exception("Wrong input");
			int[] dist = new int[NumVertices];
			dist.Fill(int.MaxValue);

			PriorityQueue<Pair<int, int>> queue = new PriorityQueue<Pair<int, int>>(NumVertices);
			dist[start] = 0;
			queue.Push(new Pair<int, int>(0, start));

			while (queue.Count > 0)
			{
				int u = queue.PopMin().Second;
				for (int i = start; i < NumVertices; i++)
				{
					if (adjMatrix[u][i] > 0 && dist[u] + adjMatrix[u][i] < dist[i])
					{
						dist[i] = dist[u] + adjMatrix[u][i];
						queue.Push(new Pair<int, int>(dist[i], i));
					}
				}
			}
			string res = "";
			for (int i = start; i < end; i++) res += i + "-" + dist[i] + "\n";
			return res += end + "-" + dist[end];
		}

		public long Prim(int srouce)
		{
			long res = 0;
			PriorityQueue<Pair<int, int>> queue = new PriorityQueue<Pair<int, int>>(NumVertices);
			queue.Push(new Pair<int, int>(0, srouce));

			while (queue.Count > 0)
			{
				var pair = queue.PopMin();
				int u = pair.Second;
				if (visited[u]) continue;
				res += pair.First;
				visited[u] = true;
				for (int i = 0; i < NumVertices; i++) if (!visited[i] && adjMatrix[u][i] > 0) queue.Push(new Pair<int, int>(adjMatrix[u][i], i));
			}
			visited.Fill(false);
			return res;
		}

		public long Kruskal()
		{
			long res = 0;
			DisjointSetUnion disjoin = new DisjointSetUnion(NumVertices);
			Vector<Pair<int, Pair<int, int>>> P = ToVectorPair(adjMatrix);
			P.Sort();
			foreach (var item in P)
			{
				int x = item.Second.First;
				int y = item.Second.Second;
				if (disjoin.Join(x, y)) res += item.First;
			}

			return res;
		}

		public Vector<Pair<int, Pair<int, int>>> ToVectorPair(int[][] matrix)
		{
			Vector<Pair<int, Pair<int, int>>> res = new Vector<Pair<int, Pair<int, int>>>();
			for (int i = 0; i < NumVertices; i++)
			{
				visited[i] = true;
				for (int j = 0; j < NumVertices; j++)
					if (!visited[j] && matrix[i][j] > 0) res.Add(new Pair<int, Pair<int, int>>() { First = matrix[i][j], Second = new Pair<int, int>(i, j) });
			}
			visited.Fill(false);
			return res;
		}
	}
}
