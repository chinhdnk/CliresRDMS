using ApplicationCore.Repositories.ApiClient;
using System;
using System.Collections.Generic;
using Infrastructure.Models.CliresSystem;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public class GroupService : IGroupService
    {
        private readonly IWebApiExecuter webApiExecuter;
        public GroupService(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }

        public async Task<IEnumerable<Group>> ViewGroupAsync()
        {
            var response = await webApiExecuter.InvokeGet<IEnumerable<Group>>("api/cliressystem/group");
            return response;
        }
        public async Task<Group> ViewGroupById(int id)
        {
            return await webApiExecuter.InvokeGet<Group>($"api/cliressystem/group/{id}");
        }
        public async Task<int> CreateGroupAsync(Group group)
        {
            group = await webApiExecuter.InvokePost("api/cliressystem/group", group);
            return group.GroupID;
        }
        public async Task UpdateGroupAsync(Group group)
        {
            await webApiExecuter.InvokePut($"api/cliressystem/group/{group.GroupID}", group);
        }

        public async Task<bool> DeleteGroupAsync(int id)
        {
            return await webApiExecuter.InvokeDelete($"api/cliressystem/group/{id}");
        }
    }
}
