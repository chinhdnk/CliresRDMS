using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.CliresSystem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public interface IPermissionService
    {
        Task<string> CreatePermAsync(Permission permission);
        Task DeletePermAsync(int id);
        Task UpdatePermAsync(Permission permission);
        Task<TblPermission> ViewPermById(int id);
        Task<IEnumerable<Permission>> ViewPermissionAsync();
    }
}