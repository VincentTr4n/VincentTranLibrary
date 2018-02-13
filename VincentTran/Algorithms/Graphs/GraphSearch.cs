using VincentTran.Helpers;
using System.Collections;
using VincentTran.Algorithms.DataStructures;

namespace VincentTran.Algorithms.Graphs
{
	public class GraphSearch
	{
		public int[][] adjMatrix;
		int Root = 0;
		int NumNode = 0;
		bool[] visited;
		public GraphSearch(int[][] input)
		{
			NumNode = input.Length;
			visited = new bool[NumNode];
			adjMatrix = new int[NumNode][];
			for (int i = 0; i < NumNode; i++) adjMatrix[i] = input[i];
		}
		public string BFS()
		{
			string res = "";
			Queue queue = new Queue();
			queue.Enqueue(Root);
			visited[Root] = true;
			res += Root + "";

			while (queue.Count > 0)
			{
				int n, child;
				n = (int)queue.Peek();

				child = getUnvisited(0, n);
				if (child > -1)
				{
					visited[child] = true;
					res += "-" + child;
					queue.Enqueue(child);
				}
				else queue.Dequeue();
			}
			visited.Fill(false);
			return res;
		}
		public Vector<int> BFS(int start, int end)
		{
			Vector<int> res = new Vector<int>();
			int[] parent = new int[NumNode];
			parent.Fill(-1);

			Queue queue = new Queue();
			queue.Enqueue(start);
			visited[start] = true;

			while (queue.Count > 0)
			{
				int n, child;
				n = (int)queue.Peek();

				child = getUnvisited(start, n);
				if (child > -1)
				{
					visited[child] = true;
					queue.Enqueue(child);
					parent[child] = n;
				}
				else queue.Dequeue();
			}
			visited.Fill(false);

			FindPath(res, start, end, parent);
			return res;
		}

		public string DFS()
		{
			string res = "";
			Stack stack = new Stack();
			stack.Push(Root);

			while (stack.Count > 0)
			{
				int n = (int)stack.Pop();
				if (!visited[n])
				{
					visited[n] = true;
					res += "-" + n;
					for (int i = NumNode - 1; i >= 0; i--) if (adjMatrix[n][i] > 0) stack.Push(i);
				}
			}
			visited.Fill(false);
			return res;
		}
		public void recursiveDfs(int node)
		{
			visited[node] = true;
			System.Console.WriteLine(" "+node);
			for (int i = 0; i < NumNode; i++) if (adjMatrix[node][i] > 0 && !visited[i]) recursiveDfs(i);
		}
		int getUnvisited(int start, int n)
		{
			for (int i = start; i < NumNode; i++) if (adjMatrix[n][i] > 0 && !visited[i]) return i;
			return -1;
		}
		void FindPath(Vector<int> path, int start, int end, int[] parent)
		{
			if (start == end || end == -1) path.Add(start);
			else
			{
				FindPath(path, start, parent[end], parent);
				path.Add(end);
			}
		}
	}
}
