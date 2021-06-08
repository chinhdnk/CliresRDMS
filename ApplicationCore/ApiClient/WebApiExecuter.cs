using Infrastructure.Constant;
using Infrastructure.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.ApiClient
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private readonly string baseUrl;
        private readonly HttpClient httpClient;
        private readonly ITokenRepository tokenRepository;
        public WebApiExecuter(string baseUrl, HttpClient httpClient, ITokenRepository tokenRepository)
        {
            this.baseUrl = baseUrl;
            this.httpClient = httpClient;
            this.tokenRepository = tokenRepository;
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> InvokeGet<T>(string uri)
        {
            await AddTokenHeader();
            var response = await httpClient.GetAsync(GetUrl(uri));
            await HandleError(response);
            var content = await response.Content.ReadFromJsonAsync<T>();
            return content;
        }

        public async Task<T> InvokePost<T>(string uri, T obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> InvokeLoginPost<T>(string uri, AuthenticateRequest obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<string> InvokePostReturnString<T>(string uri, T obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task InvokePut<T>(string uri, T obj)
        {
            await AddTokenHeader();
            var response = await httpClient.PutAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);
        }

        public async Task<bool> InvokeDelete(string uri)
        {
            await AddTokenHeader();
            var response = await httpClient.DeleteAsync(GetUrl(uri));
            await HandleError(response);
            return true;
        }
        private async Task HandleError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var statuscode = response.StatusCode;
                //navManager.NavigateTo("/error" + "/" + statuscode);
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(error);
            }
        }

        private string GetUrl(string uri)
        {
            return $"{baseUrl}/{uri}";
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
