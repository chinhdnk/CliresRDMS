using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IPermissionRepository
    {
        Permission Convert2Model(TblPermission item);
        Task<List<TblPermission>> GetPermissionList();
    }
}