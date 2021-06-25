using ApplicationCore.Repositories.Account;
using Infrastructure.Constant;
using Infrastructure.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.ApiClient
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private readonly HttpClient httpClient;
        private readonly ITokenRepository tokenRepository;
        public WebApiExecuter(HttpClient httpClient, ITokenRepository tokenRepository)
        {
            this.httpClient = httpClient;
            this.tokenRepository = tokenRepository;
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> InvokeGet<T>(string uri)
        {
            await AddTokenHeader();
            var response = await httpClient.GetAsync(uri);
            var content = await response.Content.ReadFromJsonAsync<T>();
            return content;
        }

        public async Task<T> InvokePost<T>(string uri, T obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(uri, obj);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> InvokeLoginPost<T>(string uri, AuthenticateRequest obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(uri, obj);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<string> InvokePostReturnString<T>(string uri, T obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(uri, obj);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task InvokePut<T>(string uri, T obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PutAsJsonAsync(uri, obj);
        }

        public async Task<bool> InvokeDelete(string uri)
        {
            await AddTokenHeader();
            var response = await httpClient.DeleteAsync(uri);
            return response.IsSuccessStatusCode;
        }

        private async Task AddTokenHeader()
        {
            string token = tokenRepository != null ? await tokenRepository.GetToken() : string.Empty;

            if (!string.IsNullOrWhiteSpace(token))
            {
                httpClient.DefaultRequestHeaders.Remove(UserIdentityConstant.TOKEN_HEADER);
                httpClient.DefaultRequestHeaders.Add(UserIdentityConstant.TOKEN_HEADER, token);
            }
        }
    }
}
