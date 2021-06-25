using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.CliresSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.CliresSystem
{
    public class GroupRepository : IGroupRepository
    {
        private readonly CliresSystemDBContext dbContext;
        public GroupRepository(CliresSystemDBContext context)
        {
            this.dbContext = context;
        }

        public async Task<IEnumerable<Group>> GetGroupList()
        {
            try
            {
                IEnumerable<TblGroup> items = await dbContext.TblGroups.ToListAsync();
                IEnumerable<Group> groups = (from u in items select new Group(u));
                return groups;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Group> GetGrouByID(int groupId)
        {
            try
            {
                TblGroup item = await dbContext.TblGroups.Where(x => x.GroupId == groupId).FirstOrDefaultAsync();
                Group group = Convert2Model(item);
                return group;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CheckGroupExist(int groupID, string groupName)
        {
            TblGroup item = new TblGroup();
            if (groupID == 0)
                item = await dbContext.TblGroups.FirstOrDefaultAsync(x => x.Title.ToUpper() == groupName.ToUpper());
            else
                item = await dbContext.TblGroups.FirstOrDefaultAsync(x => x.Title.ToUpper() == groupName.ToUpper() && x.GroupId != groupID);

            return item != null;
        }
        public async Task<int> CreateGroup(Group group)
        {
            try
            {
                TblGroup item = new TblGroup();
                item = Convert2Entity(item, group);
                dbContext.TblGroups.Add(item);
                await dbContext.SaveChangesAsync();
                return DBStatus.SUCCESS;
            }
            catch (Exception)
            {
                return DBStatus.FAIL; ;
            }
        }

        public async Task<int> UpdateGroup(int groupId, Group group)
        {
            try
            {
                TblGroup item = await dbContext.TblGroups.FindAsync(groupId);
                if (item == null)
                    return DBStatus.NOT_FOUND;
                item = Convert2Entity(item, group);
                dbContext.Entry(item).State = EntityState.Modified;

                await dbContext.SaveChangesAsync();
                return DBStatus.SUCCESS;
            }
            catch (Exception)
            {
                return DBStatus.FAIL;
            }

        }
        public async Task<bool> DeleteGroup(int groupId)
        {
            try
            {
                TblGroup item = await dbContext.TblGroups.FindAsync(groupId);
                if (item == null)
                    return false;
                dbContext.RemoveRange(item);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        private Group Convert2Model(TblGroup item)
        {
            Group model = new Group();
            model.GroupID = item.GroupId;
            model.GroupName = item.Title;
            model.Status = item.Status;
            model.CreatedDate = item.CreatedDate;
            model.CreatedBy = item.CreatedBy;
            model.ModifiedBy = item.ModifiedBy;
            model.ModifiedDate = item.ModifiedDate;
            return model;
        }

        private TblGroup Convert2Entity(TblGroup entity, Group group)
        {
            entity.GroupId = group.GroupID;
            entity.Title = group.GroupName;
            entity.Status = group.Status;
            entity.CreatedBy = group.CreatedBy;
            entity.CreatedDate = group.CreatedDate;
            entity.ModifiedBy = group.ModifiedBy;
            entity.ModifiedDate = group.ModifiedDate;
            return entity;

        }
    }
}
