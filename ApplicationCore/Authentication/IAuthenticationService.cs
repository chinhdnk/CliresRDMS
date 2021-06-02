﻿using Infrastructure.Models;
using System.Threading.Tasks;

namespace ApplicationCore.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> GetUserInfoAsync(string token);
        Task<string> LoginAsync(string userName, string password);
        Task<AuthResult> LoginAsync2(string userName, string password);
        Task Logout();
    }
}