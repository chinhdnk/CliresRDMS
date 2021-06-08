using Infrastructure.Models;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Account
{
    public interface IAccountService
    {
        Task<string> ChangePassWord(ChangePasswordModel model);
        Task<string> GetUserInfoAsync(string token);
        Task<AuthenticateResponse> LoginAsync(string userName, string password);
        Task Logout();
    }
}