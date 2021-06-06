using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface ITokenRepository
    {
        Task<string> GetToken();
        Task SetToken(string token);
    }
}