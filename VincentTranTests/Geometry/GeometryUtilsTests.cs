using Microsoft.VisualStudio.TestTools.UnitTesting;
using VincentTran.Geometry;
using System;
using System.Collections.Generic;

namespace VincentTran.Geometry.Tests
{
	[TestClass()]
	public class GeometryUtilsTests
	{
		[TestMethod()]
		public void GeometryUtilsMustWork()
		{
			var points = new List<PointInt2D> { new PointInt2D(0, 0), new PointInt2D(4, 0), new PointInt2D(0, 4) };
			var doubledSquare = GeometryUtils.TriangleDoubledSquare(points[0], points[1], points[2]);
			var test = Math.Abs((points[1].X - points[0].X) * (points[2].Y - points[0].Y) - (points[2].X - points[0].X) * (points[1].Y - points[0].Y));
			Assert.AreEqual(doubledSquare, test);

			points = new List<PointInt2D> { new PointInt2D(0, 0), new PointInt2D(1, 0), new PointInt2D(-1, 0) };
			var sorted = GeometryUtils.SortByAngle(points, points[0]);
			Assert.AreEqual(points[0], sorted[0]);
			Assert.AreEqual(points[1], sorted[1]);
			Assert.AreEqual(points[2], sorted[2]);

			sorted = GeometryUtils.SortByAngle(points, points[1]);
			Assert.AreEqual(points[0], sorted[1]);
			Assert.AreEqual(points[1], sorted[0]);
			Assert.AreEqual(points[2], sorted[2]);

			sorted = GeometryUtils.SortByAngle(points, points[2]);
			Assert.AreEqual(points[0], sorted[1]);
			Assert.AreEqual(points[1], sorted[2]);
			Assert.AreEqual(points[2], sorted[0]);

			points = new List<PointInt2D> { new PointInt2D(0, 0), new PointInt2D(0, 5), new PointInt2D(1, 4), new PointInt2D(2, 4), new PointInt2D(4, 6), new PointInt2D(2, 2) };
			var res = new List<PointInt2D> { new PointInt2D(0, 0), new PointInt2D(2, 2), new PointInt2D(4, 6), new PointInt2D(0, 5) };
			var test1 = GeometryUtils.ConvexHull(points);
			for (int i = 0; i < res.Count; i++)
			{
				Assert.AreEqual(test1[i], res[i]);
			}

		}
	}
}