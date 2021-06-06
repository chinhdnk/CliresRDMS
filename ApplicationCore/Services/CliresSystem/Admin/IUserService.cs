using Infrastructure.Entities.CliresSystem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public interface IUserService
    {
        Task<IEnumerable<TblUser>> ViewUserAsync();
    }
}