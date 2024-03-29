﻿using ApplicationCore.Repositories.Account;
using ApplicationCore.Repositories.ApiClient;
using Infrastructure.Models;
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

        public async Task<AuthenticateResponse> LoginAsync(string userName, string password)
        {
            AuthenticateResponse authenticateResponse = await this.webApiExecuter.InvokeLoginPost<AuthenticateResponse>("authenticate", new AuthenticateRequest { UserName = userName, Password = password });
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
