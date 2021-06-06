using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.CliresSystem;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.CiresSystem
{
    public interface IPermissionRepository
    {
        Task<string> CreatePermission(Permission permission);
        Task<TblPermission> GetPermByID(string permId);
        Task<IEnumerable<Permission>> GetPermissionList();
        IQueryable<string> GetPermOfUser(string userName);
        Task<int> UpdatePermission(string PermID, Permission permission);
    }
}