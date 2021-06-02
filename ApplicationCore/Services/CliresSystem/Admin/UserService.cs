using ApplicationCore.Repositories.ApiClient;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem.Admin
{
    public class UserService : IUserService
    {
        private readonly IWebApiExecuter webApiExecuter;
        public UserService(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }

        public async Task<IEnumerable<TblUser>> ViewUserAsync()
        {
            return await webApiExecuter.InvokeGet<IEnumerable<TblUser>>("api/cliressystem/user");
        }
    }
}
