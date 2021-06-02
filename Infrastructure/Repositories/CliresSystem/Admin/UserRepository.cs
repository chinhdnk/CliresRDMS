using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CliresSystem
{
    public class UserRepository : IUserRepository
    {
        private readonly CliresSystemDBContext dbContext;
        public UserRepository(CliresSystemDBContext context)
        {
            this.dbContext = context;
        }
        public async Task<IEnumerable<TblUser>> GetUserList()
        {
            IEnumerable<TblUser> items = await dbContext.TblUsers.ToListAsync();
            IEnumerable<UserModel> users = (from u in items select new UserModel(u));
            return items;
        }
    }
}
