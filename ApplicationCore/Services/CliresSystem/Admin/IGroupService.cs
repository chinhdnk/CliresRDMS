using Infrastructure.Models.CliresSystem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public interface IGroupService
    {
        Task<int> CreateGroupAsync(Group group);
        Task<bool> DeleteGroupAsync(int id);
        Task UpdateGroupAsync(Group group);
        Task<IEnumerable<Group>> ViewGroupAsync();
        Task<Group> ViewGroupById(int id);
    }
}