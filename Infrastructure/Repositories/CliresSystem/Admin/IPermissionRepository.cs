using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CiresSystem
{
    public interface IPermissionRepository
    {
        TblPermission Convert2Entity(Permission permission);
        Permission Convert2Model(TblPermission item);
        Task<int> CreatePermission(Permission permission);
        Task<TblPermission> GetPermByID(int permId);
        Task<IEnumerable<Permission>> GetPermissionList();
        Task<int> UpdatePermission(int PermID, Permission permission);
    }
}