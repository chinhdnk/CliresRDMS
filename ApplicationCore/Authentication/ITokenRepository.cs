using System.Threading.Tasks;

namespace ApplicationCore.Authentication
{
    public interface ITokenRepository
    {
        Task<string> GetToken();
        Task SetToken(string token);
    }
}