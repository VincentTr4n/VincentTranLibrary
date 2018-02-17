using System;
using System.Numerics;
using System.Diagnostics;
using System.Collections.Generic;
using VincentTran;
using VincentTran.Algorithms;
using VincentTran.Algorithms.Graphs;
using VincentTran.Helpers;
using VincentTran.IO;
using VincentTran.Utilities;
using VincentTran.Geometry;
using VincentTran.Cryptography;
using VincentTran.Facebook;
using VincentTran.Helpers.Strings;
using VincentTran.Algorithms.DataStructures;
using System.Linq;
using System.Collections;
using VincentTran.JudgeAPI;
using System.Threading.Tasks;
using VincentTran.MachineLearning;
using System.Xml;
using System.Net.Http;

namespace VincentTranTestConsole
{

	class SV : IComparable<SV>
	{
		public int a { get; set; }
		public int b { get; set; }

		public int CompareTo(SV other) => a.CompareTo(other.a) == 0 ? b.CompareTo(other.b) : a.CompareTo(other.a);
	}
	class Program
	{

		static void Main(string[] args)
		{
			int[] a = { 4, 2, 1, 7, 9, 8, 5, 3, 1, 0, -5, -19, 5, 2, 6, 7, 8, 2, 23, 5, 8, 3, 10, -20 };
			//Vector<int> v = new Vector<int>(a);
			//foreach (var item in temp)
			//{
			//	Console.WriteLine(item);
			//}

			//double b1, b0;
			//LinearRegression linear = new LinearRegression();
			//linear.LoadData("data1.csv");
			//linear.Solve(out b0, out b1);
			//Console.WriteLine("Y = "+b1+"*X"+(b0 < 0 ? " "+b0 : " +" + b0));
			//var res = 145 * b1 + b0;
			//Console.WriteLine(res);


			//var temp = System.IO.File.ReadAllLines("test-features.txt");
			//System.Text.StringBuilder builder = new System.Text.StringBuilder();
			//foreach (var item in temp)
			//{
			//	var str = item.Trim().Replace(' ', ',');
			//	builder.AppendLine(str);
			//}
			//System.IO.File.WriteAllText("test1.csv", "");
			//System.IO.File.WriteAllText("test1.csv", builder.ToString());


			NaiveBayes na = new NaiveBayes("data.csv", 700);
			var summarize = na.summarizeByClass(na.TrainingSet, 2);

			//foreach (var item in summarize)
			//{
			//	Console.WriteLine();
			//	foreach (var item2 in item)
			//	{
			//		Console.WriteLine(item2.First + " | " + item2.Second);
			//	}
			//}
			//Console.WriteLine("----------------------------------------------------------");
			Vector<int> pred = na.Predictions(summarize, na.TestSet);
			//foreach (var item in pred)
			//{
			//	Console.Write(item + " ");
			//}
			Console.WriteLine();
			Console.WriteLine("Accuracy : " + na.Accuracy(na.TestSet, pred).ToString("0.00") + "%");



			//foreach (var item in temp)
			//{
			//	Console.WriteLine(item);
			//}


			//Console.WriteLine(v.BinarySearch(23));
			//Console.WriteLine(v.Count);
			//Console.WriteLine(v.Capactity);

			//int[][] G =
			//{
			//	new int[] {0,1,0,0,0,0,1},
			//	new int[] {1,0,1,1,0,0,0},
			//	new int[] {0,1,0,0,0,0,0},
			//	new int[] {0,1,0,0,1,1,0},
			//	new int[] {0,0,0,1,0,0,0},
			//	new int[] {0,0,0,1,0,0,0},
			//	new int[] {1,0,0,0,0,0,0},
			//};
			//GraphSearch graph = new GraphSearch(G);
			//graph.recursiveDfs(0);

			//int[][] G1 = {  new int[]{0, 4, 0, 0, 0, 0, 0, 8, 0},
			//				new int[]{4, 0, 8, 0, 0, 0, 0, 11, 0},
			//				new int[]{0, 8, 0, 7, 0, 4, 0, 0, 2},
			//				new int[]{0, 0, 7, 0, 9, 14, 0, 0, 0},
			//				new int[]{0, 0, 0, 9, 0, 10, 0, 0, 0},
			//				new int[]{0, 0, 4, 14, 10, 0, 2, 0, 0},
			//				new int[]{0, 0, 0, 0, 0, 2, 0, 1, 6},
			//				new int[]{8, 11, 0, 0, 0, 0, 1, 0, 7},
			//				new int[]{0, 0, 2, 0, 0, 0, 6, 7, 0}
			//			};
			//GraphWithWeight GW = new GraphWithWeight(G1);
			//var test = GW.Dijkstra_PriorityQueue(0, 8);
			//Console.WriteLine(test);
			//Console.WriteLine(GW.Prim(3));

			//int[][] G2 =
			//{
			//	new int[]{0, 8, 12, 0, 0, 0, 0, 0, 0},
			//	new int[]{8, 0, 13, 25, 9, 0, 0, 0, 0},
			//	new int[]{12, 13, 0, 14, 0, 0, 21, 0, 0},
			//	new int[]{0, 25, 14, 0, 20, 8, 12, 12, 16},
			//	new int[]{0, 9, 0, 20, 0, 19, 0, 0, 0},
			//	new int[]{0, 0, 0, 8, 19, 0, 0, 11, 0},
			//	new int[]{0, 0, 21, 12, 0, 0, 0, 0, 11},
			//	new int[]{0, 0, 0, 12, 0, 11, 0, 0, 9},
			//	new int[]{0, 0, 0, 16, 0, 0, 11, 9, 0}
			//};
			//GW = new GraphWithWeight(G2);
			//Console.WriteLine(GW.Prim(4));
			//Console.WriteLine(GW.Kruskal());

			//Vector<SV> vector = new Vector<SV>();
			//vector.Add(new SV() {a=1,b=100 });
			//vector.Add(new SV() { a = 1, b = 100 });
			//vector.Add(new SV() { a = 2, b = 200 });
			//vector.Add(new SV() { a = 4, b = 300 });
			//vector.Add(new SV() { a = 10, b = 600 });
			//vector.Add(new SV() { a = 9, b = 1000 });
			//vector.Add(new SV() { a = 5, b = 1200 });

			//vector.Sort();
			//foreach (var item in vector)
			//{
			//	Console.WriteLine(item.a+" - "+item.b);
			//


			//GeneralGraph MG = new GeneralGraph(6);
			//MG.AddEdge(0, 1);
			//MG.AddEdge(1, 2);
			//MG.AddEdge(2, 0);
			//MG.AddEdge(3, 4);
			//MG.AddEdge(4, 5);
			//MG.AddEdge(5, 3);

			//int[] res;
			//Console.WriteLine(MG.GetMaximumMatching(out res));
			//foreach (var item in res)
			//{
			//	Console.WriteLine(item);
			//}



			//Console.WriteLine(graph.BFS());
			//var temp = graph.BFS(0, 5);
			//foreach (var item in temp) Console.Write(item+" ");


			//Vector<int> v = new Vector<int>();
			//v[6] = 25;
			//Console.WriteLine(v.Count + "|" + v.Capactity);




			//foreach (var item in v)
			//{
			//	Console.WriteLine(item);
			//}


			//Random rnd = new Random();
			//for (int i = 0; i < a.Length; i++)
			//{
			//	a[i] = rnd.Next(-100, 100);
			//}



			//var temp1 = (int[])a.Clone();
			//var temp2 = (int[])a.Clone();
			//var temp3 = (int[])a.Clone();

			//Stopwatch timer = new Stopwatch();
			//timer.Start();
			//SortAlgo<int>.QuickSort(a, 0, a.Length - 1);
			//timer.Stop();
			//Console.WriteLine("Time : " + timer.ElapsedMilliseconds / 1000.00 + "s");

			//timer.Start();
			//SortAlgo<int>.HeapSort(temp1);
			//timer.Stop();
			//Console.WriteLine("Time : " + timer.ElapsedMilliseconds / 1000.00 + "s");

			//timer.Start();
			//SortAlgo<int>.MergeSort(temp2, 0, temp1.Length - 1);
			//timer.Stop();
			//Console.WriteLine("Time : " + timer.ElapsedMilliseconds / 1000.00 + "s");

			//timer.Start();
			//SortAlgo<int>.TimSort(temp3,1<<10);
			//timer.Stop();
			//Console.WriteLine("Time : " + timer.ElapsedMilliseconds / 1000.00 + "s");

			//string a = "ababcab";
			//a = "abc@" + a;
			//foreach (var item in a.ToCharArray().ZAlgorithm())
			//{
			//	Console.Write(item + " ");
			//}
			//Console.WriteLine(a.ZAlgoSearch("abc")[0]);










			Console.ReadKey();
		}
	}
}

