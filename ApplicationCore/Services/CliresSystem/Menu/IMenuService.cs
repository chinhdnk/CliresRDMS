using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.MenuPage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services.CliresSystem
{
    public interface IMenuService
    {
        Task<IEnumerable<MainMenu>> ViewMenusAsync();
    }
}