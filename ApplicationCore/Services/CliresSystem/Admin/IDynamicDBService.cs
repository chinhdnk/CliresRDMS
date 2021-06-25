using Infrastructure.Entities.ProjectsDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public interface IDynamicDBService
    {
        Task<IEnumerable<TblStudyCode>> ViewPatientsAsync(string url);
    }
}