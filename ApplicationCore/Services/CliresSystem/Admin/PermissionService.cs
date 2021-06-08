using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Repositories.ApiClient;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.CliresSystem;

namespace ApplicationCore.Services.CliresSystem
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
            var response = await webApiExecuter.InvokeGet<IEnumerable<Permission>>("api/cliressystem/permission");
            return response;
        }
        public async Task<TblPermission> ViewPermById(int id)
        {
            return await webApiExecuter.InvokeGet<TblPermission>($"api/cliressystem/permission/{id}");
        }
        public async Task<string> CreatePermAsync(Permission permission)
        {
            permission = await webApiExecuter.InvokePost("api/permission", permission);
            return permission.PermissionID;
        }
        public async Task UpdatePermAsync(Permission permission)
        {
            await webApiExecuter.InvokePut($"api/permission/{permission.PermissionID}", permission);
        }

        public async Task DeletePermAsync(int id)
        {
            await webApiExecuter.InvokeDelete($"api/permission/{id}");
        }
    }
}
