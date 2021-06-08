using Infrastructure.Models;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Auth
{
    public interface IJwtTokenManager
    {
        AuthenticateResponse Authenticate(string userName, string password);
        UserIdentity GetUserInfoByToken(string token);
        string GetUserNameByToken(string token);
        string VerifyToken(string token);
    }
}