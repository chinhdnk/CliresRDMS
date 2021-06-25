using Infrastructure.Models.CliresSystem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.CliresSystem
{
    public interface IGroupRepository
    {
        Task<bool> CheckGroupExist(int groupID, string groupName);
        Task<int> CreateGroup(Group group);
        Task<bool> DeleteGroup(int groupId);
        Task<Group> GetGrouByID(int groupId);
        Task<IEnumerable<Group>> GetGroupList();
        Task<int> UpdateGroup(int groupId, Group group);
    }
}