namespace WebAPI.Auth
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName, string password);
        string GetUserInfoByToken(string tokenString);
        bool VerifyToken(string token);
    }
}