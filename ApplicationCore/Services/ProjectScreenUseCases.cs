using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Repositories;
using Infrastructure.Models;

namespace ApplicationCore.Services
{
    public class ProjectsScreenUseCases : IProjectsScreenUseCases
    {
        private readonly IProjectRepository projectRepository;
        public ProjectsScreenUseCases(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> ViewProjectsAsync()
        {
            return await projectRepository.GetAsync();
        }
    }
}
