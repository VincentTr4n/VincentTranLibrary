
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VincentTran.JudgeAPI
{
	public class JudgeService
	{
		private static readonly IJudgeProvider _judgeProvider = new JudgeProvider();
		public static IEnumerable<JudgeStatus> GetListAllStatuses()
		{
			var data = _judgeProvider.GetListAllStatuses();
			Task.WaitAll(data);
			return data.Result;
		}
		public static IEnumerable<JudgeLanguage> GetListAllLanguages()
		{
			var data = _judgeProvider.GetListAllLanguages();
			Task.WaitAll(data);
			return data.Result;
		}
		public static ResultSubmit RequestSubmission(DetailSubmit detail)
		{
			var data = _judgeProvider.RequestSubmission(detail);
			Task.WaitAll(data);
			return data.Result;
		}
	}
}
