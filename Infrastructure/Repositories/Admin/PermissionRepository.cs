using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly CliresSystemDBContext dbContext;
        public PermissionRepository(CliresSystemDBContext context)
        {
            this.dbContext = context;
        }
        public async Task<List<TblPermission>> GetPermissionList()
        {
            var items = await dbContext.TblPermissions.ToListAsync();
            return items;
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
    }
}
