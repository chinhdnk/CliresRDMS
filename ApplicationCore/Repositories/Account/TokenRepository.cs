﻿using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.Account
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IJSRuntime iJSRuntime;

        public TokenRepository(IJSRuntime iJSRuntime)
        {
            this.iJSRuntime = iJSRuntime;
        }

        public async Task SetToken(string token)
        {
            await iJSRuntime.InvokeVoidAsync("sessionStorage.setItem", "token", token);
        }

        public async Task<string> GetToken()
        {
            return await iJSRuntime.InvokeAsync<string>("sessionStorage.getItem", "token");
        }
    }
}
