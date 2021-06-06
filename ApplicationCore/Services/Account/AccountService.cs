using ApplicationCore.Repositories;
using ApplicationCore.Repositories.ApiClient;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IWebApiExecuter webApiExecuter;
        private readonly ITokenRepository tokenRepository;

        public AccountService(IWebApiExecuter webApiExecuter, ITokenRepository tokenRepository)
        {
            this.webApiExecuter = webApiExecuter;
            this.tokenRepository = tokenRepository;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var token = await this.webApiExecuter.InvokePostReturnString("authenticate", new { userName = userName, password = password });
            if (string.IsNullOrWhiteSpace(token) || token == "\"\"")
                return null;

            await tokenRepository.SetToken(token);
            return token;
        }

        public async Task<AuthenticateResponse> LoginAsync2(string userName, string password)
        {
            AuthenticateResponse authenticateResponse = await this.webApiExecuter.InvokeLoginPost<AuthenticateResponse>("login", new AuthenticateRequest { UserName = userName, Password = password });
            if (!string.IsNullOrWhiteSpace(authenticateResponse.Token) || authenticateResponse.Token != "\"\"")
                await tokenRepository.SetToken(authenticateResponse.Token);

            return authenticateResponse;
        }

        public async Task<string> GetUserInfoAsync(string token)
        {
            var userName = await this.webApiExecuter.InvokePostReturnString("getusername", new { token = token });
            if (string.IsNullOrWhiteSpace(userName) || userName == "\"\"") return null;

            return userName;
        }

        public async Task<string> ChangePassWord(ChangePasswordModel model)
        {
            var result = await this.webApiExecuter.InvokePostReturnString("changepassword", model);
            return result;
        }

        public async Task Logout()
        {
            await tokenRepository.SetToken(string.Empty);
        }
    }

}
