using System.Collections.Generic;
using System.Threading.Tasks;

namespace VincentTran.Facebook
{
    public interface IFacebookService
    {
		#region Methods of interface
		Task<FacebookAccount> GetAccountAsync(string accessToken);
		Task PostOnWallAsync(string accessToken, string message); 
		#endregion
	}

    public class FacebookService : IFacebookService
    {
        private readonly IFacebookProvider _facebookProvider;

        public FacebookService(IFacebookProvider facebookClient)
        {
            _facebookProvider = facebookClient;
        }
		/// <summary>
		/// Get infomation your account
		/// </summary>
		/// <param name="accessToken"></param>
		/// <returns></returns>
        public async Task<FacebookAccount> GetAccountAsync(string accessToken)
        {
            var result = await _facebookProvider.GetAsync<dynamic>(
                accessToken, "me", "fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale");

            if (result == null)
            {
                return new FacebookAccount();
            }

            var account = new FacebookAccount
            {
                Id = result.id,
                Email = result.email,
                Name = result.name,
                UserName = result.username,
                FirstName = result.first_name,
                LastName = result.last_name,
                Locale = result.locale,
				Gender = result.gender
            };

            return account;
        }
		/// <summary>
		/// Get List your friends but you must call method WaitAll of Task object to get result
		/// </summary>
		/// <param name="accessToken"></param>
		/// <returns></returns>
		public async Task<List<FacebookFriends>> GetFriends(string accessToken)
		{
			var result = await _facebookProvider.GetAsync<dynamic>(
				accessToken, "me/friends");

			if (result == null)
			{
				return null;
			}
			List<FacebookFriends> mlist = new List<FacebookFriends>();
			var temp = (IEnumerable<dynamic>)(result.data);
			foreach(var item in temp)
			{
				mlist.Add(new FacebookFriends() { Id = item.id, Name = item.name });
			}
			return mlist;
		}
		/// <summary>
		/// Get List liked of you but must call method WaitAll of Task object to get result
		/// </summary>
		/// <param name="accessToken"></param>
		/// <returns></returns>
		public async Task<List<FacebookLiked>> GetLiked(string accessToken)
		{
			var result = await _facebookProvider.GetAsync<dynamic>(
				accessToken, "me/likes");

			if (result == null)
			{
				return null;
			}
			List<FacebookLiked> mlist = new List<FacebookLiked>();
			foreach (var item in (IEnumerable<dynamic>)(result.data))
			{
				mlist.Add(new FacebookLiked() { ID = item.id, Name = item.name });
			}
			return mlist;
		}
		/// <summary>
		/// Post a status on facebook but you must call method WaitAll of Task object
		/// </summary>
		/// <param name="accessToken"></param>
		/// <returns></returns>
		public async Task PostOnWallAsync(string accessToken, string message)
            => await _facebookProvider.PostAsync(accessToken, "me/feed", new {message});
    }  
}