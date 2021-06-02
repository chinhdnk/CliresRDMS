using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Repositories;
using ApplicationCore.Repositories.ApiClient;
using Infrastructure.Models.Admin;
using Infrastructure.Entities.CliresSystem;

namespace ApplicationCore.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IWebApiExecuter webApiExecuter;
        public PermissionService(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }

        public async Task<IEnumerable<Permission>> ViewPermissionAsync()
        {
            return await webApiExecuter.InvokeGet<IEnumerable<Permission>>("api/cliressystem/permission");
        }
        public async Task<TblPermission> ViewPermById(int id)
        {
            return await webApiExecuter.InvokeGet<TblPermission>($"api/cliressystem/permission/{id}");
        }
        public async Task<int> CreatePermAsync(Permission permission)
        {
            permission = await webApiExecuter.InvokePost("api/permission", permission);
            return permission.PermissionID;
        }
        public async Task UpdatePermAsync(Permission permission)
        {
            await webApiExecuter.InvokePut($"api/permission/{permission.PermissionID}", permission);
        }

        public async Task DeleteAsync(int id)
        {
            await webApiExecuter.InvokeDelete($"api/permission/{id}");
        }
    }
}
