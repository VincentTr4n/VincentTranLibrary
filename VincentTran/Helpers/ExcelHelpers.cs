using System;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace VincentTran.Helpers
{
	/// <summary>
	/// This class can work with excel and supports following settings:
	/// 1) Can work with a DataTable
	/// 2) You can develop any more
	/// </summary>
	public class ExcelHelpers
	{
		#region Elements
		public Excel.Application app;
		Excel.Worksheet exSheet;
		Excel.Workbook exBook;
		#endregion

		#region Setting
		public ExcelHelpers()
		{
			app = new Excel.Application();
		}
		private void SetWorkSpace(int sheetNumbers)
		{
			exBook = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
			exSheet = (Excel.Worksheet)exBook.Worksheets[sheetNumbers];
		}
		public void Quit()
		{
			app.Quit();
		}
		#endregion

		#region Excel tools
		Excel.Range setRange(int x, int y, string between, int size, dynamic style, dynamic color, string caption)
		{
			Excel.Range range = (Excel.Range)exSheet.Cells[y, x];
			if (!String.IsNullOrEmpty(between)) exSheet.get_Range(between).Merge(true);
			range.Font.Size = size;
			range.Font.Color = color;
			if (style != null) range.Font.FontStyle = style;
			range.Value = caption;
			range.WrapText = null;
			return range;
		}
		//
		// Using Data Table
		void setTable(DataTable table, int name, int index)
		{
			StringBuilder build = new StringBuilder();
			for (int i = 0; i <= table.Columns.Count; i++) build.Append((char)('A' + i));
			string dis1 = build[0].ToString() + index + ":" + build[build.Length - 1].ToString() + index;
			exSheet.get_Range(dis1).Font.Bold = true;
			exSheet.get_Range(dis1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			for (int i = 0; i < table.Columns.Count; i++)
			{
				if (i == 0) exSheet.get_Range(build[0].ToString() + index).Value = "NO";
				exSheet.get_Range(build[i + 1].ToString() + index).Value = table.Columns[i].ColumnName;
				if (i == name) exSheet.get_Range(build[i].ToString() + index).ColumnWidth = 30;
				else exSheet.get_Range(build[i + 1].ToString() + index).ColumnWidth = 20;
			}
			DataRow row;
			for (int i = 0; i < table.Rows.Count; i++)
			{
				row = table.Rows[i];
				string dis2 = build[0].ToString() + (index + i + 1) + ":" + build[build.Length - 1].ToString() + (index + i + 1);
				exSheet.get_Range(dis2).Font.Bold = false;
				for (int j = 0; j < table.Columns.Count; j++)
				{
					if (j == 0) exSheet.get_Range(build[0].ToString() + (index + i + 1)).Value = (i + 1).ToString();
					exSheet.get_Range(build[j + 1].ToString() + (index + i + 1)).Value = row[j].ToString();
				}
			}

		} 
		#endregion
	}
}
