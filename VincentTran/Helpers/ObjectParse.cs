using System;

namespace VincentTran.Helpers
{
	/// <summary>
	/// This class can parse a object to some other type
	/// </summary>
	public class ObjectParse
	{
		#region Temp TryParse
		static long tempLong;
		static int tempInt;
		static double tempDou;
		static float tempFloat;
		static DateTime tempDate = DateTime.Now;
		#endregion

		#region Parese
		public static long ParseLong(object obj)
			=> (obj == null) ? 0 : (Convert.ToString(obj).Trim() == "") ? 0 : (!long.TryParse(Convert.ToString(obj), out tempLong)) ? 0 : long.Parse(Convert.ToString(obj));

		public static double ParseDouble(object obj)
			=> (obj == null) ? 0 : (Convert.ToString(obj).Trim() == "") ? 0 : (!double.TryParse(Convert.ToString(obj), out tempDou)) ? 0 : double.Parse(Convert.ToString(obj));

		public static float ParseFloat(object obj)
			=> (obj == null) ? 0 : (Convert.ToString(obj).Trim() == "") ? 0 : (!float.TryParse(Convert.ToString(obj), out tempFloat)) ? 0 : float.Parse(Convert.ToString(obj));

		public static int ParseInt(object obj)
			=> (obj == null) ? 0 : (Convert.ToString(obj).Trim() == "") ? 0 : (!int.TryParse(Convert.ToString(obj), out tempInt)) ? 0 : int.Parse(Convert.ToString(obj));

		public static DateTime ParseDateTime(object obj)
			=> (obj == null) ? tempDate : (Convert.ToString(obj).Trim() == "") ? tempDate : (!DateTime.TryParse(Convert.ToString(obj), out tempDate)) ? DateTime.Now : DateTime.Parse(Convert.ToString(obj));

		#endregion
	}
}

