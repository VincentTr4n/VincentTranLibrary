using System.Linq;
using VincentTran.Algorithms.DataStructures;

namespace VincentTran.MachineLearning
{
	public class LinearRegression
	{
		public Vector<double> VX { get; private set; }
		public Vector<double> VY { get; private set; }
		public LinearRegression()
		{
			VX = new Vector<double>();
			VY = new Vector<double>();
		}
		public void LoadData(string fileName)
		{
			var buffer = System.IO.File.ReadAllLines(fileName);
			foreach (var item in buffer)
			{
				var temp = item.Split(',');
				VX.Add(double.Parse(temp[0]));
				VY.Add(double.Parse(temp[1]));
			}
		}
		/// <summary>
		/// Math equation linear : Y = B1*X + B0
		/// </summary>
		public void Solve(out double B0,out double B1)
		{
			double xbar = VX.Sum() / VX.Count;
			double ybar = VY.Sum() / VY.Count;
			double sumX2 = VX.Sum(t => t * t);
			double xxbar = 0, yybar = 0, xybar = 0;
			for (int i = 0; i < VX.Count; i++)
			{
				xxbar += (VX[i] - xbar) * (VX[i] - xbar);
				yybar += (VY[i] - ybar) * (VY[i] - ybar);
				xybar += (VX[i] - xbar) * (VY[i] - ybar);
			}
			B1 = xybar/xxbar;
			B0 = ybar - B1*xbar;
		}
	}
}