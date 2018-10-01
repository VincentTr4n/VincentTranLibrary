using System;
using System.Collections.Generic;
using System.Linq;
using VincentTran.Algorithms.DataStructures;

namespace VincentTran.MachineLearning
{
	public class NaiveBayes
	{
		public Vector<Vector<double>> TrainingSet { get; set; }
		public Vector<Vector<double>> TestSet { get; set; }
        public double[] c;

        public int Count = 2;

		public NaiveBayes()
		{
			TrainingSet = new Vector<Vector<double>>();
			TestSet = new Vector<Vector<double>>();
		}
		public NaiveBayes(string fileName, double limitTraining) : this() { LoadData(fileName, limitTraining); }
		public void LoadData(string fileName, double limitTraining)
		{
			var buffer = System.IO.File.ReadAllLines(fileName);
            int limit = (int)(buffer.Length * limitTraining);
            HashSet<double> set = new HashSet<double>();
			foreach (var item in buffer)
			{
				var values = item.Split(',');
				Vector<double> cur = new Vector<double>();
				foreach (var val in values) cur.Add(double.Parse(val));
                set.Add(cur[cur.Count - 1]);
				if (TrainingSet.Count < limit) TrainingSet.Add(cur);
				else TestSet.Add(cur);
			}
            Count = set.Count;
            c = set.ToArray();
		}
		public void LoadTest(string fileName)
		{
			var buffer = System.IO.File.ReadAllLines(fileName);
			foreach (var item in buffer)
			{
				var values = item.Split(',');
				Vector<double> cur = new Vector<double>();
				foreach (var val in values) cur.Add(double.Parse(val));
				TestSet.Add(cur);
			}
		}
		private double average(Vector<double> vector)
		{
			double res = 0;
			foreach (var item in vector) res += item;
			return (double)(res / vector.Count);
		}
		private double std(Vector<double> vector)
		{
			double avg = average(vector), variance = 0;
			foreach (var item in vector)
			{
				double temp = item - avg;
				variance += temp * temp;
			}
			variance /= (vector.Count - 1);
			return Math.Sqrt(variance);
		}

        private int getIndexClass(double x)
        {
            for (int i = 0; i < Count; i++)
            {
                if (x == c[i]) return i;
            }
            return 0;
        }
		private double calProbability(double x, double avg, double s)
		{
			double e = Math.Exp(-Math.Pow(x - avg, 2) / (2 * Math.Pow(s, 2)));
			return ((double)1.0 / (Math.Sqrt(2 * Math.PI) * s)) * e;
		}
		public Vector<Vector<Vector<double>>> separateByClass(Vector<Vector<double>> vector)
		{
			Vector<Vector<Vector<double>>> res = new Vector<Vector<Vector<double>>>(Count);
			for (int i = 0; i < Count; i++) res[i] = new Vector<Vector<double>>();
			foreach (var item in vector)
			{
				int last = item.Count - 1;
				double val = item[last];
				//if (res[val] == null) res[val] = new Vector<Vector<double>>();
				res[getIndexClass(val)].Add(item);
			}
			return res;
		}
		private Vector<Pair<double, double>> summarize(Vector<Vector<double>> vector)
		{
			Vector<Pair<double, double>> res = new Vector<Pair<double, double>>();
			int n = (vector.Count==0) ? 0 : vector[0].Count - 1 ;//vector[0].Count - 1;
			for (int i = 0; i < n; i++)
			{
				Vector<double> temp = new Vector<double>();
				foreach (var item in vector) temp.Add(item[i]);
				res.Add(new Pair<double, double>(average(temp), std(temp)));
			}
			return res;
		}
		public Vector<Vector<Pair<double, double>>> summarizeByClass(Vector<Vector<double>> vector)
		{
			var S = separateByClass(vector);
			Vector<Vector<Pair<double, double>>> res = new Vector<Vector<Pair<double, double>>>();
			foreach (var item in S) res.Add(summarize(item));
			return res;
		}
		public Vector<double> calculateClassProbabilities(Vector<Vector<Pair<double, double>>> summarize, Vector<double> input)
		{
			Vector<double> res = new Vector<double>(summarize.Count);
			for (int i = 0; i < summarize.Count; i++)
			{
				res[i] = 1.0;
				Vector<Pair<double, double>> vector = summarize[i];
				for (int j = 0; j < vector.Count; j++)
				{
					double avg = vector[j].First;
					double s = vector[j].Second;
					double x = input[j];
					res[i] *= calProbability(x, avg, s);
				}
				if (res[i] == 1) res[i] = double.MinValue;
			}
			return res;
		}
		private int predict(Vector<Vector<Pair<double, double>>> summarize, Vector<double> input)
		{
			var prob = calculateClassProbabilities(summarize, input);
			double max = prob.Max();
			int index = 0;
			for (int i = 0; i < prob.Count; i++) if (prob[i] == max) { index = i; break; }
			return index;
		}
		public Vector<double> Predictions(Vector<Vector<Pair<double, double>>> summarize, Vector<Vector<double>> vector)
		{
			Vector<double> res = new Vector<double>();
			foreach (var item in vector) res.Add(c[predict(summarize, item)]);
			return res;
		}
        public double Accuracy(Vector<Vector<double>> input, Vector<double> pred)
		{
			int acc = 0, last = input[0].Count - 1;
			for (int i = 0; i < pred.Count; i++) if (input[i][last] == pred[i]) acc++;
			return (double)((acc * 100.00) / pred.Count);
		}
	}
}
