using Infrastructure.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Entities.CliresSystem;

namespace ApplicationCore.Services
{
    public interface IPermissionService
    {
        Task<int> CreateAsync(Permission permission);
        Task DeleteAsync(int id);
        Task<Permission> GetByIdAsync(int id);
        Task UpdateAsync(Permission permission);
        Task<IEnumerable<TblPermission>> ViewPermissionAsync();
    }
}