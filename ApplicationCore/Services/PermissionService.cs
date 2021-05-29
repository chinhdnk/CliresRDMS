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

        public async Task<IEnumerable<TblPermission>> ViewPermissionAsync()
        {
            return await webApiExecuter.InvokeGet<IEnumerable<TblPermission>>("api/cliressystem/permissions");
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await webApiExecuter.InvokeGet<Permission>($"api/permissions/{id}");
        }
        public async Task<int> CreateAsync(Permission permission)
        {
            permission = await webApiExecuter.InvokePost("api/permissions", permission);
            return permission.PermissionID;
        }
        public async Task UpdateAsync(Permission permission)
        {
            await webApiExecuter.InvokePut($"api/permissions/{permission.PermissionID}", permission);
        }

        public async Task DeleteAsync(int id)
        {
            await webApiExecuter.InvokeDelete($"api/permissions/{id}");
        }
    }
}
