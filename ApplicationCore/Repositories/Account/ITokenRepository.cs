using System.Threading.Tasks;

namespace ApplicationCore.Repositories.Account
{
    public interface ITokenRepository
    {
        Task<string> GetToken();
        Task SetToken(string token);
    }
}