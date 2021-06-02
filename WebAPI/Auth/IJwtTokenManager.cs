using Infrastructure.Models;

namespace WebAPI.Auth
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName, string password);
        AuthResult Authenticate2(string userName, string password);
        string GetUserInfoByToken(string token);
        bool VerifyToken(string token);
    }
}