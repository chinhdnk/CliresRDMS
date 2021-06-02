using Infrastructure.Entities.CliresSystem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<TblUser>> ViewUserAsync();
    }
}