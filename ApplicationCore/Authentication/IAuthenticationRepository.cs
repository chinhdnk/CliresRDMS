using System.Threading.Tasks;

namespace ApplicationCore.Authentication
{
    public interface IAuthenticationRepository
    {
        Task<string> GetUserInfoAsync(string token);
        Task<string> LoginAsync(string userName, string password);
    }
}