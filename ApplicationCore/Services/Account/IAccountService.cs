using Infrastructure.Models;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Account
{
    public interface IAccountService
    {
        Task<string> ChangePassWord(ChangePasswordModel model);
        Task<string> GetUserInfoAsync(string token);
        Task<string> LoginAsync(string userName, string password);
        Task<AuthenticateResponse> LoginAsync2(string userName, string password);
        Task Logout();
    }
}