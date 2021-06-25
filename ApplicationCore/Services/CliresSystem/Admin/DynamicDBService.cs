using ApplicationCore.Repositories.ApiClient;
using Infrastructure.Entities.ProjectsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public class DynamicDBService : IDynamicDBService
    {
        private readonly IWebApiExecuter webApiExecuter;
        public DynamicDBService(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }

        public async Task<IEnumerable<TblStudyCode>> ViewPatientsAsync(string url)
        {
            var response = await webApiExecuter.InvokeGet<IEnumerable<TblStudyCode>>(url);
            return response;
        }
    }
}
