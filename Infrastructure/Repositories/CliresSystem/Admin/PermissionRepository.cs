using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CiresSystem
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly CliresSystemDBContext dbContext;
        public PermissionRepository(CliresSystemDBContext context)
        {
            this.dbContext = context;
        }
        public async Task<IEnumerable<Permission>> GetPermissionList()
        {
            IEnumerable<TblPermission> items = await dbContext.TblPermissions.ToListAsync();
            IEnumerable<Permission> perms = (from u in items select new Permission(u));
            return perms;
        }

        public async Task<TblPermission> GetPermByID(int permId)
        {
            TblPermission item = await dbContext.TblPermissions.Where(x => x.PermId == permId).FirstOrDefaultAsync();
            //Permission perm = new Permission(item);
            return item;
        }

        public async Task<int> CreatePermission(Permission permission)
        {
            TblPermission perm = Convert2Entity(permission);
            dbContext.TblPermissions.Add(perm);
            await dbContext.SaveChangesAsync();
            return perm.PermId;

        }

        public async Task<int> UpdatePermission(int PermID, Permission permission)
        {
            TblPermission perm = Convert2Entity(permission);
            dbContext.Entry(perm).State = EntityState.Modified;
            try
            {
                await dbContext.SaveChangesAsync();
                return (int)DBStatus.Success;
            }
            catch
            {
                if (await dbContext.TblPermissions.FindAsync(PermID) == null)
                    return (int)DBStatus.NotFound;
                throw;
            }

        }
        public Permission Convert2Model(TblPermission item)
        {
            Permission model = new Permission();
            model.PermissionName = item.Title;
            model.Status = item.Status;
            model.CreatedBy = item.CreatedBy;
            model.CreatedDate = model.CreatedDate;
            model.ModifiedBy = item.ModifiedBy;
            model.ModifiedDate = item.ModifiedDate;
            return model;
        }

        public TblPermission Convert2Entity(Permission permission)
        {
            TblPermission entity = new TblPermission();
            entity.PermId = permission.PermissionID;
            entity.Title = permission.PermissionName;
            entity.Status = permission.Status;
            entity.CreatedBy = permission.CreatedBy;
            entity.CreatedDate = permission.CreatedDate;
            entity.ModifiedBy = permission.ModifiedBy;
            entity.ModifiedDate = permission.ModifiedDate;
            return entity;

        }
    }
}
