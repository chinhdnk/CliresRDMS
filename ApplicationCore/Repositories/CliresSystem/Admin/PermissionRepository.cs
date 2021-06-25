using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.CliresSystem;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.CliresSystem
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly CliresSystemDBContext dbContext;
        public PermissionRepository(CliresSystemDBContext context)
        {
            this.dbContext = context;
        }

        public IQueryable<string> GetPermOfUser(string userName)
        {
            var listPermGroup = (from p in dbContext.TblPermissions
                                 join gp in dbContext.TblGroupPermissions on p.PermId equals gp.PermId
                                 join u in dbContext.TblUserGroups on gp.GroupId equals u.GroupId
                                 where u.Username == userName
                                 select p.PermId).Distinct();
            var listPermUser = (from p in dbContext.TblPermissions
                                join up in dbContext.TblUserPermissions on p.PermId equals up.PermId
                                where up.Username == userName
                                select p.PermId).Distinct();
            var listPerm = listPermGroup.Concat(listPermUser);
            return listPerm.Distinct();
        }

        public async Task<IEnumerable<Permission>> GetPermissionList()
        {
            try
            {
                IEnumerable<TblPermission> items = await dbContext.TblPermissions.ToListAsync();
                IEnumerable<Permission> perms = (from u in items select new Permission(u));
                return perms;
            }
            catch
            {
                return null;
            }

        }

        public async Task<Permission> GetPermByID(string permId)
        {
            try
            {
                TblPermission item = await dbContext.TblPermissions.Where(x => x.PermId == permId).FirstOrDefaultAsync();
                Permission perm = Convert2Model(item);
                return perm;
            }
            catch
            {
                return null;
            }

        }

        public async Task<string> CreatePermission(Permission permission)
        {
            try
            {
                TblPermission perm = new TblPermission();
                perm = Convert2Entity(perm, permission);
                dbContext.TblPermissions.Add(perm);
                await dbContext.SaveChangesAsync();
                return perm.PermId;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> UpdatePermission(string PermID, Permission permission)
        {
            try
            {
                TblPermission perm = await dbContext.TblPermissions.FindAsync(PermID);
                if (perm == null)
                    return DBStatus.NOT_FOUND;
                perm = Convert2Entity(perm, permission);
                dbContext.Entry(perm).State = EntityState.Modified;

                await dbContext.SaveChangesAsync();
                return DBStatus.SUCCESS;
            }
            catch
            {
                return DBStatus.FAIL;
            }

        }

        public async Task<int> DeletePermission(string permId)
        {
            try
            {
                TblPermission item = await dbContext.TblPermissions.FindAsync(permId);
                if (item == null)
                    return DBStatus.NOT_FOUND;
                dbContext.RemoveRange(item);
                await dbContext.SaveChangesAsync();
                return DBStatus.SUCCESS;
            }
            catch
            {
                return DBStatus.FAIL;
            }

        }
        private Permission Convert2Model(TblPermission item)
        {
            Permission model = new Permission();
            model.PermissionID = item.PermId;
            model.Status = item.Status;
            model.CreatedBy = item.CreatedBy;
            model.CreatedDate = model.CreatedDate;
            model.ModifiedBy = item.ModifiedBy;
            model.ModifiedDate = item.ModifiedDate;
            return model;
        }

        private TblPermission Convert2Entity(TblPermission entity, Permission permission)
        {
            entity.PermId = permission.PermissionID;
            entity.Status = permission.Status;
            entity.CreatedBy = permission.CreatedBy;
            entity.CreatedDate = permission.CreatedDate;
            entity.ModifiedBy = permission.ModifiedBy;
            entity.ModifiedDate = permission.ModifiedDate;
            return entity;

        }
    }
}
