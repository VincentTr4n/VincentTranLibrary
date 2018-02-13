using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace VincentTran.JudgeAPI
{
	public interface IJudgeRequest
	{
		Task<T> GetAsync<T>(string endpoint);
		Task<T> PostAsync<T>(string endpoint, object data);
	}
	public class JudgeRequest : IJudgeRequest
	{
		private readonly HttpClient _httpClient;
		public JudgeRequest(string uri)
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(uri)
			};
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
		public JudgeRequest() : this("https://api.judge0.com/") { }

		public async Task<T> GetAsync<T>(string endpoint)
		{
			var response = await _httpClient.GetAsync($"{endpoint}");
			if (!response.IsSuccessStatusCode) return default(T);

			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(result);
		}

		public async Task<T> PostAsync<T>(string endpoint, object data)
		{
			var response = await _httpClient.PostAsync($"{endpoint}", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
			if (!response.IsSuccessStatusCode) return default(T);
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(result);
		}

	}
}
