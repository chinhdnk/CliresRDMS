using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models;
using Infrastructure.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace ApplicationCore.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CliresSystemDBContext dbContext;
        public AccountRepository(CliresSystemDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TblAccount> CheckUserIdentity(string username, string password)
        {
            TblAccount account = await dbContext.TblAccounts.Where(x => x.Username == username).FirstOrDefaultAsync();
            if (account == null || !BC.Verify(account.Salt + password, account.Password))
                return null;
            return account;
        }

        public async Task<string> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                TblAccount account = await CheckUserIdentity(model.Username, model.OldPassword);
                if (account == null)
                    return "pw_incorrect";
                else
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(account.Salt + model.NewPassword);
                    account.Password = passwordHash;
                    account.PasswordDate = DateTime.Now;
                    dbContext.Entry(account).State = EntityState.Modified;

                    await dbContext.SaveChangesAsync();
                    return null;
                }
            }
            catch (Exception)
            {
                return "system_error";
            }
        }
    }
}
