using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ApplicationCore.Repositories.CliresSystem
{
    public interface IUserRepository
    {
        Task<IEnumerable<TblUser>> GetUserList();
    }
}