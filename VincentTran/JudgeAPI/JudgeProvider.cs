
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace VincentTran.JudgeAPI
{
	public interface IJudgeProvider
	{
		Task<IEnumerable<JudgeStatus>> GetListAllStatuses();
		Task<IEnumerable<JudgeLanguage>> GetListAllLanguages();
		Task<ResultSubmit> RequestSubmission(DetailSubmit detail);

	}
	public class JudgeProvider : IJudgeProvider
	{
		private readonly IJudgeRequest _judgeRequest;
		public JudgeProvider()
		{
			_judgeRequest = new JudgeRequest();
		}
		public async Task<IEnumerable<JudgeLanguage>> GetListAllLanguages()
		{
			var result = await _judgeRequest.GetAsync<JudgeLanguage[]>("languages");
			if (result == null) return null;
			return result.AsEnumerable();
		}

		public async Task<IEnumerable<JudgeStatus>> GetListAllStatuses()
		{
			var result = await _judgeRequest.GetAsync<JudgeStatus[]>("statuses");
			if (result == null) return null;
			return result.AsEnumerable();
		}

		public async Task<ResultSubmit> RequestSubmission(DetailSubmit detail)
		{
			var result = await _judgeRequest.PostAsync<ResultSubmit>("submissions?wait=true", detail);
			if (result == null) return null;
			return result;
		}
	}
}
