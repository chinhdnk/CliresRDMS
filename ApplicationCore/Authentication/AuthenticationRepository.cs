using ApplicationCore.Repositories.ApiClient;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IWebApiExecuter webApiExecuter;
        private readonly ITokenRepository tokenRepository;

        public AuthenticationRepository(IWebApiExecuter webApiExecuter, ITokenRepository tokenRepository)
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

        public async Task<AuthResult> LoginAsync2(string userName, string password)
        {
            AuthResult authResult = await this.webApiExecuter.InvokeLoginPost<AuthResult>("login", new UserLoginModel { UserName = userName, Password = password });
            if (!string.IsNullOrWhiteSpace(authResult.Token) || authResult.Token != "\"\"") 
                await tokenRepository.SetToken(authResult.Token);

            return authResult;
        }

        public async Task<string> GetUserInfoAsync(string token)
        {
            var userName = await this.webApiExecuter.InvokePostReturnString("getuserinfo", new { token = token });
            if (string.IsNullOrWhiteSpace(userName) || userName == "\"\"") return null;

            return userName;
        }
    }
}
