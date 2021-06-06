using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.CiresSystem
{
    public interface IAccountRepository
    {
        Task<string> ChangePassword(ChangePasswordModel model);
        Task<TblAccount> CheckUserIdentity(string username, string password);
    }
}