using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IPermissionService
    {
        Task<int> CreatePermAsync(Permission permission);
        Task DeleteAsync(int id);
        Task UpdatePermAsync(Permission permission);
        Task<TblPermission> ViewPermById(int permId);
        Task<IEnumerable<Permission>> ViewPermissionAsync();
    }
}