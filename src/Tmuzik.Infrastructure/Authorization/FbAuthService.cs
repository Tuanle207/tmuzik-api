using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Tmuzik.Common.DependencyInjections;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Interfaces;

namespace Tmuzik.Infrastructure.Authorization
{
    public class FbAuthService : IFbAuthService, ISingletonDependency<IFbAuthService>
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";
        private const string UserInfoUrl  = "https://graph.facebook.com/me?fields=id,name,email,picture.width(720).height(720)&access_token={0}";
        private const string AppId  = "2964497603821160";
        private const string AppSecret  = "882bc4e7c23ff305ab7f523b125b38ec";
        private readonly IHttpClientFactory _httpClientFactory;

        public FbAuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken)
        {
            var url = string.Format(UserInfoUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(url);
            result.EnsureSuccessStatusCode();
            var responseAsString = await result.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<FacebookUserInfoResult>(responseAsString);
        }

        public async Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            var url = string.Format(TokenValidationUrl, accessToken, AppId, AppSecret);

            var result = await _httpClientFactory.CreateClient().GetAsync(url);
            result.EnsureSuccessStatusCode();
            var responseAsString = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<FacebookTokenValidationResult>(responseAsString);
        }
    }
}