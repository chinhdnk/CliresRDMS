using ApplicationCore.Repositories.ApiClient;
using Infrastructure.Models.CliresSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public class MenuService : IMenuService
    {
        private readonly IWebApiExecuter webApiExecuter;
        public MenuService(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }

        public async Task<IEnumerable<MainMenu>> ViewMenusAsync()
        {
            return await webApiExecuter.InvokeGet<IEnumerable<MainMenu>>("api/cliressystem/menu");
        }
    }
}
