using Infrastructure.Models.CliresSystem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public interface IMenuService
    {
        Task<IEnumerable<MainMenu>> ViewMenusAsync();
    }
}