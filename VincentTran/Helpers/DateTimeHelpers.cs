using System;
using System.Collections.Generic;
using System.Linq;

namespace VincentTran.Helpers
{
	/// <summary>
	/// This class can help you solve some problem related type of Datetime
	/// </summary>
	public static class DateTimeHelpers
	{
		/// <summary>
		/// Get all date bettween start Date and end Date
		/// </summary>
		/// <param name="startingDate"></param>
		/// <param name="endingDate"></param>
		/// <returns></returns>
		public static IEnumerable<DateTime> GetAllDates(this DateTime startingDate, DateTime endingDate)
		{
			List<DateTime> allDates = new List<DateTime>();

			for (DateTime i = startingDate; i <= endingDate; i = i.AddDays(1)) allDates.Add(i);
			return allDates.AsReadOnly();
		}
		/// <summary>
		/// Return End date of week from temp Date
		/// </summary>
		/// <param name="tempDate"></param>
		/// <param name="formatDateTime"></param>
		/// <returns></returns>
		public static DateTime GetEndDate(this DateTime tempDate)
		{
			DateTime EDate = new DateTime(tempDate.Year, tempDate.Month, DateTime.DaysInMonth(tempDate.Year, tempDate.Month));
			DateTime day1 = EDate;
			for (DateTime Nday = tempDate.AddDays(1); Nday <= EDate; Nday += TimeSpan.FromDays(1))
			{
				if (Nday.DayOfWeek == DayOfWeek.Monday)
				{
					day1 = Nday.AddDays(-1);
					break;
				}
			}
			return day1;
		}
		/// <summary>
		/// Count date between start Date and end Date
		/// </summary>
		/// <param name="startingDate"></param>
		/// <param name="endingDate"></param>
		/// <returns></returns>
		public static int DateDiff(this DateTime startingDate, DateTime endingDate) => (startingDate > endingDate) ? -1 : startingDate.GetAllDates(endingDate).Count() - 1;
	}
}
