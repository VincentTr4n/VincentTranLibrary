using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VincentTran.Facebook
{
    public interface IFacebookProvider
    {
		#region Methods of interface
		Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);
		Task PostAsync(string accessToken, string endpoint, object data, string args = null); 
		#endregion
	}

    public class FacebookProvider : IFacebookProvider
    {
        private readonly HttpClient _httpClient;

		#region Constructor
		public FacebookProvider(string uri)
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(uri)
			};
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
		public FacebookProvider() : this("https://graph.facebook.com/v2.11/") { } 
		#endregion

		#region GET/POST
		public async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
		{
			var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}&{args}");
			if (!response.IsSuccessStatusCode)
				return default(T);

			var result = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(result);
		}

		public async Task PostAsync(string accessToken, string endpoint, object data, string args = null)
		{
			var content = GetContent(data);
			await _httpClient.PostAsync($"{endpoint}?access_token={accessToken}&{args}", content);
		} 
		#endregion

		/// <summary>
		/// Get content data type of Json
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>

		private static StringContent GetContent(object data)
        {
            var json = JsonConvert.SerializeObject(data);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}
    }
}