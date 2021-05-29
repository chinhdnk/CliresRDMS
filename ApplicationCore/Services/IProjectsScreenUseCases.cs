using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IProjectsScreenUseCases
    {
        Task<IEnumerable<Project>> ViewProjectsAsync();
    }
}